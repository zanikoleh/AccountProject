using DataAccess.Repositories;
using AccountProject.Models.Models;

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
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel { Username = username, Value = 0 }
                };
            }
            catch
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "User with such name allready registered",
                    Object = null
                };
            }
        }
    }
}