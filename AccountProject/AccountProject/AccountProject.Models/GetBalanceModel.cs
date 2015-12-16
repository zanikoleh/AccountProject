using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models
{
    public class GetBalanceModel: IResultModel
    {
        public string Username { get; set; }
        public decimal Amount { get; set; }
    }
}
