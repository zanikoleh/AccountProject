using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;

namespace AccountProject.Web.Controllers
{
    public class TransferMoneyController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public TransferMoneyController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [HttpPost]
        public IResultModel Post(TransferModel model)
        {
            if (ModelState.IsValid)
            {
                return this._bankAccountService.TransferMoney(model.CurrentUserName, model.TargetUserName, model.Amount);
            }
            else
            {
                return this._bankAccountService.TransferMoney(model.CurrentUserName, model.TargetUserName, model.Amount);
            }
        }
    }
}
