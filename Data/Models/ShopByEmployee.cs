using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class ShopByEmployee
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime WorkDate { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        

    }
}
