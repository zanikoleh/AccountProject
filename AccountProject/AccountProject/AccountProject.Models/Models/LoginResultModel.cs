using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models.Models
{
    public class LoginResultModel: IResultModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
