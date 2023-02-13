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
    public class EfDepartmentDal:EfEntityRepository<Department, EmployeesContext>,IDepartmentDal
    {
    }
}
