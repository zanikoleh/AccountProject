using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public partial class BankAccounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankAccounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        [Key]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(35)]
        public string Password { get; set; }

        public decimal AccountBalance { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
