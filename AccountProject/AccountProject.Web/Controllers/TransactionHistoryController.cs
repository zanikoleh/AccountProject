using AccountProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    [Authorize]
    public class TransactionHistoryController : ApiController
    {
        private ITransactionService _transactionService;

        public TransactionHistoryController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [Authorize]
        public IHttpActionResult Get(string username)
        {
            return Ok(_transactionService.GetTransactionOnUser(username));
        }
    }
}