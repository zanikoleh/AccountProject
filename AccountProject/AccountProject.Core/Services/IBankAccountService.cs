using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Core.Services
{
    public interface IBankAccountService
    {
        void DepositMoney(string username, decimal value);
        decimal GetBalance(string userName);
        void WithdrawMoney(string userName, decimal value);
        void TransferMoney(string currentUserName, string targetUserName, decimal value);
    }
}
