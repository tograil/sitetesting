using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.EF.Context;
using Core.Data.EF.Store;
using Core.Identity;
using Microsoft.Owin;

namespace Core.Data.EF.Identity
{
    public class IdentityFactory
    {
        public static MainUserManager CreateUserManager(MainDataContext context)
        {
            return new MainUserManager(new MainStore(new UnitOfWork(context)));
        }

        public static MainRoleManager CreateRoleManager(MainDataContext context)
        {
            return new MainRoleManager(new MainRoleStore(new UnitOfWork(context)));
        }

        public static MainSignInManager CreateSignInMager(MainUserManager userManager, IOwinContext owinContext)
        {
            return new MainSignInManager(userManager, owinContext.Authentication);
        }
    }
}
