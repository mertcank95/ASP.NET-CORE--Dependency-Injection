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
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentService(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public string DeleteDepartment(int departmentId)
        {
            var departmant = GetDepartment(departmentId);
            _departmentDal.Delete(departmant);
            return "Department Delete Successful";
        }
        public Department GetDepartment(int id)
        {
            return _departmentDal.Get(d => d.DepartmentId == id);
        }
        public List<Department> GetAllDepartments()
        {
            return _departmentDal.GetList().ToList();
        }
        public string InsertDepartment(Department department)
        {
            _departmentDal.Insert(department);
            return "Department Insert Successful";
        }
        public void InsertFakeDepartmentData(int count)
        {
            var departments = FakeDepartmentCreated(count);
            _departmentDal.FakeDataInsert(departments);
        }
        public string UpdateDepartment(Department department)
        {
            _departmentDal.Update(department);
            return "Department Update Successful";
        }
        List<Department> FakeDepartmentCreated(int count)
        {
            var departments = new Faker<Department>()
                .RuleFor(d => d.DepartmentName, f => f.Company.CompanyName())
                .Generate(count);
            return departments;
        }


    }
}
