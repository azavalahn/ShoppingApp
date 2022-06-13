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
    public class EmployeeTypeRepositoryTests
    {
        private DbContextOptions<AppDBContext> dbContextOptions;

        public EmployeeTypeRepositoryTests()
        {
            var dbName = $"EmployeeDB_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        } 
        [Fact]
        public async Task GetEmployeeTypes_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var employeeTypes = repository.GetEmployeeTypes();

            // Assert
            Assert.Equal(3, employeeTypes.Count());
        }

        [Fact]
        public async Task CreateEmployeeType_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act

            var employeeType = new EmployeeType()
            {
                Id = 5,
                Name = "Employee Type",
                Salary = 3000
                
            };

            repository.CreateEmployeeType(employeeType);
            

            // Assert
            var employeeTypes = repository.GetEmployeeTypes();
            Assert.Equal(4, employeeTypes.Count());
        }
        private async Task<EmployeeTypeRepository> CreateRepositoryAsync()
        {
            AppDBContext context = new AppDBContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new EmployeeTypeRepository(context);
        }

        private async Task PopulateDataAsync(AppDBContext context)
        {
            int index = 1;
            Random random = new Random();
            while (index <=3 )
            {
                var employeeType = new EmployeeType()
                {
                    Id = index,
                    Name = $"Employee Type {index} ",
                    Salary = random.Next(1000, 3000),
                    
                };
                index++;
                await context.EmployeeTypes.AddAsync(employeeType);
            }
            
            await context.SaveChangesAsync();
            
        }
    }
}