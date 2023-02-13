using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    [Table("TblEmloyee")]
    public class Employee:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        private Department Department { get; set; }

        [StringLength(50), Required]
        public string? EmployeeName { get; set; }

        [StringLength(50), Required]
        public string? EmployeeSurName { get; set; }

        [StringLength(50)]
        public string? EmployeeAddress { get; set; }

        public float EmployeeSalary { get; set; }

    }
}
