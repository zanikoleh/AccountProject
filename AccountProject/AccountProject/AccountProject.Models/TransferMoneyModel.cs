using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models
{
    public class TransferMoneyModel: IResultModel
    { 
        public string Username { get; set; }
        public string Target { get; set; }
        public decimal Amount { get; set; }
    }
}
