using AccountProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class GetBalanceController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public GetBalanceController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [Authorize]
        public IHttpActionResult Get(string username)
        {
            return Ok(_bankAccountService.GetBalance(username));
        }
    }
}