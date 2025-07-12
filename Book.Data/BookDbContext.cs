using Book.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    /// <summary>
    /// Represents a session with the database for managing book-related data.
    /// </summary>
    /// <remarks>This class provides the necessary context for querying and saving instances of book entities.
    /// It is typically used in conjunction with Entity Framework to perform database operations.</remarks>
    public class BookDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the collection of books in the database context.
        /// </summary>
        public DbSet<Books>? Books { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookDbContext"/> class using the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the <see cref="DbContext"/>. This includes configuration settings such as the
        /// database provider and connection string.</param>
        public BookDbContext(DbContextOptions<BookDbContext> options)
           : base(options)
        {
        }

        /// <summary>
        /// Configures the model for the context by defining the schema needed for the database.
        /// </summary>
        /// <remarks>This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context. The default implementation of this
        /// method does nothing, but it can be overridden in a derived class to configure the model. In this
        /// implementation, the <c>Books</c> entity is configured with specific constraints such as primary key and
        /// required properties with maximum lengths.</remarks>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Books entity
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(b => b.Id); // Set Id as the primary key
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200); // Title is required with a max length
                entity.Property(b => b.Author).IsRequired().HasMaxLength(100); // Author is required with a max length
                entity.Property(b => b.CraatedAt).IsRequired(); // PublishedYear is required
            });
        }
    }
}
