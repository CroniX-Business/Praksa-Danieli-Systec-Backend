using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
    /// <summary>
    ///   <br />
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets the time stamp.</summary>
        /// <value>The time stamp.</value>
        public byte TimeStamp {  get; set; }

        /// <summary>Gets or sets the created date.</summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>Gets or sets the modified date.</summary>
        /// <value>The modified date.</value>
        public DateTime ModifiedDate { get; set; }
    }
}
