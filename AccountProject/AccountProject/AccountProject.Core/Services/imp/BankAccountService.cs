using AccountProject.Models.Models;
using DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace AccountProject.Core.Services.imp
{

    public class BankAccountService : IBankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            this._bankAccountRepository = bankAccountRepository;
        }

        public async Task<IResultModel> GetBalanceAsync(string userName)
        {
            try
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel { Username = userName, Amount = await this._bankAccountRepository.GetBalanceAsync(userName)
                    }
                };
            }
            catch
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Couldn't find balance of current user",
                    Object = null
                };
            }
        }

        public async Task<IResultModel> DepositMoneyAsync(string userName, decimal value)
        {
            try
            {
                await this._bankAccountRepository.UpdateAccountBalanceAsync(userName, value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = userName,
                        Amount = value
                    }
                };
            }
            catch
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Couldn't make deposit for current user",
                    Object = null
                };
            }
        }

        public async Task<IResultModel> WithdrawMoneyAsync(string userName, decimal value)
        {
            try
            {
                await this._bankAccountRepository.UpdateAccountBalanceAsync(userName, -1 * value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = userName,
                        Amount = value
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = ex.Message,
                    Object = null
                };
            }
            catch
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Couldn't find balance of current user",
                    Object = null
                };
            }
        }

        public async Task<IResultModel> TransferMoneyAsync(string currentUserName, string targetUserName, decimal value)
        {
            try
            {
                await this._bankAccountRepository.TransferMoneyAsync(currentUserName, targetUserName, value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = currentUserName,
                        Amount = value
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = ex.Message,
                    Object = null
                };
            }
            catch
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Couldn't find balance of current user",
                    Object = null
                };
            }
        }
    }
}