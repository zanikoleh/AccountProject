using System.Linq;

namespace DataAccess.Repositories.impl
{
    public class UserAccountRepository: RepositoryBase, IUserAccountRepository
    {
        public void AddNewAccount(string userName, string password)
        {
            this.BankContext.BankAccounts.Add(new BankAccounts { Username = userName, Password = password });
            this.BankContext.SaveChanges();
        }

        public BankAccounts GetAccount(string userName, string password)
        {
            return (from user in this.BankContext.BankAccounts
                    where user.Username == userName && user.Password == password
                    select user).FirstOrDefault();
        }

    }
}