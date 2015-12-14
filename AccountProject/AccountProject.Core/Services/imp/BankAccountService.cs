using DataAccess.Repositories;

namespace AccountProject.Core.Services.imp
{

    public class BankAccountService : IBankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            this._bankAccountRepository = bankAccountRepository;
        }

        public decimal GetBalance(string userName)
        {
            return this._bankAccountRepository.GetBalance(userName);
        }

        public void DepositMoney(string username, decimal value)
        {
            this._bankAccountRepository.DepositMoney(username, value);
        }

        public void WithdrawMoney(string userName, decimal value)
        {
            this._bankAccountRepository.WithdrawMoney(userName, value);
        }

        public void TransferMoney(string currentUserName, string targetUserName, decimal value)
        {
            this._bankAccountRepository.TransferMoney(currentUserName, targetUserName, value);
        }
    }
}
