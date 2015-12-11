using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccounts ac = new BankAccounts { Username = "Nazar", Password = "321" };
            RepositoryBase bank = new RepositoryBase();
            //bank.AddNewAccount(ac);
            //bank.UpdateAccountBalance("Nazar", -40);
        }
    }
}
