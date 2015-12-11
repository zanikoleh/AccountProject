using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.impl
{
    public interface IRepositoryBase
    {
        BankContext BankContext { get; set; }
    }
}
