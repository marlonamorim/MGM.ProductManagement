using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the system with category information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the product's title.
        /// Must not be null or empty.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's price.
        /// Determines a price the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product's description.
        /// Must not be null or empty.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's category.
        /// Determines a category the product.
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Gets the product's image.
        /// Must not be null or empty.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Determines a idetifier the rating.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Gets the product's rating count.
        /// Determines a rating in the product count.
        /// </summary>
        public int RatingCount { get; set; }

        public void Update(string title, decimal price, string description, ProductCategory category, string image, int rate, int ratingCount)
        {
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;
            Rate = rate;
            RatingCount = ratingCount;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
