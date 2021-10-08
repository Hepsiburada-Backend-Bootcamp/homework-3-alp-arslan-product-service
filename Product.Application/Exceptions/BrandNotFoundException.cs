namespace ProductNS.Application.Exceptions
{
    public sealed class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(int id)
            : base($"The brand with the id: {id} was not found.")
        { 
        }
    }
}
