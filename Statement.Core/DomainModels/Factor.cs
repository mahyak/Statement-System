using System;
using System.Collections.Generic;

namespace Statement.Core.DomainModels
{
    public class Factor : BaseEntity
    {
        public int CustomerId { get; set; }

        public string Price { get; set; }

        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
