using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories.impl
{
    public class BankAccountRepository: RepositoryBase, IBankAccountRepository
    {
        /// <summary>
        /// Gets BankAccount which matches name
        /// </summary>
        /// <param name="userName">Account's username</param>
        /// <returns>BankAccount instance</returns>
        private async Task<BankAccounts> GetAccountAsync(string userName)
        {
            return await (from user in this.BankContext.BankAccounts
                    where user.Username == userName
                    select user).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Checks if update for current account can be performed
        /// </summary>
        /// <param name="account">Account to check</param>
        /// <param name="value">Value to check</param>
        /// <returns>True if update is valid</returns>
        private bool IsValideUpdate(BankAccounts account, decimal value)
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

        public async Task<decimal> GetBalanceAsync(string userName)
        {
            var user = await this.GetAccountAsync(userName);
            return user.AccountBalance;
        }

        public async Task UpdateAccountBalanceAsync(string userName, decimal value)
        {
            var account = await this.GetAccountAsync(userName);
            if (IsValideUpdate(account, value))
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
                        await this.BankContext.SaveChangesAsync();
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

        public async Task TransferMoneyAsync(string currentUserName, string targetUserName, decimal value)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    BankAccounts currentUser = await this.GetAccountAsync(currentUserName);
                    if (IsValideUpdate(currentUser, value))
                    {
                        BankAccounts targetUser = await this.GetAccountAsync(targetUserName);
                        currentUser.AccountBalance -= value;
                        targetUser.AccountBalance += value;
                        await this.BankContext.SaveChangesAsync();
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