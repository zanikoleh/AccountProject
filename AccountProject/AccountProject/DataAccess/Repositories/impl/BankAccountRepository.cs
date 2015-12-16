using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    public class BankAccountRepository: IBankAccountRepository
    {
        private IRepositoryBase _repositoryBase;

        public BankAccountRepository(IRepositoryBase repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        /// <summary>
        /// Gets BankAccount which matches name
        /// </summary>
        /// <param name="userName">Account's username</param>
        /// <returns>BankAccount instance</returns>
        public BankAccounts GetAccount(string userName)
        {
            return (from user in _repositoryBase.BankContext.BankAccounts
                    where user.Username == userName
                    select user).FirstOrDefault();
        }

        /// <summary>
        /// Gets balance on account with username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public decimal GetBalance(string userName)
        {
            return this.GetAccount(userName).AccountBalance;
        }

        /// <summary>
        /// Updates account balance and creates transaction for it
        /// </summary>
        /// <param name="username"></param>
        /// <param name="value"></param>
        public void DepositMoney(string username, decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Deposit must be positive value");
            }
            else
            {
                this.UpdateAccountBalance(username, value);
            }
        }

        /// <summary>
        /// Updates account balance and creates transaction for it
        /// </summary>
        /// <param name="account"></param>
        /// <param name="value"></param>
        public void UpdateAccountBalance(string username, decimal value)
        {
            var user = this.GetAccount(username);

            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    //this._repositoryBase.BankContext.Entry(user).OriginalValues["RowVersion"] = user.RowVersion;
                    var transaction = new Transactions { Username = username, Amount = value };
                    user.AccountBalance += value;
                    _repositoryBase.BankContext.Transactions.Add(transaction);
                    _repositoryBase.BankContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
            }
            while (saveFailed);
        }


        public void WithdrawMoney(string userName, decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Withdraw must be positive value");
            }
            else
            {
                var user = this.GetAccount(userName);
                if(user.AccountBalance < value)
                {
                    throw new ArgumentException("Withdraw is greater than current balance");
                }
                else
                {
                    this.UpdateAccountBalance(userName, -1 * value);
                }
            }
        }

        /// <summary>
        /// Changes password for account with new one
        /// </summary>
        /// <param name="username">Username of account to change password</param>
        /// <param name="oldPassword">Old password of account</param>
        /// <param name="newPassword">New password for account</param>
        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = this.GetAccount(username);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
            }

            _repositoryBase.BankContext.SaveChanges();
        }

        /// <summary>
        /// Transfers money from one user to another
        /// </summary>
        /// <param name="currentUserName">User, who wants to transfer money</param>
        /// <param name="targetUserName">User, who will recieve money</param>
        /// <param name="value">Amount of money</param>
        public void TransferMoney(string currentUserName, string targetUserName, decimal value)
        {
            try
            {
                WithdrawMoney(currentUserName, value);
                DepositMoney(targetUserName, value);
            }

            catch(ArgumentException e)
            {
                throw new ArgumentException("Can't perform transfer." + e.Message);
            }
        }
    }
}