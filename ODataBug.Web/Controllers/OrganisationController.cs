using System.Linq;
using System.Threading;
using Microsoft.AspNet.OData;
using ODataBug.Web.Models;

namespace ODataBug.Web.Controllers
{
    public class OrganisationController : ODataController
    {
        private static readonly Organisation[] Organisations =
        {
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
            Organisation.Generate(),
        };

        [EnableQuery]
        public IQueryable<Organisation> Get()
        {
            Thread.Sleep(100); // roughly simulate a database call of some sort

            return Organisations.AsQueryable();
        }
    }
}