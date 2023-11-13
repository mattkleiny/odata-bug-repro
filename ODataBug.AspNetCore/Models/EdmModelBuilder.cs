using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBug.Web.Models;

namespace ODataBug.AspNetCore.Models
{
    public class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Contact>("Contact")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Contact.BusinessCards));

            builder.EntitySet<Organization>("Organization")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Organization.Contacts));

            return builder.GetEdmModel();
        }
    }
}
