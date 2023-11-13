using System;
using System.ComponentModel.DataAnnotations;

namespace ODataBug.Web.Models
{
    public class Organization
    {
        [Key]
        public string PermaKey { get; set; }

        public string Name { get; set; }

        public Contact[] Contacts { get; set; }

        public static Organization Generate()
        {
            return new Organization
            {
                PermaKey = Guid.NewGuid().ToString(),
                Name = "Test Organization",
                Contacts = new[]
                {
                    Contact.Generate(),
                    Contact.Generate()
                }
            };
        }
    }
}