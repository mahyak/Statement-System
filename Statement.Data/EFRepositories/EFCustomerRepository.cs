using Statement.Core.DomainModels;
using Statement.Data.Services;
using System.Collections.Generic;

namespace Statement.Data.EFRepositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private StatementDbContext context = new StatementDbContext();

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            Customer dbEntry = context.Customers.Find(customer.Id);
            if (dbEntry != null)
            {
                dbEntry.FirstName = customer.FirstName;
                dbEntry.LastName = customer.LastName;
                dbEntry.Email = customer.Email;
                dbEntry.CellPhone = customer.CellPhone;
                dbEntry.Id = customer.Id;
                dbEntry.UserId = customer.UserId;
            }

            context.SaveChanges();
        }

        public Customer DeleteCustomer(int Id)
        {
            Customer dbEntery = context.Customers.Find(Id);
            if (dbEntery != null)
            {
                context.Customers.Remove(dbEntery);
                context.SaveChanges();
            }
            return dbEntery;
        }
    }
}

