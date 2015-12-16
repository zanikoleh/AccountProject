using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;

namespace AccountProject.Web.Controllers
{
    public class RegisterController : ApiController
    {
        private IUserAccountService _userAccountService;

        public RegisterController(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }

        [HttpPost]
        public IResultModel Post(RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                // ToDo
            }
            return this._userAccountService.Register(model.UserName, model.Password);
        }
    }
}
