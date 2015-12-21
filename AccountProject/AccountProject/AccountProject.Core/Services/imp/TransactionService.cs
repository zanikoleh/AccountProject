using System.Collections.Generic;
using System.Linq;
using DataAccess.Repositories;
using AccountProject.Models.Models;
using System.Threading.Tasks;

namespace AccountProject.Core.Services.imp
{
    public class TransactionService: ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        public async Task<IResultModel> GetTransactionByUserAsync(string userName)
        {
            try
            {
                var transactions = await this._transactionRepository.GetTransactionByUserAsync(userName);
                return new ResultModel<IEnumerable<decimal>>
                {
                    Status = Status.Success,
                    Message = "",
                    Object = from transaction in transactions
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