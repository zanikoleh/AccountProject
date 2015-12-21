using System.Web.Http;
using AccountProject.Core.Services;
using AccountProject.Models.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace AccountProject.Web.Controllers
{
    public class DepositController : ApiController
    {
        private IBankAccountService _bankAccountService;

        public DepositController(IBankAccountService bankAccountService)
        {
            this._bankAccountService = bankAccountService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IResultModel> Post(UserModel model)
        {
            var identity = User.Identity as ClaimsIdentity;
            var claims = from c in identity.Claims
                         select new
                         {
                             subject = c.Subject.Name,
                             type = c.Type,
                             value = c.Value
                         };


            if (!ModelState.IsValid)
            {
                return new ResultModel<UserModel>
                {
                    Status = Status.Error,
                    Message = "Model is invalid",
                    Object = model
                };
            }
            return await this._bankAccountService.DepositMoneyAsync(model.Username, model.Amount);
        }
    }
}