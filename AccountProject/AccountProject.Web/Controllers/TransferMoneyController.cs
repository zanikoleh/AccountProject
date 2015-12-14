using AccountProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class TransferMoneyController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public TransferMoneyController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [Authorize]
        public IHttpActionResult Post(string currentUsername, string targetUsername, decimal value)
        {
            _bankAccountService.TransferMoney(currentUsername, targetUsername, value);
            return Ok();
        }
    }
}
