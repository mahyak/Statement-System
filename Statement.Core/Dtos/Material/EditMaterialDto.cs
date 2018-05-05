using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Statement.Core.Dtos.Material
{
    public class EditMaterialDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Material Name")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; }
    }
}
