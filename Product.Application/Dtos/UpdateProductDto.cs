using System.ComponentModel.DataAnnotations;

namespace ProductNS.Application.Dtos
{
    public class UpdateProductDto
    {
        //TODO: Maybe remove this and have only 2 dtos as request and response
        [Required]
        public int Id { get; set; }
        [Required, StringLength(56, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required, Range(1, 50000)]
        public double Price { get; set; }
    }
}
