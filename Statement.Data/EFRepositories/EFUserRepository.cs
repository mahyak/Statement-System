using Statement.Core.DomainModels;
using Statement.Data.Services;
using System.Collections.Generic;

namespace Statement.Data.EFRepositories
{
    public class EFUserRepository : IUserRepository
    {
        private StatementDbContext context = new StatementDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void EditUser(User user)
        {
            User dbEntry = context.Users.Find(user.Id);
            if (dbEntry != null)
            {
                dbEntry.FirstName = user.FirstName;
                dbEntry.LastName = user.LastName;
                dbEntry.Id = user.Id;
                dbEntry.UserName = user.UserName;
                dbEntry.LastName = user.LastName;
            }
            context.SaveChanges();
        }

        public User DeleteUser(int Id)
        {
            User dbEntery = context.Users.Find(Id);
            if (dbEntery != null)
            {
                context.Users.Remove(dbEntery);
                context.SaveChanges();
            }
            return dbEntery;
        }
    }
}

