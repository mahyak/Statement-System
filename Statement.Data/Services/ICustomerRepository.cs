using Statement.Core.DomainModels;
using System.Collections.Generic;

namespace Statement.Data.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void CreateCustomer(Customer Customer);
        void EditCustomer(Customer Customer);
        Customer DeleteCustomer(int id);
    }
}
