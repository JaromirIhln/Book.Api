using Book.Api.Interfaces;
using Book.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Book.Api.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing books in the system.
    /// </summary>
    /// <remarks>This controller handles HTTP requests for retrieving, creating, updating, and deleting books.
    /// It uses the <see cref="IBookServices"/> to perform operations on book data.</remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Provides access to book-related services.
        /// </summary>
        /// <remarks>This field is intended to be used for operations related to book management, such as
        /// retrieving, adding, or updating book information. Ensure that the implementation of <see
        /// cref="IBookServices"/> is properly initialized before use.</remarks>
        public IBookServices bookServicecs;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class with the specified book services.
        /// </summary>
        /// <param name="bookServicecs">The service used to manage book-related operations.</param>
        public BooksController(IBookServices bookServicecs)
        {
            this.bookServicecs = bookServicecs;
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <remarks>This method returns an HTTP 404 status code if the book with the specified <paramref
        /// name="id"/> does not exist.</remarks>
        /// <param name="id">The unique identifier of the book to retrieve.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the <see cref="BookDto"/> if found; otherwise, a NotFound
        /// result.</returns>
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            var book = bookServicecs.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>An <see cref="ActionResult{T}"/> containing a list of <see cref="BookDto"/> objects representing all books.
        /// Returns <see cref="NotFoundResult"/> if no books are available.</returns>
        [HttpGet]
        public ActionResult<IList<BookDto>> GetAllBooks()
        {
            var books = bookServicecs.GetAllBooks();
            if (books is null)
            
                return NotFound();
            
            return Ok(books);
        }

        /// <summary>
        /// Creates a new book entry in the system.
        /// </summary>
        /// <param name="book">The book data transfer object containing the details of the book to be created. Cannot be null.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the created <see cref="BookDto"/> and a location header pointing
        /// to the new resource.</returns>
        [HttpPost]
        public ActionResult<BookDto> Create([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Books cannot be null");
            }
            var createdBook = bookServicecs.Create(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        /// <summary>
        /// Updates the details of an existing book.
        /// </summary>
        /// <param name="book">The <see cref="BookDto"/> object containing the updated book details. Cannot be null.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the updated <see cref="BookDto"/> if the update is successful;
        /// otherwise, a <see cref="BadRequestResult"/> if the input is null, or a <see cref="NotFoundResult"/> if the
        /// book does not exist.</returns>
        [HttpPut]
        public ActionResult<BookDto> Update([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Books cannot be null");
            }
            var updatedBook = bookServicecs.Update(book);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        /// <summary>
        /// Deletes the book with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the book to delete. Must be a valid book ID.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="NotFoundResult"/> if the book does not exist; otherwise, returns <see cref="NoContentResult"/>.</returns>

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = bookServicecs.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            bookServicecs.Delete(id);
            return NoContent();
        }
    }
   
}
