using System.ComponentModel.DataAnnotations;

namespace WebAPICoreTask1.DTOS
{
    public class UserRequestDTO
    {



        [Required(ErrorMessage = "Plz enter a username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Plz enter a password")]

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 20 characters")]
        public string? Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Plz enter a correct Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }




    }
}
