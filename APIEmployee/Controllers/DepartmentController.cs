using Business.Absract;
using DataAccess.Abstract;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("getall")]
        public List<Department> GetDepartment()
        {
            return _departmentService.GetAllDepartments();
        }
        [HttpGet("getid")]
        public Department GetById(int departmentId)
        {
            return _departmentService.GetDepartment(departmentId);
        }
        [HttpGet("{count}")]
        public void InsertFakeData(int count)
        {
           _departmentService.InsertFakeDepartmentData(count);
        }
       
        [HttpPost("insert")]
        public string Insert(Department department)
        {
            var result = _departmentService.InsertDepartment(department);
            return result;
        }
        [HttpPost("update")]
        public string Update(Department department)
        {
            var result = _departmentService.UpdateDepartment(department);
            return result;
        }
        [HttpPost("delete")]
        public string Delete(int deparmentId)
        {
            var result = _departmentService.DeleteDepartment(deparmentId);
            return result;
        }

    }
}
