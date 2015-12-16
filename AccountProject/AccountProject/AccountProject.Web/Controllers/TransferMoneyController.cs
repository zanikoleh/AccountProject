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
    public class TransferMoneyController : ApiController
    {
        private IBankAccountService _bankAccountService;
        /*public TransferMoneyController()
        {
            this._bankAccountService = new BankAccountService(new BankAccountRepository(new RepositoryBase()));
        }*/

        public TransferMoneyController(IBankAccountService serv)
        {
            this._bankAccountService = serv;
        }

        [HttpPost]
        public IResultModel Post(string currentUser, string targetUser, decimal amount)
        {
            return this._bankAccountService.TransferMoney(currentUser, targetUser, amount);
        }
    }
}
