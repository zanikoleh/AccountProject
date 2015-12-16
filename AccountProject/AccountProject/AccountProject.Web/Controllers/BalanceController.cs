using AccountProject.Core.Services;
using AccountProject.Core.Services.imp;
using AccountProject.Models;
using DataAccess.Repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class BalanceController : ApiController
    {
        private IBankAccountService _bankAccountService;
        /*public GetBalanceController()
        {
            this._bankAccountService = new BankAccountService(new BankAccountRepository(new RepositoryBase()));
        }*/

        public BalanceController(IBankAccountService serv)
        {
            this._bankAccountService = serv;
        }

        [HttpGet]
        public IResultModel Get(string username)
        {
            var result = this._bankAccountService.GetBalance(username);
            return result;
        }
    }
}
