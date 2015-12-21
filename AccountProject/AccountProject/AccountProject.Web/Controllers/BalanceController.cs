using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Threading.Tasks;
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

        [Authorize]
        [HttpGet]
        public async Task<IResultModel> Get(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var result = await this._bankAccountService.GetBalanceAsync(userName);
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
