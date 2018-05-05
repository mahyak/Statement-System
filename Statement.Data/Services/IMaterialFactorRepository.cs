using Statement.Core.DomainModels;
using System.Collections.Generic;

namespace Statement.Data.Services
{
    public interface IMaterialFactorRepository
    {
        IEnumerable<MaterialFactor> MaterialFactors { get; }
        void CreateMaterialFactor(MaterialFactor materialFactor);
    }
}

