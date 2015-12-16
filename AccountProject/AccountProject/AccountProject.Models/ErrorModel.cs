using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Models
{
    public class ErrorModel<T>: IResultModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
    }
}
