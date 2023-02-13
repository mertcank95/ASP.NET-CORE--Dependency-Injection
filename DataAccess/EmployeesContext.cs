using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeesContext:DbContext
    {
        const string path = @"Server=(localdb)\mssqllocaldb;Database=Employees;Trusted_Connection=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(path);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                Console.WriteLine(e.Message);
            }
        }   
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
