using System;
using System.Threading.Tasks;
using Core.Domain.Profiles;
using Core.Store;
using Microsoft.AspNet.Identity;

namespace Core.Identity
{
    public class MainRoleStore : IRoleStore<UserRole>
    {
        private readonly IUnitOfWork _repository;

        public MainRoleStore(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public Task CreateAsync(UserRole role)
        {
            throw new ArgumentException("Roles is fixed");
        }

        public Task DeleteAsync(UserRole role)
        {
            throw new ArgumentException("Roles is fixed");
        }

        public void Dispose()
        {
            
        }

        public Task<UserRole> FindByIdAsync(string roleId)
        {
            int id;

            return Task.Factory.StartNew(() => int.TryParse(roleId, out id) ? _repository.UserRoles.Get(id) : null);
        }

        public Task<UserRole> FindByNameAsync(string roleName)
        {
            return Task.Factory.StartNew(() => _repository.UserRoles.GetByName(roleName));
        }

        public Task UpdateAsync(UserRole role)
        {
            throw new ArgumentException("Roles is fixed");
        }
    }
}
