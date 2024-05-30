namespace webapi.Model;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("LoginTable")]
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@])[A-Za-z\d@]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter, one digit, and one '@' symbol")]
        public string? Password { get; set; }
    }
