using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using Core.Data.EF.Context;

namespace Web.Admin.StartupModules
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(b => b.Resolve<DbContext>() as MainDataContext).InstancePerLifetimeScope();

        }
    }
}