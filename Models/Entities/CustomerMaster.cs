using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Models.Entities
{
    [Table("CustomerMaster")]
    public class CustomerMaster
    {
        [Key]
        public int CustomerCode { get; set; }  // Primary Key and Auto Increment
        public required string Name { get; set; }       // Name of the customer
        public required string Address { get; set; }    // Address of the customer
        public required string Email { get; set; }      // Email address of the customer
        public required string MobileNo { get; set; }   // Mobile number of the customer
        public string? GeoLocation { get; set; } // GeoLocation
    }
}
