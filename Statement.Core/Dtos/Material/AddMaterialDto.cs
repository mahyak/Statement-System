using System.ComponentModel.DataAnnotations;

namespace Statement.Core.Dtos.Material
{
    public class AddMaterialDto
    {
        [Display(Name = "Material Name")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; }
    }
}
