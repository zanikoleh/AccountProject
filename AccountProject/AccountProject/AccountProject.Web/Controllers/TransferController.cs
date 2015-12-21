using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Threading.Tasks;

namespace AccountProject.Web.Controllers
{
    public class TransferController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public TransferController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IResultModel> Post(TransferModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultModel<object>
                {
                    Status = Status.Error,
                    Message = "Model is invalid",
                    Object = null
                };
            }
            else
            {
                return await this._bankAccountService.TransferMoneyAsync(model.CurrentUserName, model.TargetUserName, model.Amount);
            }
        }
    }
}
