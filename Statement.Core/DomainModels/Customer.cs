using System.Collections.Generic;

namespace Statement.Core.DomainModels
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Factor> Factor { get; set; }
    }
}
