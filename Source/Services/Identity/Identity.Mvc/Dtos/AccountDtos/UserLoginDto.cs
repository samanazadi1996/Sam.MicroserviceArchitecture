using System.ComponentModel.DataAnnotations;

namespace Identity.Mvc.Dtos.AccountDtos
{
    public class UserLoginDto
    {
        [Required]
        [Display]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Display]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
