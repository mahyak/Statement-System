using Statement.Core.DomainModels;
using Statement.Data.Services;
using System.Collections.Generic;

namespace Statement.Data.EFRepositories
{
    public class EFMaterialRepository : IMaterialRepository
    {
        private StatementDbContext context = new StatementDbContext();

        public IEnumerable<Material> Materials
        {
            get { return context.Materials; }
        }

        public void CreateMaterial(Material material)
        {
            context.Materials.Add(material);
            context.SaveChanges();
        }

        public void EditMaterial(Material material)
        {
            Material dbEntry = context.Materials.Find(material.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = material.Id;
                dbEntry.Name = material.Name;
            }
            context.SaveChanges();
        }

        public Material DeleteMaterial(int Id)
        {
            Material dbEntery = context.Materials.Find(Id);
            if (dbEntery != null)
            {
                context.Materials.Remove(dbEntery);
                context.SaveChanges();
            }
            return dbEntery;
        }
    }
}

