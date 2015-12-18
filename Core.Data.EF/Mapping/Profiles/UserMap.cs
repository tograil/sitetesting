using System.Data.Entity.ModelConfiguration;
using Core.Domain.Profiles;

namespace Core.Data.EF.Mapping.Profiles
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.Name).HasMaxLength(45).IsRequired();
            Property(t => t.Email).HasMaxLength(60).IsRequired();

            Property(t => t.UserRoleId).IsRequired();
            
            Ignore(t => t.UserName);

            HasRequired(t => t.UserRole).WithMany().HasForeignKey(t => t.UserRoleId).WillCascadeOnDelete(true);
        }
    }
}
