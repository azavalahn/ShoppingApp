using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class EmployeeType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public double Salary { get; set; }

        
    }
}
