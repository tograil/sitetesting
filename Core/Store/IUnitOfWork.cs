using System;
using Core.Store.Profiles;

namespace Core.Store
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }

        int Commit();
    }
}
