using Statement.Core.DomainModels;
using Statement.Data.Services;
using System.Collections.Generic;

namespace Statement.Data.EFRepositories
{
    public class EFFactorRepository : IFactorRepository
    {
        private StatementDbContext context = new StatementDbContext();

        public IEnumerable<Factor> Factors
        {
            get { return context.Factors; }
        }

        public void CreateFactor(Factor factor)
        {
            context.Factors.Add(factor);
            context.SaveChanges();
        }

        public void EditFactor(Factor factor)
        {
            Factor dbEntry = context.Factors.Find(factor.Id);
            if (dbEntry != null)
            {
                dbEntry.Id = factor.Id;
                dbEntry.Price = factor.Price;
                dbEntry.Date = factor.Date;
                dbEntry.CustomerId = factor.CustomerId;
            }
            context.SaveChanges();
        }

        public Factor DeleteFactor(int Id)
        {
            Factor dbEntery = context.Factors.Find(Id);
            if (dbEntery != null)
            {
                context.Factors.Remove(dbEntery);
                context.SaveChanges();
            }
            return dbEntery;
        }
    }
}

