﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    class TransactionRepository
    {
        private IRepositoryBase _repositoryBase;

        public TransactionRepository(IRepositoryBase repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        /// <summary>
        /// Gets all transactions for specific user 
        /// </summary>
        /// <param name="_username">Username on which transactions to get</param>
        /// <returns>Collection of transactions</returns>
        public IEnumerable<Transactions> GetTransactionOnUser(string _username)
        {
            return from transaction in _repositoryBase.BankContext.Transactions
                   where transaction.Username == _username
                   select transaction;
        }
    }
}
