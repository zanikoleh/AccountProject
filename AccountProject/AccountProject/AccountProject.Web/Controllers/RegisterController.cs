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
    public class RegisterController : ApiController
    {
        private IUserAccountService _userAccountService;
        /*public RegisterController()
        {
            this._userAccountService = new UserAccountService(new UserAccountRepository(new RepositoryBase()));
        }*/

        public RegisterController(IUserAccountService serv)
        {
            this._userAccountService = serv;
        }

        [HttpPost]
        public IResultModel Post(string username, string password)
        {
            return this._userAccountService.Register(username, password);
        }
    }
}
