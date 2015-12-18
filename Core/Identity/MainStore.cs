using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Profiles;
using Core.DomainUnits;
using Core.Store;
using Core.Utils;
using Microsoft.AspNet.Identity;

namespace Core.Identity
{
    public class MainStore : IUserStore<User>, IUserLockoutStore<User, string>, IUserPasswordStore<User>
    {
        private readonly IUnitOfWork _repository;

        public MainStore(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            
        }

        public Task CreateAsync(User user)
        {
            if (user.UserRole == null || user.UserRole.UserType == RolesUnits.UserType.Customer)
            {
                _repository.Users.AddCustomer(user);
            }
            else
            {
                _repository.Users.AddAdmin(user);
            }

            return Task.Factory.StartNew(() => _repository.Commit());
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return Task.Factory.StartNew(() => _repository.Users.Get(userId));
        }

        public Task<User> FindByIdAsync(string userId)
        {
            int id;

            return int.TryParse(userId, out id) ? FindByIdAsync(id) : null;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Factory.StartNew(() => Validation.OfEmail(userName) 
            ? _repository.Users.GetByEmail(userName) 
            :  _repository.Users.GetByName(userName));
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.Factory.StartNew(() => false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return null;
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return null;
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return null;
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return null;
        }

        public Task UpdateAsync(User user)
        {
            return CreateAsync(user);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Factory.StartNew(() => user.Password = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.Factory.StartNew(() => user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.Factory.StartNew(() => true);
        }
    }
}
