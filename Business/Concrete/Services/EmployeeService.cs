using Bogus;
using Business.Absract;
using DataAccess.Abstract;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeService(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public string DeleteEmployee(int employeeId)
        {
            var employee = GetEmployee(employeeId);
            _employeeDal.Delete(employee);
            return "Delete Successful";
        }
        public Employee GetEmployee(int id)
        {
            return _employeeDal.Get(e => e.EmployeeId == id);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDal.GetList().ToList();
        }
        public List<Employee> GetEmployeebyDepertmant(int depertmantId)
        {
            return _employeeDal.GetList(e => e.DepartmentId == depertmantId).ToList();
        }
        public string InsertEmployee(Employee employee)
        {
            _employeeDal.Insert(employee);
            return "Insert Successful";
        }
        public void InsertFakeEmployeeData(int count)
        {
            var employees = FakeEmloyeeCreated(count);
            _employeeDal.FakeDataInsert(employees);
        }
        public string UpdateEmployee(Employee employee)
        {
            _employeeDal.Update(employee);
            return "Update Successful";
           
        }
        List<Employee> FakeEmloyeeCreated(int count)
        {
            var employees = new Faker<Employee>()
                .RuleFor(e => e.EmployeeName, f => f.Name.FirstName())
                .RuleFor(e => e.EmployeeSurName, f => f.Name.LastName())
                .RuleFor(e => e.EmployeeAddress, f => f.Address.FullAddress())
                .RuleFor(e => e.EmployeeSalary, f => f.Random.Number(1000, 10000))
                .RuleFor(e => e.DepartmentId, f => f.Random.Number(1, 4))
                .Generate(count);
            return employees;
        }

        public List<dynamic> GetDepartmentEmployeeList()
        {
          return  _employeeDal.DepartmentEmployeeList().ToList();
        }
    }
}
