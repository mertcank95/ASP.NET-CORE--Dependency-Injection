using Autofac;
using Business.Absract;
using Business.Concrete.Services;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoFac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>();
        }
    }
}
