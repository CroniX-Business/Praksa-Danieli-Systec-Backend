namespace WebApplication2.DTO
{
    public class PriceDTO
    {
        /// <summary>Gets or sets the item price.</summary>
        /// <value>The item price.</value>
        public decimal ItemPrice { get; set; }

        /// <summary>Gets or sets the valid from.</summary>
        /// <value>The valid from.</value>
        public DateTime ValidFrom { get; set; } = DateTime.UtcNow;

        /// <summary>Gets or sets the valid to.</summary>
        /// <value>The valid to.</value>
        public DateTime? ValidTo { get; set; } = null!;

        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }
    }
}
