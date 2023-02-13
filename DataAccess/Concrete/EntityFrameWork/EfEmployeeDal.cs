using Core.Data.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfEmployeeDal : EfEntityRepository<Employee, EmployeesContext>, IEmployeeDal
    {
        public IEnumerable<dynamic> DepartmentEmployeeList()
        {
            using(EmployeesContext context = new EmployeesContext())
            {
                var result = from employee in context.Employees
                             join department in context.Departments on 
                             employee.DepartmentId equals department.DepartmentId
                             select new
                             {
                                 EmployeeName = employee.EmployeeName,
                                 DepartmentName = department.DepartmentName,
                                 Salary = employee.EmployeeSalary
                             };
                return result.ToList();
            }
        }
    }
}
