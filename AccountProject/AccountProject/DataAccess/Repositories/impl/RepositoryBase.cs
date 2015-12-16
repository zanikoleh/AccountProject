using DataAccess.Repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace DataAccess.Repositories.impl
{
    public class RepositoryBase: IRepositoryBase
    {
        private BankAccountContext _bankContext = new BankAccountContext();

        public BankAccountContext BankContext
        {
            get
            {
                return this._bankContext;
            }

            set
            {
                this._bankContext = value;
            }
        }
    }
}
