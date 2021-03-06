﻿using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Threading.Tasks;
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

        [Authorize]
        [HttpPost]
        public async Task<IResultModel> Post(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Model is invalid",
                    Object = model
                };
            }
            return await this._bankAccountService.WithdrawMoneyAsync(model.Username, model.Amount);
        }
    }
}
