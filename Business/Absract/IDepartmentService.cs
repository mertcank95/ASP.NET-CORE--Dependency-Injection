using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface IDepartmentService
    {
        Department GetDepartment(int id);
        List<Department> GetAllDepartments();
        void InsertFakeDepartmentData(int count);
        string InsertDepartment(Department departmant);
        string DeleteDepartment(int departmantId);
        string UpdateDepartment(Department departmant);
    }
}
