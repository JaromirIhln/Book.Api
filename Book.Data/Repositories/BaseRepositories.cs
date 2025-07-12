using Book.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories
{
    /// <summary>
    /// Provides a base implementation for repository operations on entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <remarks>This class offers basic CRUD operations for entities within a database context. It is
    /// designed to be extended by more specific repository classes.</remarks>
    /// <typeparam name="TEntity">The type of the entity for which the repository is responsible. Must be a reference type.</typeparam>
    public class BaseRepositories<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Represents the database context used for accessing book-related data.
        /// </summary>
        /// <remarks>This field is intended for use within derived classes to interact with the database.
        /// It provides access to the underlying data store for operations related to books.</remarks>
        protected readonly BookDbContext bookDbContext;

        /// <summary>
        /// Represents the database set for the specified entity type.  
        /// </summary>
        /// <remarks>This field is used to perform CRUD operations on the entity type <typeparamref
        /// name="TEntity"/>. It is typically initialized in the constructor of a class that manages database
        /// operations.</remarks>
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepositories{TEntity}"/> class with the specified database
        /// context.
        /// </summary>
        /// <remarks>This constructor sets up the repository to interact with the specified database
        /// context, allowing operations on the entity set of type <typeparamref name="TEntity"/>.</remarks>
        /// <param name="context">The <see cref="BookDbContext"/> used to access the database. Cannot be <see langword="null"/>.</param>
        public BaseRepositories(BookDbContext context)
        {   
            this.bookDbContext = context ;
            _dbSet = bookDbContext.Set<TEntity>();
        }

        /// <summary>
        /// Retrieves all book entities from the database.
        /// </summary>
        /// <returns>A list of all book entities. The list will be empty if no books are found.</returns>
        public IList<TEntity> GetAllBooks()
        {
            return _dbSet.ToList();
        }
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <remarks>The returned entity is detached from the context, meaning it is not tracked by the
        /// database context.</remarks>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier, or <see langword="null"/> if no such entity exists.</returns>
        public TEntity GetById(int id)
        {
            TEntity? entity = _dbSet.Find(id);
            if (entity is not null)
                bookDbContext.Entry(entity).State = EntityState.Detached;

#pragma warning disable CS8603 // Possible null reference return.
            return entity;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Inserts a new entity into the database and saves the changes.
        /// </summary>
        /// <param name="entity">The entity to be inserted. Cannot be null.</param>
        /// <returns>The inserted entity with updated state from the database.</returns>
        public TEntity Insert(TEntity entity)
        {
           EntityEntry<TEntity> entityEntry = _dbSet.Add(entity);
           bookDbContext.SaveChanges();
           return entityEntry.Entity;
        }

        /// <summary>
        /// Updates the specified entity in the database and saves the changes.
        /// </summary>
        /// <param name="entity">The entity to update. Must not be null.</param>
        /// <returns>The updated entity.</returns>
        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = _dbSet.Update(entity);
            bookDbContext.SaveChanges();
            return entityEntry.Entity;
        }
        /// <summary>
        /// Deletes the entity with the specified identifier from the database.
        /// </summary>
        /// <remarks>If the entity with the specified identifier does not exist, the method completes
        /// without making any changes. If an error occurs during the deletion process, the entity's state is reset to
        /// unchanged, and the exception is rethrown.</remarks>
        /// <param name="id">The identifier of the entity to be deleted. Must be a valid identifier of an existing entity.</param>
        public void Delete(int id)
        {
            TEntity? entity = _dbSet.Find(id);
            if (entity is null)
                return;
            try
            {
                _dbSet.Remove(entity);
                bookDbContext.SaveChanges();
            }
            catch
            {
                bookDbContext.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }
    }
}
