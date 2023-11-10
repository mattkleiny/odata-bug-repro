using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.ComponentModel.DataAnnotations;

namespace ODataBug.Models
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Contact>("Contact")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Contact.BusinessCards));

            builder.EntitySet<Organisation>("Organisation")
                .EntityType
                .Expand(maxDepth: 2, SelectExpandType.Allowed, properties: nameof(Organisation.Contacts));

            return builder.GetEdmModel();
        }
    }
}