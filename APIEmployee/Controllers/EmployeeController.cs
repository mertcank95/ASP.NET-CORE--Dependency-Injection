using Business.Absract;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _emloyeeService;
        public EmployeeController(IEmployeeService emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }
        [HttpGet("getall")]
        public List<Employee> GetEmployees()
        {
            return _emloyeeService.GetAllEmployees();
        }
        [HttpGet("getdepartmentemployeeList")]
        public IEnumerable<dynamic> GetDepartmentsEmployeesList()
        {
            return _emloyeeService.GetDepartmentEmployeeList();
        }
        [HttpGet("getid")]
        public Employee GetById(int employeeId)
        {
            return _emloyeeService.GetEmployee(employeeId);
        }
        [HttpGet("{count}")]
        public void InsertFakeData(int count)
        {
            _emloyeeService.InsertFakeEmployeeData(count);
        }
        [HttpGet("getlistbydeparment")]
        public List<Employee> GetByCategory(int departmentId)
        {
            return _emloyeeService.GetEmployeebyDepertmant(departmentId);
        }
        [HttpPost("insert")]
        public string Insert(Employee employee)
        {
          var result =  _emloyeeService.InsertEmployee(employee);
          return result;
        }
        [HttpPost("update")]
        public string Update(Employee employee)
        {
            var result = _emloyeeService.UpdateEmployee(employee);
            return result;
        }
        [HttpPost("delete")]
        public string Delete(int employeeId)
        {
            var result = _emloyeeService.DeleteEmployee(employeeId);
            return result;
        }
    }
}
