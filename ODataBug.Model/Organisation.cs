using System;
using System.ComponentModel.DataAnnotations;

namespace ODataBug.Models
{
    public class Organisation
    {
        [Key]
        public string PermaKey { get; set; }

        public string Name { get; set; }

        public Contact[] Contacts { get; set; }

        public static Organisation Generate()
        {
            return new Organisation
            {
                PermaKey = Guid.NewGuid().ToString(),
                Name = "Test Organisation",
                Contacts = new[]
                {
                    Contact.Generate(),
                    Contact.Generate()
                }
            };
        }
    }
}