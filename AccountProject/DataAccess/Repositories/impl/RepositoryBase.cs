using DataAccess.Repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace DataAccess
{
    class RepositoryBase: IRepositoryBase
    {
        private BankContext _bankContext = new BankContext();

        public BankContext BankContext
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
