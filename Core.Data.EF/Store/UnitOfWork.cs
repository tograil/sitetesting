using Core.Data.EF.Context;
using Core.Data.EF.Store.Profiles;
using Core.Store;
using Core.Store.Profiles;

namespace Core.Data.EF.Store
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDataContext _context;

        public UnitOfWork(MainDataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            UserRoles = new UserRoleRepository(_context);
        }

        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public static UnitOfWork Create()
        {
            return new UnitOfWork(new MainDataContext());
        }
    }
}
