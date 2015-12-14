using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountProject.Core.Services;

namespace AccountProject.Web.Controllers
{
    public class RegisterController : ApiController
    {
        private IUserAccountService _userAccountService;

        public RegisterController(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }

        public IHttpActionResult Post(string username, string password)
        {
            try
            {
                this._userAccountService.Register(username, password);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}