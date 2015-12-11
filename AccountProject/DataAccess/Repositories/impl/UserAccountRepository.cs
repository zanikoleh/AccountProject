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
        public void AddNewAccount(BankAccounts account)
        {
            _repositoryBase.BankContext.BankAccounts.Add(account);
            _repositoryBase.BankContext.SaveChanges();
        }

        public void Login()
        {
            //To investigate
        }

    }
}
