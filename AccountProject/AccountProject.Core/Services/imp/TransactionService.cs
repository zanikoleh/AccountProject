using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace AccountProject.Core.Services.imp
{
    public class Transaction
    {
        public string UserName { get; set; }
        public decimal Amount { get; set; }
    }

    class TransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetTransactionOnUser(string userName)
        {
            return from transaction in this._transactionRepository.GetTransactionOnUser(userName)
                   select new Transaction { UserName = transaction.Username, Amount = transaction.Amount };
        }
    }
}
