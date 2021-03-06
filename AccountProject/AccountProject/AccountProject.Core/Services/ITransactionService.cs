﻿using AccountProject.Models.Models;
using System.Threading.Tasks;

namespace AccountProject.Core.Services
{
    public interface ITransactionService
    {
        /// <summary>
        /// Gets transactions on certain user
        /// </summary>
        /// <param name="userName">Name of user for transactions to get</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        Task<IResultModel> GetTransactionByUserAsync(string userName);
    }
}
