using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Profiles;

namespace Core.Data.EF.Mapping.Profiles
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRoles");

            HasKey(t => t.Id);
            Property(t => t.UserType).IsRequired();
            
        }
    }
}
