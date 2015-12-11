using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class DepositMoneyController : ApiController
    {
        [Authorize]
        public IHttpActionResult Post()
        {
            return Ok();
        }
    }
}
