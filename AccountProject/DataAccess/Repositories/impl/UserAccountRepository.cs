using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    class UserAccountRepository
    {
        private IRepositoryBase _repositoryBase;

        public UserAccountRepository(IRepositoryBase repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        /// <summary>
        /// Adds new account to database
        /// </summary>
        /// <param name="account">Account to add</param>
        public void AddNewAccount(string userName, string password)
        {
            _repositoryBase.BankContext.BankAccounts.Add(new BankAccounts { Username = userName, Password = password });
            _repositoryBase.BankContext.SaveChanges();
        }

        /// <summary>
        /// Gets account from database, which maches username & password
        /// </summary>
        /// <param name="userName">Username to find</param>
        /// <param name="password">Password to find</param>
        /// <returns></returns>
        public BankAccounts GetAccount(string userName, string password)
        {
            return (from user in _repositoryBase.BankContext.BankAccounts
                    where user.Username == userName && user.Password == password
                    select user).FirstOrDefault();
        }

    }
}
