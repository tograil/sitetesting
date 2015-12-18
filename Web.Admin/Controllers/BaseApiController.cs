using System.Net.Http;
using System.Web;
using System.Web.Http;
using Core.Domain.Profiles;
using Core.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Web.Admin.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private User _currentUser;

        public int UserId => int.Parse(User.Identity.GetUserId());

        public User CurrentUser
        {
            get
            {
                if (_currentUser != null || !HttpContext.Current.User.Identity.IsAuthenticated) return _currentUser;

                var userManager = HttpContext.Current.GetOwinContext().GetUserManager<MainUserManager>();

                if (User.Identity.IsAuthenticated)
                {
                    _currentUser = userManager.FindByName(User.Identity.GetUserName());
                }

                return _currentUser;
            }
        }

        public MainUserManager UserManager => Request.GetOwinContext().GetUserManager<MainUserManager>();
    }
}
