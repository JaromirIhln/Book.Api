
namespace Book.Data.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for performing CRUD operations on entities of type <typeparamref
    /// name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository will manage. Must be a reference type.</typeparam>
    public interface IBaseRepository <TEntity> where TEntity:class
    {
        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>A list of all books represented as <see cref="IList{TEntity}"/>. The list will be empty if no books are
        /// available.</returns>
        IList<TEntity> GetAllBooks();
        
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve. Must be a positive integer.</param>
        /// <returns>The entity associated with the specified identifier, or <see langword="null"/> if no such entity exists.</returns>
        TEntity GetById(int id);
        /// <summary>
        /// Inserts the specified entity into the data store.
        /// </summary>
        /// <param name="entity">The entity to insert. Cannot be null.</param>
        /// <returns>The inserted entity, including any updates made during the insertion process.</returns>
        TEntity Insert(TEntity entity);
        
        /// <summary>
        /// Updates the specified entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to update. Cannot be null.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// Deletes the entity with the specified identifier.
        /// </summary>
        /// <remarks>Ensure that the entity with the specified <paramref name="id"/> exists before calling
        /// this method to avoid unexpected behavior.</remarks>
        /// <param name="id">The unique identifier of the entity to be deleted. Must be a positive integer.</param>
        void Delete(int id);
        
       
    }
}
