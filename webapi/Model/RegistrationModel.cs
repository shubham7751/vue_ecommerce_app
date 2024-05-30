namespace webapi.Model;
using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {
        [Key]
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@])[A-Za-z\d@]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter, one digit, and one '@' symbol")]
        public string? Password { get; set; }
    
}
