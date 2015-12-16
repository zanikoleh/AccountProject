using AccountProject.Models;
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
                return new GetBalanceModel { Username = userName, Amount = this._bankAccountRepository.GetBalance(userName) };
            }
            catch(Exception ex)
            {
                return new ErrorModel<GetBalanceModel> { Status = "Error", Message = ex.Message, Object = new GetBalanceModel { Username = userName, Amount = 0 } };
            }
        }

        public IResultModel DepositMoney(string username, decimal value)
        {
            try
            {
                this._bankAccountRepository.DepositMoney(username, value);
                return new DepositMoneyModel { Username = username, Amount = value };
            }
            catch(Exception ex)
            {
                return new ErrorModel<DepositMoneyModel> { Status = "Error", Message = ex.Message, Object = new DepositMoneyModel { Username = username, Amount = value } };
            }
        }

        public IResultModel WithdrawMoney(string username, decimal value)
        {
            try
            {
                this._bankAccountRepository.WithdrawMoney(username, value);
                return new DepositMoneyModel { Username = username, Amount = -1 * value };
            }
            catch (Exception ex)
            {
                return new ErrorModel<DepositMoneyModel> { Status = "Error", Message = ex.Message, Object = new DepositMoneyModel { Username = username, Amount = value * (-1) } };
            }
        }

        public IResultModel TransferMoney(string currentUserName, string targetUserName, decimal value)
        {
            try
            {
                this._bankAccountRepository.TransferMoney(currentUserName, targetUserName, value);
                return new TransferMoneyModel { Username = currentUserName, Target = targetUserName, Amount = value };
            }
            catch (Exception ex)
            {
                return new ErrorModel<TransferMoneyModel> { Status = "Error", Message = ex.Message, Object = new TransferMoneyModel { Username = currentUserName, Target = targetUserName, Amount = value } };
            }
        }
    }
}
