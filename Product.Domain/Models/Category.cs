using System;
using System.Collections.Generic;

namespace ProductNS.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
