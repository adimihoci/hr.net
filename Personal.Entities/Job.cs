using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Job", Schema = "HR")]
    public class Job
    {
        [Required]
        public string JobId { get; set; }
        [MaxLength(25)]
        public string JobTitle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
    }
}
