using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.impl
{
    public class TransactionRepository: RepositoryBase, ITransactionRepository
    {
        public IEnumerable<Transactions> GetTransactionOnUser(string userName)
        {
            return from transaction in this.BankContext.Transactions
                   where transaction.Username == userName
                   select transaction;
        }
    }
}
