using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Department", Schema = "HR")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int LocationId { get; set;}
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
