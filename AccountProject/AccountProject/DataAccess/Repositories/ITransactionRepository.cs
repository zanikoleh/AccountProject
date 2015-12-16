using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Gets all transactions for specific user 
        /// </summary>
        /// <param name="userName">Username on which transactions to get</param>
        /// <returns>Collection of transactions</returns>
        IEnumerable<Transactions> GetTransactionOnUser(string userName);
    }
}
