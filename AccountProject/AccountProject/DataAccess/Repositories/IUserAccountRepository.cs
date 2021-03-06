﻿using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserAccountRepository
    {
        /// <summary>
        /// Adds new account to database
        /// </summary>
        /// <param name="account">Account to add</param>
        Task<BankAccounts> GetAccountAsync(string userName, string password);


        /// <summary>
        /// Gets account from database, which maches username & password
        /// </summary>
        /// <param name="userName">Username to find</param>
        /// <param name="password">Password to find</param>
        /// <returns></returns>
        Task AddNewAccountAsync(string userName, string password);

        /// <summary>
        /// Checks if user is allready in database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> IsExistAsync(string userName);
    }
}
