using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        List<dynamic> GetDepartmentEmployeeList();
        List<Employee> GetEmployeebyDepertmant(int depertmantId);
        void InsertFakeEmployeeData(int count);
        string InsertEmployee(Employee employee);
        string DeleteEmployee(int employeeId);
        string UpdateEmployee(Employee employee);
    }
}
