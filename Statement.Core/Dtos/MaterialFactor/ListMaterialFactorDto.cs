using Statement.Core.Dtos.Factor;
using Statement.Core.Dtos.Material;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Statement.Core.Dtos.MaterialFactor
{
    public class ListMaterialFactorDto
    {
        public IEnumerable<ListMaterialDto> MaterialDto { get; set; }

        public IEnumerable<ListMaterialDto> MaterialExistDto { get; set; }

        public ListFactorDto FactorDto { get; set; }

        public string ListMaterialExistDtoId { get; set; }
    }
}
