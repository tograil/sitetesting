using Core.Domain.Profiles;
using Microsoft.AspNet.Identity;

namespace Core.Identity
{
    public class MainRoleManager : RoleManager<UserRole>
    {
        public MainRoleManager(MainRoleStore store) : base(store)
        {

        }
    }
}
