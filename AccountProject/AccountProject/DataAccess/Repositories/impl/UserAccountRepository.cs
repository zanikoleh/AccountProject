using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    public class UserAccountRepository: RepositoryBase, IUserAccountRepository
    {

        public async Task<bool> IsExistAsync(string userName)
        {
            bool toReturn = true;
            var result = await 
                         (from user in this.BankContext.BankAccounts
                          where user.Username == userName
                          select user).SingleOrDefaultAsync();
            if (result == null)
            {
                toReturn = false;
            }
            else
            {
                if (result.Username == userName)
                {
                    toReturn = true;
                }
                else
                {
                    toReturn = false;
                }
            }
            return toReturn;
        }

        public async Task AddNewAccountAsync(string userName, string password)
        {
            this.BankContext.BankAccounts.Add(new BankAccounts { Username = userName, Password = password });
            await this.BankContext.SaveChangesAsync();
        }

        public async Task<BankAccounts> GetAccountAsync(string userName, string password)
        {
            return await (from user in this.BankContext.BankAccounts
                    where user.Username == userName && user.Password == password
                    select user).SingleOrDefaultAsync();
        }

    }
}