using Statement.Core.DomainModels;
using System.Collections.Generic;

namespace Statement.Data.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void CreateUser(User user);
        void EditUser(User user);
        User DeleteUser(int id);
    }
}

