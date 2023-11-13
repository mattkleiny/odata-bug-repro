using System.Web;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using ODataBug.Web.Models;

namespace ODataBug.Web
{
    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(ConfigureRoutes);
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            config.Expand(QueryOptionSetting.Disabled);
            config.MaxTop(null);

            builder.EntitySet<Contact>("Contact")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Contact.BusinessCards));
            
            builder.EntitySet<Organization>("Organization")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Organization.Contacts));

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "v3",
                model: builder.GetEdmModel()
            );
        }
    }
}