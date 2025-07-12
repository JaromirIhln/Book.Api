using Book.Data.Interfaces;
using Book.Data;

namespace Book.Data.Repositories
{
    /// <summary>  
    /// Provides a repository for managing <see cref="Models.Books"/> entities.  
    /// </summary>  
    /// <remarks>This class implements the <see cref="IBaseRepository{T}"/> and <see cref="IBookRepository"/>  
    /// interfaces, providing methods for CRUD operations and additional functionality specific to <see cref="Models.Books"/>  
    /// entities.</remarks>  
    public class BookRepository : BaseRepositories<Models.Books>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The <see cref="BookDbContext"/> used to access the book data store. Cannot be null.</param>
        public BookRepository(BookDbContext context) : base(context)
        {
        }
    }
}
