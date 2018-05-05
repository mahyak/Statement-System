using Statement.Core.DomainModels;
using Statement.Data.Services;
using System.Collections.Generic;

namespace Statement.Data.EFRepositories
{
    public class EFMaterialFactorRepository : IMaterialFactorRepository
    {
        private StatementDbContext context = new StatementDbContext();

        public IEnumerable<MaterialFactor> MaterialFactors
        {
            get { return context.MaterialFactors; }
        }

        public void CreateMaterialFactor(MaterialFactor materialFactor)
        {
            context.MaterialFactors.Add(materialFactor);
            context.SaveChanges();
        }
    }
}

