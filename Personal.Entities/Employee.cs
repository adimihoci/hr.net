using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Employee", Schema = "HR")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public Job Job { get; set; }
        public decimal Salary { get; set; }
        public decimal CommisionPercent { get; set; }
        public Employee Manager { get; set; }
        public Department Department { get; set; }
    }
}
