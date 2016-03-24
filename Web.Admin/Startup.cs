using System;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Core.Data.EF.Context;
using Core.Data.EF.Identity;
using IoC;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Web.Admin.Providers;
using Web.Admin.StartupModules;

[assembly: OwinStartup(typeof(Web.Admin.Startup))]

namespace Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            RegisterSwagger(config);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            ConfigureAutofac(app, config);
            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            
        }

        public void ConfigureAutofac(IAppBuilder app, HttpConfiguration config)
		{
			var diFilePath = HostingEnvironment.MapPath("~/App_Data/dependencies.xml");
			var factory = new DependecyResoloverFactory(diFilePath);

			factory.RegisterModules(new IdentityModule());
			factory.ContainerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerLifetimeScope();

			DependencyResolver.ConfigureResolver(factory);
			app.CreatePerOwinContext(() => IdentityFactory.CreateUserManager(DependencyResolver.Get<MainDataContext>()));

			config.DependencyResolver = DependencyResolver.Resolver;

			app.UseAutofacMiddleware(DependencyResolver.AutofacContainer);
			app.UseAutofacWebApi(config);
		}

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(IdentityFactory.CreateUserManager(DependencyResolver.Get<MainDataContext>()))
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}
