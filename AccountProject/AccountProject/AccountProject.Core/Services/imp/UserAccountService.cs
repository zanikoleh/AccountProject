using DataAccess.Repositories;
using AccountProject.Models.Models;
using System;
using System.Threading.Tasks;

namespace AccountProject.Core.Services.imp
{
    public class UserAccountService: IUserAccountService
    {
        private IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            this._userAccountRepository = userAccountRepository;
        }

        public async Task<IResultModel> RegisterAsync(string userName, string password)
        {
            bool used = await this._userAccountRepository.IsExistAsync(userName);
            if (used)
            {
                return new ResultModel<object>
                {
                    Status = Status.Error,
                    Message = "User with such name allready registered",
                    Object = null
                };
            }
            else
            {
                await this._userAccountRepository.AddNewAccountAsync(userName, password);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel { Username = userName, Amount = 0 }
                };
            }
        }
    }
}