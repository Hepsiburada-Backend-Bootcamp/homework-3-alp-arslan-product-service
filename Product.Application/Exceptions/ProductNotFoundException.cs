namespace ProductNS.Application.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id)
            : base($"The product with the id: {id} was not found.")
        { 
        }
    }
}
