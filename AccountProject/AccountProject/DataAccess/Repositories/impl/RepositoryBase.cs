using System;

namespace DataAccess.Repositories.impl
{
    public class RepositoryBase: IDisposable
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

        public void Dispose()
        {
            _bankContext.Dispose();
        }
    }
}
