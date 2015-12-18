using System.Data.Entity.Migrations;
using Core.Data.EF.Context;
using Core.Domain.Profiles;
using Core.DomainUnits;
using Core.Identity;

namespace Core.Data.EF.Migrations
{
    public class Configuration : DbMigrationsConfiguration<MainDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MainDataContext context)
        {
            context.UserRoles.AddRange(
                new []
                {
                    new UserRole
                    {
                        Id = 1,
                        UserType = RolesUnits.UserType.Admin
                   },
                    new UserRole
                    {
                        Id = 2,
                        UserType = RolesUnits.UserType.Customer
                    }
                });

            context.UserPermissions.AddRange(
                new[]
            {
                new UserPermission
                {
                    Id = 1,
                    UserRoleId = 1,
                    Permission = RolesUnits.Permission.CreateUser
                },
                new UserPermission
                {
                    Id = 2,
                    UserRoleId = 1,
                    Permission = RolesUnits.Permission.AddEditOrApproveAnyPost
                },
                new UserPermission
                {
                    Id = 3,
                    UserRoleId = 1,
                    Permission = RolesUnits.Permission.AddOrEditOwnPost
                },
                new UserPermission
                {
                    Id = 4,
                    UserRoleId = 1,
                    Permission = RolesUnits.Permission.UpdateAnyProfile
                },
                new UserPermission
                {
                    Id = 5,
                    UserRoleId = 1,
                    Permission = RolesUnits.Permission.UpdateOwnProfile
                },
                new UserPermission
                {
                    Id = 6,
                    UserRoleId = 2,
                    Permission = RolesUnits.Permission.AddOrEditOwnPost
                },
                new UserPermission
                {
                    Id = 7,
                    UserRoleId = 2,
                    Permission = RolesUnits.Permission.UpdateAnyProfile
                }
            });

            context.Users.AddOrUpdate(new User
            {
                Id = 1,
                Name = "Admin",
                UserRoleId = 1,
                Email = "admin@admin.net",
                Password = new MainPasswordHasher().HashPassword("Admin")
            });
        }
    }
}
