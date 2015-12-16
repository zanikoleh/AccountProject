using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;

namespace AccountProject.Web.Controllers
{
    public class DepositController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public DepositController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [HttpPost]
        public IResultModel Post(UserModel model)
        {
            if (!string.IsNullOrEmpty(model.Username))
            {
                if (model.Value > 0)
                {
                    return this._bankAccountService.DepositMoney(model.Username, model.Value);
                }
                else
                {
                    return new ResultModel<object>
                    {
                        Status = Status.Error,
                        Message = "Amount for deposit must be greater than 0",
                        Object = null
                    };
                }
            }
            else
            {
                return new ResultModel<object>
                {
                    Status = Status.Error,
                    Message = "User name mustn't be null or empty",
                    Object = null
                };
            }
        }
    }
}