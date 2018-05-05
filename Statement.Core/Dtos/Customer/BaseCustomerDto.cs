using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statement.Core.Dtos.Customer
{
    public class BaseCustomerDto
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "{0} is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "{0} is required.")]
        public string LastName { get; set; }

        [Display(Name = "Mobile")]
        [RegularExpression("^09[0-9]{9}$", ErrorMessage = "{0} format is not valid ...")]
        public string CellPhone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter {0} ..."), MaxLength(255), Index("EmailIndex", IsUnique = true)]
        [EmailAddress(ErrorMessage = "{0} format is not valid ...")]
        public string Email { get; set; }
    }
}
