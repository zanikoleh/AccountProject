using AccountProject.Models.Models;
using System.Threading.Tasks;

namespace AccountProject.Core.Services
{
    public interface IUserAccountService
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="userName">Name of new user</param>
        /// <param name="password">Password of new user</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        Task<IResultModel> RegisterAsync(string userName, string password);
    }
}
