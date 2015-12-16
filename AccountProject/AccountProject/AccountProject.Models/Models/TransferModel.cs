using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models.Models
{
    public class TransferModel
    {
        public string CurrentUserName { get; set; }
        public string TargetUserName { get; set; }
        public decimal Amount { get; set; }
    }
}
