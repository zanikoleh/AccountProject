using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Web.Http;

namespace AccountProject.Web.Controllers
{
    public class WithdrawController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public WithdrawController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [HttpPut]
        public IResultModel Put(UserModel model)
        {
            return this._bankAccountService.WithdrawMoney(model.Username, model.Value);
        }
    }
}
