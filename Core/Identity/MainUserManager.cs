using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Profiles;
using Microsoft.AspNet.Identity;

namespace Core.Identity
{
    public class MainUserManager : UserManager<User>
    {
        public MainUserManager(MainStore store) : base(store)
        {

        }
    }
}
