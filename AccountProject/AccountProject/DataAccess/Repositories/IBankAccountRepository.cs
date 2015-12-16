using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IBankAccountRepository
    {
        decimal GetBalance(string userName);
        void DepositMoney(string username, decimal value);
        void WithdrawMoney(string userName, decimal value);
        void TransferMoney(string currentUserName, string TargetUserName, decimal value);
    }
}
