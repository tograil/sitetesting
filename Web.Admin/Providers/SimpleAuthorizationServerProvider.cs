using System.Security.Claims;
using System.Threading.Tasks;
using Core.Identity;
using Microsoft.Owin.Security.OAuth;

namespace Web.Admin.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly MainUserManager _repository;

        public SimpleAuthorizationServerProvider(MainUserManager repository)
        {
            _repository = repository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            return Task.Factory.StartNew(context.Validated);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            
                var user = await _repository.FindAsync(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", user.UserRole.Name));

            context.Validated(identity);

        }
    }
}