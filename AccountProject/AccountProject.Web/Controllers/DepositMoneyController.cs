using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;

namespace AccountProject.Web.Controllers
{
    public class DepositMoneyController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public DepositMoneyController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult Post(string username, decimal amount)
        {
            this._bankAccountService.DepositMoney(username, amount);
            return Ok();
        }
    }
}