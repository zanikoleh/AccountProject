using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Threading.Tasks;

namespace AccountProject.Web.Controllers
{
    public class TransactionStatementController : ApiController
    {
        private ITransactionService _transactionService;

        public TransactionStatementController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IResultModel> Get(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = await this._transactionService.GetTransactionByUserAsync(username);
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
