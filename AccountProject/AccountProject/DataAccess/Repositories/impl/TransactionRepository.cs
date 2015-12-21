using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    public class TransactionRepository: RepositoryBase, ITransactionRepository
    {
        public async Task<IEnumerable<Transactions>> GetTransactionByUserAsync(string userName)
        {
            return await
                   (from transaction in this.BankContext.Transactions
                   where transaction.Username == userName
                   select transaction).ToListAsync();
        }
    }
}
