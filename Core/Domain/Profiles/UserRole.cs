using System;
using System.Collections.Generic;
using Core.DomainUnits;
using Microsoft.AspNet.Identity;

namespace Core.Domain.Profiles
{
    public class UserRole : IRole<int>, IRole<string>
    {
        public int Id { get; set; }

        string IRole<string>.Id => Id.ToString();

        public string Name
        {
            get { return UserType.ToString(); }
            set
            {
                RolesUnits.UserType type;

                if (Enum.TryParse(value, out type))
                    UserType = type;
                
            }
        }

        public RolesUnits.UserType UserType { get; set; }

        public IEnumerable<UserPermission> Permissions { get; set; }

        public IEnumerable<User> UsersWithRole { get; set; }
    }
}
