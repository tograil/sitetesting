using System.ComponentModel.DataAnnotations;

namespace Web.Admin.Models.Request
{
    public class RegistrationRequestModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}