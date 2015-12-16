using AccountProject.Models.Models;

namespace AccountProject.Core.Services
{
    public interface IBankAccountService
    {
        /// <summary>
        /// Deposits money for user
        /// </summary>
        /// <param name="userName">Name of user to make deposit</param>
        /// <param name="value">Amount to deposit</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        IResultModel DepositMoney(string username, decimal value);

        /// <summary>
        /// Gets balance on user
        /// </summary>
        /// <param name="userName">Name of user to get balance</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        IResultModel GetBalance(string userName);

        /// <summary>
        /// Withdraws money for user
        /// </summary>
        /// <param name="userName">Name of user to make withdraw</param>
        /// <param name="value">Amount to withdraw</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        IResultModel WithdrawMoney(string userName, decimal value);

        /// <summary>
        /// Transfer money from one user to another
        /// </summary>
        /// <param name="currentUserName">Name of user, who want to transfer</param>
        /// <param name="targetUserName">Name of user, who will recieve money</param>
        /// <param name="value">Amount to transfer</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        IResultModel TransferMoney(string currentUserName, string targetUserName, decimal value);
    }
}
