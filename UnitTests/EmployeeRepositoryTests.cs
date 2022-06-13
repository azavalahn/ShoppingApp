using Data.Data;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class EmployeeRepositoryTests
    {
        private DbContextOptions<AppDBContext> dbContextOptions;

        public EmployeeRepositoryTests()
        {
            var dbName = $"EmployeeDB_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        } 
        [Fact]
        public async Task GetEmployees_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var employees = repository.GetEmployees();

            // Assert
            Assert.Equal(3, employees.Count());
        }

        [Fact]
        public async Task CreateEmployee_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act

            var employee = new Employee()
            {
                Id = 5,
                Name = "Name 5 LastName 5",
                EmployeeTypeId = 1,
                Telephone = "99999999",
                EmploymentDate = DateTime.Now
            };

            repository.CreateEmployee(employee);
            

            // Assert
            var employees = repository.GetEmployees();
            Assert.Equal(4, employees.Count());
        }
        private async Task<EmployeeRepository> CreateRepositoryAsync()
        {
            AppDBContext context = new AppDBContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new EmployeeRepository(context);
        }

        private async Task PopulateDataAsync(AppDBContext context)
        {
            int index = 1;
            Random random = new Random();
            while (index <=3 )
            {
                var employee = new Employee()
                {
                    Id = index,
                    Name = $"Name {index} LastName {index}",
                    EmployeeTypeId = random.Next(1, 2),
                    Telephone = "99999999",
                    EmploymentDate = DateTime.Now
                };
                index++;
                await context.Employees.AddAsync(employee);
            }
            
            await context.SaveChangesAsync();
            
        }
    }
}