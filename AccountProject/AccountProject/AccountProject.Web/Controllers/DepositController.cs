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
    public class DepositController : ApiController
    {
        private IBankAccountService _bankAccountService;
        /*public DepositMoneyController()
        {
            this._bankAccountService = new BankAccountService(new BankAccountRepository(new RepositoryBase()));
        }*/

        public DepositController(IBankAccountService serv)
        {
            this._bankAccountService = serv;
        }

        [HttpPost]
        public IResultModel Post(string username, decimal amount)
        {
            return this._bankAccountService.DepositMoney(username, amount);
        }
    }
}