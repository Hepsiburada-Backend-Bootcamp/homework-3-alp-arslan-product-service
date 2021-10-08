using System.Collections.Generic;

namespace ProductNS.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}