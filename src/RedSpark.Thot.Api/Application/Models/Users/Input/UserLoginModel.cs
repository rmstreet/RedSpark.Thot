using System.ComponentModel.DataAnnotations;

namespace RedSpark.Thot.Api.Application.Models.Users.Input
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "EMAIL_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD_IS_REQUIRED")]
        [StringLength(100, ErrorMessage = "PASSOWRD_LENGTH_INVALID")]
        public string Password { get; set; }
    }
}
