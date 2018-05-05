using Statement.Core.DomainModels;
using System.Collections.Generic;

namespace Statement.Data.Services
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> Materials { get; }
        void CreateMaterial(Material Material);
        void EditMaterial(Material Material);
        Material DeleteMaterial(int id);
    }
}
