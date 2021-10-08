using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNS.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastEdit { get; set; }
    }
}
