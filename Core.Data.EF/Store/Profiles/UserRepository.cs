using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Data.EF.Context;
using Core.Domain.Profiles;
using Core.DomainUnits;
using Core.Store.Profiles;
using Core.Utils;

namespace Core.Data.EF.Store.Profiles
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainDataContext context) : base(context)
        {
        }

        public void AddCustomer(User user)
        {
            user.UserRoleId = Context.Set<UserRole>().Single(role => role.UserType == RolesUnits.UserType.Customer).Id;

            AddOrUpdate(user);
        }

        public void AddAdmin(User user)
        {
            user.UserRoleId = Context.Set<UserRole>().Single(role => role.UserType == RolesUnits.UserType.Admin).Id;

            AddOrUpdate(user);
        }

        public User GetByName(string name)
        {
            return
                Context.Users.Include(u => u.UserRole)
                    .SingleOrDefault(u => u.Name.Equals(name))?
                    .Perform(
                        u =>
                            u.UserRole.Permissions =
                                Context.UserPermissions.Where(permission => permission.UserRole.Id == u.UserRoleId));
        }

        public User GetByEmail(string email)
        {
            return
                Context.Users.Include(u => u.UserRole)
                    .SingleOrDefault(u => u.Email.Equals(email))?
                    .Perform(
                        u =>
                            u.UserRole.Permissions =
                                Context.UserPermissions.Where(permission => permission.UserRole.Id == u.UserRoleId));
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return GetUsersByType(RolesUnits.UserType.Customer);
        }

        public IEnumerable<User> GetAllAdmins()
        {
            return GetUsersByType(RolesUnits.UserType.Admin);
        }

        private IEnumerable<User> GetUsersByType(RolesUnits.UserType userType)
        {
            var permissions =
                Context.UserPermissions.Include(p => p.UserRole)
                    .Where(p => p.UserRole.UserType == userType);

            return Context.Users.Include(u => u.UserRole)
                .Where(u => u.UserRole.UserType == userType)
                .ToArray()
                .Perform(p => p.DoWithEach(usr => usr.UserRole.Permissions = permissions));
        }
    }
}
