using System.Collections.Generic;
using System.Linq;
using DataAccess.Repositories;
using AccountProject.Models.Models;

namespace AccountProject.Core.Services.imp
{
    public class TransactionService: ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        public IResultModel GetTransactionOnUser(string userName)
        {
            try
            {
                return new ResultModel<IEnumerable<decimal>>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = from transaction in this._transactionRepository.GetTransactionOnUser(userName)
                             select transaction.Amount
                };
            }
            catch
            {
                return new ResultModel<IEnumerable<decimal>>
                {
                    Status = Status.Error,
                    Message = "Can't find transactions for current user",
                    Object = null
                };
            }
        }
    }
}