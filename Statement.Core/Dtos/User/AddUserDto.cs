using Statement.Core.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statement.Core.Dtos.User
{
    public class AddUserDto : BaseUserDto
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter {0} ..."), MaxLength(255), Index("UsernameIndex", IsUnique = true)]
        public string Username { set; get; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0} ...")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Please enter at least 6 characters ...")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please Enter {0} ...")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password are not match")]
        public string ConfirmedPassword { set; get; }

        public Role Role { get; set; }
    }
}
