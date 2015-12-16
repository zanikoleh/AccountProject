using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using AccountProject.Models;

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
                var result = new TransactionStatementModel
                {
                    Username = userName,
                    Transactions = (from transaction in this._transactionRepository.GetTransactionOnUser(userName)
                                    select new Transaction { UserName = transaction.Username, Amount = transaction.Amount })
                };
                return result;
            }
            catch(Exception ex)
            {
                return new ErrorModel<TransactionStatementModel> { Status = "Error", Message = ex.Message, Object = new TransactionStatementModel { Username = userName } };
            }
        }
    }
}