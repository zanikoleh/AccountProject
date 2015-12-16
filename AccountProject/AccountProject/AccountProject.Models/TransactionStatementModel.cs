using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models
{
    public class TransactionStatementModel: IResultModel
    {
        public string Username { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
