using AutoMapper;
using Book.Api.Interfaces;
using Book.Api.Models;
using Book.Data.Interfaces;
using Book.Data.Models;

namespace Book.Api.Services
{
    /// <summary>
    /// Provides services for managing books, including operations to retrieve, create, update, and delete book records.
    /// </summary>
    /// <remarks>This service acts as an intermediary between the data repository and the application,
    /// handling data mapping and business logic related to book management. It uses an <see cref="IBookRepository"/> to
    /// perform data operations and an <see cref="IMapper"/> to map between data models and DTOs.</remarks>
    public class BookService : IBookServices
    {
        /// <summary>
        /// Represents a repository for managing book-related data operations.
        /// </summary>
        /// <remarks>This field is used to interact with the underlying data store for book entities. It
        /// is intended for internal use within the class to perform CRUD operations on books.</remarks>
        private readonly IBookRepository _bookRepository;
       
        /// <summary>
        /// Provides mapping functionality between objects using the specified mapper.
        /// </summary>
        /// <remarks>This field is used to perform object-to-object mapping, typically for converting
        /// between different data models or DTOs. The mapper is initialized externally and should be configured to
        /// handle the necessary mappings.</remarks>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class with the specified book repository and
        /// mapper.
        /// </summary>
        /// <param name="bookRepository">The repository used to access and manage book data. Cannot be null.</param>
        /// <param name="mapper">The mapper used to convert between data models and view models. Cannot be null.</param>
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all books available in the repository.
        /// </summary>
        /// <returns>A list of <see cref="BookDto"/> objects representing all books. The list will be empty if no books are
        /// available.</returns>
        public IList<BookDto> GetAllBooks()
        {
            IList<Data.Models.Books> books = _bookRepository.GetAllBooks();
            return _mapper.Map<IList<BookDto>>(books);
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book to retrieve.</param>
        /// <returns>A <see cref="BookDto"/> representing the book with the specified identifier. Returns <see langword="null"/>
        /// if no book with the given identifier is found.</returns>
        public BookDto GetBook(int id)
        {
            Books? book = _bookRepository.GetById(id);
            if (book is null)
                return null!; // Return null if the book is not found
            return _mapper.Map<BookDto>(book);
        }

        /// <summary>
        /// Creates a new book record in the repository based on the provided book data transfer object.
        /// </summary>
        /// <param name="bookDto">The data transfer object containing the details of the book to be created. The <c>Id</c> property is ignored
        /// and set to default.</param>
        /// <returns>A <see cref="BookDto"/> representing the newly created book, including its assigned identifier.</returns>
        public BookDto Create(BookDto bookDto)
        {
            Books bookEntity = _mapper.Map<Books>(bookDto);
            bookEntity.Id = default; // Ensure Id is set to default for new entities
            Books createdBook = _bookRepository.Insert(bookEntity);
            return _mapper.Map<BookDto>(createdBook);
        }

        /// <summary>
        /// Updates an existing book record with the specified data.
        /// </summary>
        /// <param name="bookDto">The data transfer object containing the updated book information.</param>
        /// <returns>A <see cref="BookDto"/> representing the updated book.</returns>
        public BookDto Update(BookDto bookDto)
        {
            Books bookEntity = _mapper.Map<Books>(bookDto);
            Books updatedBook = _bookRepository.Update(bookEntity);
            return _mapper.Map<BookDto>(updatedBook);
        }

        /// <summary>
        /// Deletes the book with the specified identifier from the repository.
        /// </summary>
        /// <remarks>If the book with the specified identifier does not exist, the method completes
        /// without performing any action.</remarks>
        /// <param name="id">The identifier of the book to delete. Must be a valid identifier of an existing book.</param>
        public void Delete(int id)
        {
            Books? book = _bookRepository.GetById(id);
            if (book is null)
            return;
            try
            {
                _bookRepository.Delete(id);
            }
            catch
            {
                // Handle exceptions as needed, e.g., log the error or rethrow
                throw;
            }
        }
    }
}
