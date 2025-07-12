using Book.Data.Models;

namespace Book.Data.Interfaces
{
    /// <summary>
    /// Defines a contract for a repository that manages book entities.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for providing data access operations for
    /// book entities, such as retrieving, adding, updating, or deleting books.</remarks>
    public interface IBookRepository: IBaseRepository<Books>
    {
        
    }
}
