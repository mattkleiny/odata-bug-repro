using System.Linq;
using System.Threading;
using Microsoft.AspNet.OData;
using ODataBug.Web.Models;

namespace ODataBug.Web.Controllers
{
    public class ContactController : ODataController
    {
        private static readonly Contact[] Contacts =
        {
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
            Contact.Generate(),
        };

        [EnableQuery]
        public IQueryable<Contact> Get()
        {
            Thread.Sleep(50); // roughly simulate a database call of some sort

            return Contacts.AsQueryable();
        }
    }
}