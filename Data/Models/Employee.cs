using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int EmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }

        public string? Telephone { get; set; }

        public string? Address { get; set; }

        public DateTime EmploymentDate { get; set; }
       
    }
}
