using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;
using AccountProject.Models;
using DataAccess.Repositories.impl;

namespace AccountProject.Web.Controllers
{
    public class TransactionStatementController : ApiController
    {
        private ITransactionService _transactionService;
        /*public TransactionStatementController()
        {
            this._transactionService = new TransactionService(new TransactionRepository(new RepositoryBase()));
        }*/

        public TransactionStatementController(ITransactionService serv)
        {
            this._transactionService = serv;
        }

        [HttpGet]
        public IResultModel Get(string username)
        {
            return this._transactionService.GetTransactionOnUser(username);
        }
    }
}
