namespace DataAccess.Repositories
{
    public interface IUserAccountRepository
    {
        /// <summary>
        /// Adds new account to database
        /// </summary>
        /// <param name="account">Account to add</param>
        BankAccounts GetAccount(string userName, string password);


        /// <summary>
        /// Gets account from database, which maches username & password
        /// </summary>
        /// <param name="userName">Username to find</param>
        /// <param name="password">Password to find</param>
        /// <returns></returns>
        void AddNewAccount(string userName, string password);
    }
}
