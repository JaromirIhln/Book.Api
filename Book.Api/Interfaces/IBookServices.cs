using Book.Api.Models;

namespace Book.Api.Interfaces
{
    /// <summary>
    /// Provides methods for managing books, including retrieval, creation, updating, and deletion.
    /// </summary>
    public interface IBookServices
    {
        /// <summary>
        /// Retrieves the book details for the specified book identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book to retrieve.</param>
        /// <returns>A <see cref="BookDto"/> containing the details of the book. Returns <see langword="null"/> if the book is
        /// not found.</returns>
        BookDto GetBook(int id);
        /// <summary>
        /// Retrieves a collection of books.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BookDto"/> representing the books available. The collection
        /// will be empty if no books are available.</returns>
        IList<BookDto> GetAllBooks();
        /// <summary>
        /// Creates a new book entry based on the provided book details.
        /// </summary>
        /// <param name="book">The details of the book to create. Must not be null.</param>
        /// <returns>A <see cref="BookDto"/> representing the newly created book.</returns>
        BookDto Create(BookDto book);
        /// <summary>
        /// Updates the details of an existing book.
        /// </summary>
        /// <remarks>The method updates the book's information in the data store. Ensure that the book's
        /// identifier is valid and corresponds to an existing entry.</remarks>
        /// <param name="book">The <see cref="BookDto"/> containing the updated information for the book. Must not be null.</param>
        /// <returns>The updated <see cref="BookDto"/> reflecting the changes made.</returns>
        BookDto Update(BookDto book);
        void Delete(int id);
    }
}
