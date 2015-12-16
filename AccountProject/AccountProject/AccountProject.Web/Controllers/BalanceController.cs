using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class BalanceController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public BalanceController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [HttpGet]
        public IResultModel Get(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var result = this._bankAccountService.GetBalance(userName);
                return result;
            }
            else
            {
                return new ResultModel<object>
                {
                    Status = Status.Error,
                    Message = "Username field musn't be null or empty",
                    Object = null
                };
            }
        }
    }
}
