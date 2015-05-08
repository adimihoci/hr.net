using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Location", Schema = "HR")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public string StateProvince { get; set; }
    }
}
