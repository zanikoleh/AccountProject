using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    public class TransactionRepository: ITransactionRepository
    {
        private IRepositoryBase _repositoryBase;

        public TransactionRepository(IRepositoryBase repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        /// <summary>
        /// Gets all transactions for specific user 
        /// </summary>
        /// <param name="userName">Username on which transactions to get</param>
        /// <returns>Collection of transactions</returns>
        public IEnumerable<Transactions> GetTransactionOnUser(string userName)
        {
            return from transaction in _repositoryBase.BankContext.Transactions
                   where transaction.Username == userName
                   select transaction;
        }
    }
}
