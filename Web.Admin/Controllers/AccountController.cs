using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Core.Identity;
using Core.Store;
using Microsoft.AspNet.Identity.Owin;
using Web.Admin.Models.Request;

namespace Web.Admin.Controllers
{
    public class AccountController : BaseApiController
    {

        public MainSignInManager SignInManager => Request.GetOwinContext().Get<MainSignInManager>();
        private IUnitOfWork _repository;

        public AccountController(IUnitOfWork repository)
        {
            _repository = repository;
        }



    }
}
