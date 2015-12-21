using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IBankAccountRepository
    {
        /// <summary>
        /// Gets balance on account with username
        /// </summary>
        /// <param name="userName">Name of user which balance to get</param>
        /// <returns>Decimal user balance</returns>
        Task<decimal> GetBalanceAsync(string userName);

        /// <summary>
        /// Transfers money from one user to another
        /// </summary>
        /// <param name="currentUserName">User, who wants to transfer money</param>
        /// <param name="targetUserName">User, who will recieve money</param>
        /// <param name="value">Amount of money</param>
        Task TransferMoneyAsync(string currentUserName, string TargetUserName, decimal value);

        /// <summary>
        /// Updates account balance and creates transaction for it
        /// </summary>
        /// <param name="userName">Name of user to update balance</param>
        /// <param name="value">Value to update</param>
        Task UpdateAccountBalanceAsync(string userName, decimal value);
    }
}
