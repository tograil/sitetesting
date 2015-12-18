using System;
using System.Data.Entity;
using System.Linq;
using Core.Data.EF.Context;
using Core.Domain.Profiles;
using Core.DomainUnits;
using Core.Store.Profiles;
using Core.Utils;

namespace Core.Data.EF.Store.Profiles
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(MainDataContext context) : base(context)
        {
        }

        public UserRole GetByName(string name)
        {
            var type = (RolesUnits.UserType)Enum.Parse(typeof(RolesUnits.UserType), name);

            var permissions = Context.UserPermissions.Include(t => t.UserRole).Where(t => t.UserRole.UserType == type);

            return Context.UserRoles.Single(ur => ur.UserType == type).Perform(ur => ur.Permissions = permissions);
        }
    }
}
