using System.Data.Entity.ModelConfiguration;
using Core.Domain.Profiles;

namespace Core.Data.EF.Mapping.Profiles
{
    public class UserPermissionMap : EntityTypeConfiguration<UserPermission>
    {
        public UserPermissionMap()
        {
            ToTable("UserPermissions");

            HasKey(t => t.Id);
            Property(t => t.Permission).IsRequired();

            Property(t => t.UserRoleId).IsRequired();
            HasRequired(t => t.UserRole).WithMany().HasForeignKey(t => t.UserRoleId).WillCascadeOnDelete(true);
        }
    }
}
