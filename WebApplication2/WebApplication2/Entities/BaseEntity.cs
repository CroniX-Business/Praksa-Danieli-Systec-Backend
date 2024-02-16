using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
    public abstract class BaseEntity
    {
        public bool IsActive {  get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        
    }
}
