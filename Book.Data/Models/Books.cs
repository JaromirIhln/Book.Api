using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Book.Data.Models
{
    /// <summary>
    /// Represents a book with properties for identification, title, author, description, creation date, and
    /// availability status.
    /// </summary>
    public class Books
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title of the item. 
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        public string Author { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CraatedAt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the item is available.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
