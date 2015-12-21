using System.ComponentModel.DataAnnotations;

namespace AccountProject.Models.Models
{
    public class UserModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "User name length must be greater than 5 characters"), MaxLength(35)]
        public string Username { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Transaction has to be greater or equal 1")]
        public decimal Amount { get; set; }
    }
}
