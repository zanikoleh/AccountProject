using AccountProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Core.Services
{
    public interface IBankAccountService
    {
        IResultModel DepositMoney(string username, decimal value);
        IResultModel GetBalance(string userName);
        IResultModel WithdrawMoney(string userName, decimal value);
        IResultModel TransferMoney(string currentUserName, string targetUserName, decimal value);
    }
}
