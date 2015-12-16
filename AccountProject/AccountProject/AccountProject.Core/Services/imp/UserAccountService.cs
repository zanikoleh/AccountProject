using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using AccountProject.Models;

namespace AccountProject.Core.Services.imp
{
    public class UserAccountService: IUserAccountService
    {
        private IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            this._userAccountRepository = userAccountRepository;
        }

        public IResultModel Register(string username, string password)
        {
            try
            {
                this._userAccountRepository.AddNewAccount(username, password);
                return new RegisterModel { Message = "Success!" };
            }
            catch(Exception ex)
            {
                //return new ErrorModel<RegisterModel> { Status = "Error", Message = ex.Message, Object = new RegisterModel { Message = "Can't create new user" } };
                return new ErrorModel<Exception> { Status = "Error", Message = "User with such username allready exists in the database", Object = ex };
            }
        }
    }
}