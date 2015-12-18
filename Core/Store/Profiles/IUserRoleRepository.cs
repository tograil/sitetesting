using Core.Domain.Profiles;

namespace Core.Store.Profiles
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        UserRole GetByName(string name);
    }
}
