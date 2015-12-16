namespace DataAccess.Repositories.impl
{
    public class RepositoryBase
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
