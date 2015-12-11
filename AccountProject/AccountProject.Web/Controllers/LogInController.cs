using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountProject.Core.Services;
using System.Net.Http.Headers;

namespace AccountProject.Web.Controllers
{
    public class LogInController : ApiController
    {
        private IUserAccountService _userAccountService;

        public LogInController(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }

        public HttpResponseMessage Get(string userName, string password)
        {
            var resp = new HttpResponseMessage();
            //var value = Request.
            var cookie = new CookieHeaderValue("session-id", "12345");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
    }
}
