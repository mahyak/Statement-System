using System.ComponentModel.DataAnnotations;

namespace Statement.Core.Dtos.User
{
    public class BaseUserDto
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "{0} is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "{0} is required.")]
        public string LastName { get; set; }

    }
}
