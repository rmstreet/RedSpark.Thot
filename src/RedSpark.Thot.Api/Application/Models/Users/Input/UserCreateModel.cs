using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Application.Models.Users.Input
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "EMAIL_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD_IS_REQUIRED")]
        [StringLength(100, ErrorMessage = "PASSOWRD_LENGTH_INVALID")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "CONFIRMPASSWORD_NOT_EQUALS")]
        public string ConfirmPassword { get; set; }
    }
}
