using AccountProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class WithdrawMoneyController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public WithdrawMoneyController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [Authorize]
        public IHttpActionResult Post(string username, decimal value)
        {
            _bankAccountService.WithdrawMoney(username, value);
            return Ok();
        }
    }
}