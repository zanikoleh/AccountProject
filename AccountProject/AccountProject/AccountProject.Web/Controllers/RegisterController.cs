using System.Web.Http;
using AccountProject.Core.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System;
using AccountProject.Models.Models;

namespace AccountProject.Web.Controllers
{
    public class RegisterController : ApiController
    {
        private IUserAccountService _bankAccountService;

        public RegisterController(IUserAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IResultModel> Post(RegisterModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new ResultModel<RegisterModel>
                {
                    Status = AccountProject.Models.Models.Status.Error,
                    Message = "Model is invalid",
                    Object = userModel
                };
            }

            try
            {
                return await _bankAccountService.RegisterAsync(userModel.UserName, userModel.Password);
            }
            catch(Exception ex)
            {
                return new AccountProject.Models.Models.ResultModel < object >
                {
                    Status = AccountProject.Models.Models.Status.Error,
                    Message = ex.Message,
                    Object = null
                };
            }
        }
    }
}