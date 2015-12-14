using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace AccountProject.Core.Services.imp
{
    public class UserAccountService: IUserAccountService
    {
        private IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            this._userAccountRepository = userAccountRepository;
        }

        public void Register(string username, string password)
        {
            this._userAccountRepository.AddNewAccount(username, password);
        }
    }
}