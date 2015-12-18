using System;
using System.Data.Entity.Utilities;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Profiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Core.Identity
{
    public class MainSignInManager : SignInManager<User, string>
    {
        public MainSignInManager(MainUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {

        }

        private static async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, UserManager<User, string> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return GenerateUserIdentityAsync(user, (MainUserManager)UserManager);
        }

        public MainUserManager FlUserManager => UserManager as MainUserManager;

        public override async Task SignInAsync(
        User user,
        bool isPersistent,
        bool rememberBrowser)
        {
            var userIdentity = await CreateUserIdentityAsync(user).WithCurrentCulture();

            // Clear any partial cookies from external or two factor partial sign ins
            AuthenticationManager.SignOut(
                DefaultAuthenticationTypes.ExternalCookie,
                DefaultAuthenticationTypes.TwoFactorCookie);

            if (rememberBrowser)
            {
                var rememberBrowserIdentity = AuthenticationManager
                    .CreateTwoFactorRememberBrowserIdentity(user.Id.ToString());

                AuthenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    userIdentity,
                    rememberBrowserIdentity);
            }
            else
            {
                AuthenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    userIdentity);
            }
        }

        private async Task<SignInStatus> SignInOrTwoFactor(User user, bool isPersistent)
        {
            var id = Convert.ToString(user.Id);

            if (UserManager.SupportsUserTwoFactor
                && await UserManager.GetTwoFactorEnabledAsync(user.Id.ToString())
                                    .WithCurrentCulture()
                && (await UserManager.GetValidTwoFactorProvidersAsync(user.Id.ToString())
                                     .WithCurrentCulture()).Count > 0
                    && !await AuthenticationManager.TwoFactorBrowserRememberedAsync(id)
                                                   .WithCurrentCulture())
            {
                var identity = new ClaimsIdentity(
                    DefaultAuthenticationTypes.TwoFactorCookie);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));

                AuthenticationManager.SignIn(identity);

                return SignInStatus.RequiresVerification;
            }
            await SignInAsync(user, isPersistent, false).WithCurrentCulture();
            return SignInStatus.Success;
        }

        public override async Task<SignInStatus> PasswordSignInAsync(
            string userName,
            string password,
            bool isPersistent,
            bool shouldLockout)
        {
            if (UserManager == null)
            {
                return SignInStatus.Failure;
            }

            var user = await FlUserManager.FindByNameAsync(userName).WithCurrentCulture();
            if (user == null)
            {
                return SignInStatus.Failure;
            }

            if (UserManager.SupportsUserLockout
                && await FlUserManager.IsLockedOutAsync(user.Id.ToString()).WithCurrentCulture())
            {
                return SignInStatus.LockedOut;
            }

            if (UserManager.SupportsUserPassword
                && await FlUserManager.CheckPasswordAsync(user, password)
                                    .WithCurrentCulture())
            {
                return await SignInOrTwoFactor(user, isPersistent).WithCurrentCulture();
            }
            if (shouldLockout && UserManager.SupportsUserLockout)
            {
                await UserManager.AccessFailedAsync(user.Id.ToString()).WithCurrentCulture();
                if (await UserManager.IsLockedOutAsync(user.Id.ToString()).WithCurrentCulture())
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }
    }
}
