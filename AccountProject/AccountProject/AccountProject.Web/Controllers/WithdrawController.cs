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
    public class WithdrawController : ApiController
    {
        private IBankAccountService _bankAccountService;
        //public WithdrawController()
        //{
        //    this._bankAccountService = new BankAccountService(new BankAccountRepository(new RepositoryBase()));
        //}

        public WithdrawController(IBankAccountService serv)
        {
            this._bankAccountService = serv;
        }

        [HttpPut]
        public IResultModel Put(string username, decimal amount)
        {
            return this._bankAccountService.WithdrawMoney(username, amount);
        }
    }
}
