namespace ProductNS.Application.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id)
            : base($"The category with the id: {id} was not found.")
        { 
        }
    }
}
