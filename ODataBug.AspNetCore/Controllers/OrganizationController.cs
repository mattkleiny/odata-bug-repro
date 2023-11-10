using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBug.Web.Models;

namespace ODataBug.Web.Controllers
{
    public class OrganizationController : ODataController
    {
        private static readonly Organization[] Organizations =
        {
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
            Organization.Generate(),
        };

        [EnableQuery]
        public IQueryable<Organization> Get()
        {
            Thread.Sleep(100); // roughly simulate a database call of some sort

            return Organizations.AsQueryable();
        }
    }
}