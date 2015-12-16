using AccountProject.Models.Models;

namespace AccountProject.Core.Services
{
    public interface IUserAccountService
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="username">Name of new user</param>
        /// <param name="password">Password of new user</param>
        /// <returns>Result model, which includes all nessesary data</returns>
        IResultModel Register(string username, string password);
    }
}
