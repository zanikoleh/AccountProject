using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public partial class Transactions
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        public decimal Amount { get; set; }

        public virtual BankAccounts BankAccounts { get; set; }
    }
}
