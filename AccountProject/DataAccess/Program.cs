using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.impl;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BankAccountContext ctx = new BankAccountContext())
            {
                //ctx.BankAccounts.Add(new BankAccounts { Username = "Oleh", Password = "123", AccountBalance = 50 });
                //ctx.BankAccounts.Add(new BankAccounts { Username = "Nazar", Password = "321", AccountBalance = 10 });
            }
        }
    }
}