namespace Statement.Core.DomainModels
{
    public class MaterialFactor : BaseEntity
    {
        public int FactorId { get; set; }
        public virtual Factor Factors { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Materials { get; set; }
    }
}
