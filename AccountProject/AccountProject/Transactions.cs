namespace AccountProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        public decimal Amount { get; set; }

        public virtual BankAccounts BankAccounts { get; set; }
    }
}
