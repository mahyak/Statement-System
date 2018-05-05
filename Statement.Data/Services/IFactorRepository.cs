using Statement.Core.DomainModels;
using System.Collections.Generic;

namespace Statement.Data.Services
{
    public interface IFactorRepository
    {
        IEnumerable<Factor> Factors { get; }
        void CreateFactor(Factor factor);
        void EditFactor(Factor factor);
        Factor DeleteFactor(int id);
    }
}
