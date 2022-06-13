using Microsoft.EntityFrameworkCore;
using Data.Models;
using System.Globalization;

namespace Data.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<EmployeeType>? EmployeeTypes { get; set; }
        public DbSet<Shop>? Shops { get; set; }
        public DbSet<ShopByEmployee>? ShopsByEmployee { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopByEmployee>().HasKey(sbe => new { sbe.EmployeeId, sbe.WorkDate });

            modelBuilder.Entity<EmployeeType>()
               .HasData(
                    new EmployeeType
                    {
                        Id = 1,
                        Name = "Manager",
                        Salary = 5000
                    },
                    new EmployeeType
                    {
                        Id =2,
                        Name = "Accountant",
                        Salary = 3000
                    },
                    new EmployeeType
                    {
                        Id = 3,
                        Name = "Clerk",
                        Salary = 1000
                    }

                );
            
            modelBuilder.Entity<Employee>()
               .HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Employee Demo Name",
                        EmployeeTypeId = 1,
                        Address = "Employee Demo Address",
                        Telephone = "1254789654",
                        EmploymentDate = DateTime.UtcNow
                    }
                );
        }
    }
}
