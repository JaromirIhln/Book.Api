using System.Text.Json.Serialization;

namespace Book.Api.Models
{
    /// <summary>
    /// Represents a data transfer object for a book, containing essential information such as title, author, and
    /// availability status.
    /// </summary>
    /// <remarks>This class is used to transfer book data between different layers of an application. It
    /// includes properties for the book's title, author, description, creation date, and availability status.</remarks>
    public class BookDto
    {
        [JsonPropertyName("_id")]
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
