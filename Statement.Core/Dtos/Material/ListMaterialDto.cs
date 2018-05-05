using System.Web.Mvc;

namespace Statement.Core.Dtos.Material
{
    public class ListMaterialDto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
