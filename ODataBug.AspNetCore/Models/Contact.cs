using System;
using System.ComponentModel.DataAnnotations;

namespace ODataBug.Web.Models
{
    public class Contact
    {
        [Key]
        public string PermaKey { get; set; }

        public string Name { get; set; }
        
        public BusinessCard[] BusinessCards { get; set; }

        public static Contact Generate()
        {
            return new Contact
            {
                PermaKey = Guid.NewGuid().ToString(),
                Name = "Test Contact",
                BusinessCards = new[]
                {
                    BusinessCard.Generate(),
                    BusinessCard.Generate()
                }
            };
        }
    }

    public sealed class BusinessCard
    {
        [Key]
        public string PermaKey { get; set; }

        public string Name { get; set; }

        public static BusinessCard Generate()
        {
            return new BusinessCard
            {
                PermaKey = Guid.NewGuid().ToString(),
                Name = "Test Business Card"
            };
        }
    }
}