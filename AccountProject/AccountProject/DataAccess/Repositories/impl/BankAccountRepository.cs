using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DataAccess.Repositories.impl
{
    public class BankAccountRepository: RepositoryBase, IBankAccountRepository
    {
        /// <summary>
        /// Gets BankAccount which matches name
        /// </summary>
        /// <param name="userName">Account's username</param>
        /// <returns>BankAccount instance</returns>
        private BankAccounts GetAccount(string userName)
        {
            return (from user in this.BankContext.BankAccounts
                    where user.Username == userName
                    select user).FirstOrDefault();
        }

        /// <summary>
        /// Checks if update for current account can be performed
        /// </summary>
        /// <param name="account">Account to check</param>
        /// <param name="value">Value to check</param>
        /// <returns>True if update is valid</returns>
        private bool valideUpdate(BankAccounts account, decimal value)
        {
            decimal firstValue = account.AccountBalance;
            decimal secondValue = -1 * value;
            if (firstValue < secondValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public decimal GetBalance(string userName)
        {
            return this.GetAccount(userName).AccountBalance;
        }

        public void UpdateAccountBalance(string userName, decimal value)
        {
            var account = this.GetAccount(userName);
            if (valideUpdate(account, value))
            {
                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        var transaction = new Transactions { Username = account.Username, Amount = value };
                        account.AccountBalance += value;
                        this.BankContext.Transactions.Add(transaction);
                        this.BankContext.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        ex.Entries.Single().Reload();
                    }
                }
                while (saveFailed);
            }
            else
            {
                throw new ArgumentException("Current user don't have enough money");
            }
        }

        public void TransferMoney(string currentUserName, string targetUserName, decimal value)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    BankAccounts currentUser = this.GetAccount(currentUserName);
                    if (valideUpdate(currentUser, value))
                    {
                        BankAccounts targetUser = this.GetAccount(targetUserName);
                        currentUser.AccountBalance -= value;
                        targetUser.AccountBalance += value;
                        this.BankContext.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentException("Current user don't have enough money");
                    }
                }

                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
            } while (saveFailed);
        }
    }
}