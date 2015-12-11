using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    [Authorize]
    public class BankAccountController : ApiController
    {
        public HttpResponseMessage GetBalance() { return new HttpResponseMessage(); }
    }
}
