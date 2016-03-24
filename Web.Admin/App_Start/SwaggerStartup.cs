using System;
using System.Linq;
using System.Web.Http;
using Swashbuckle.Application;


namespace Web.Admin
{
    public partial class Startup
    {
        public void RegisterSwagger(HttpConfiguration config)
        {
            config.EnableSwagger(sw =>
            {
                sw.SingleApiVersion("v1", "Testing");
                sw.ResolveConflictingActions(api => api.First());

                sw.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\Web.Admin.xml");
            }).EnableSwaggerUi();//.EnableSwaggerUi(sw => sw.InjectJavaScript(typeof(Startup).Assembly, "Infrastructure.Swagger.swaggerAuthorization.js"));
        }
    }
}