using WebApplication2.Entities;

namespace WebApplication2.DTO
{
    public class ItemDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public int Sort { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant identifier.
        /// </summary>
        /// <value>
        /// The restaurant identifier.
        /// </value>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the order item.
        /// </summary>
        /// <value>
        /// The order item.
        /// </value>
        public OrderItem? OrderItem { get; set; }

        /// <summary>
        /// Gets the prices.
        /// </summary>
        /// <value>
        /// The prices.
        /// </value>
        public ICollection<Price> Prices { get; } = new List<Price>();
    }
}
