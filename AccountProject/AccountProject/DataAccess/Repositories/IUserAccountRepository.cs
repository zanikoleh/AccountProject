using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserAccountRepository
    {
        BankAccounts GetAccount(string userName, string password);
        void AddNewAccount(string userName, string password);
    }
}
