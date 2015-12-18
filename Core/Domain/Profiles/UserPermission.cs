using Core.DomainUnits;

namespace Core.Domain.Profiles
{
    public class UserPermission
    {
        public int Id { get; set; }

        public RolesUnits.Permission Permission { get; set; }

        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}
