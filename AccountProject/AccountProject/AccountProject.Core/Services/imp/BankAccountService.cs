using AccountProject.Models.Models;
using DataAccess.Repositories;
using System;

namespace AccountProject.Core.Services.imp
{

    public class BankAccountService : IBankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            this._bankAccountRepository = bankAccountRepository;
        }

        public IResultModel GetBalance(string userName)
        {
            try
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel { Username = userName, Value = this._bankAccountRepository.GetBalance(userName)
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

        public IResultModel DepositMoney(string userName, decimal value)
        {
            try
            {
                this._bankAccountRepository.UpdateAccountBalance(userName, value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = userName,
                        Value = value
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

        public IResultModel WithdrawMoney(string userName, decimal value)
        {
            try
            {
                this._bankAccountRepository.UpdateAccountBalance(userName, -1 * value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = userName,
                        Value = value
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

        public IResultModel TransferMoney(string currentUserName, string targetUserName, decimal value)
        {
            try
            {
                this._bankAccountRepository.TransferMoney(currentUserName, targetUserName, value);
                return new ResultModel<UserModel>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = new UserModel
                    {
                        Username = currentUserName,
                        Value = value
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
