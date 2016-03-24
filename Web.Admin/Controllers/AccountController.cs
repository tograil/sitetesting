using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Core.Domain.Profiles;
using Core.DomainUnits;
using Core.Identity;
using Core.Store;
using Microsoft.AspNet.Identity.Owin;
using Web.Admin.Models.Request;

namespace Web.Admin.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/accounts")]
    [Route("{action}")]
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private MainSignInManager SignInManager => Request.GetOwinContext().Get<MainSignInManager>();
        private readonly IUnitOfWork _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AccountController(IUnitOfWork repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Gets all admins.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllAdmins()
        {
            var users = await Task.Run(() => _repository.Users.GetAllAdmins());

            return users;
        }

    }
}
