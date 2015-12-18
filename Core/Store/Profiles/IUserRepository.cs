using System.Collections.Generic;
using Core.Domain.Profiles;

namespace Core.Store.Profiles
{
    public interface IUserRepository : IRepository<User>
    {
        void AddCustomer(User user);
        void AddAdmin(User user);

        User GetByName(string name);
        User GetByEmail(string email);

        IEnumerable<User> GetAllCustomers();
        IEnumerable<User> GetAllAdmins();
    }
}
