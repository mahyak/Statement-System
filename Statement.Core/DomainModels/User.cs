using Statement.Core.DomainModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Statement.Core.DomainModels
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
