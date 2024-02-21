using WebApplication2.Entities;

namespace WebApplication2.DTO
{
    public class RestaurantDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public ICollection<Item> Items { get; } = new List<Item>();
    }
}
