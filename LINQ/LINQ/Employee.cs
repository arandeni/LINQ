using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }

    public class EmployeeBand
    {
        public virtual Employee Employee { get; set; }
        public int EmpId { get; set; }
        public int EmpBand { get; set; }
    }

    public class EmployeeSalary
    {
        public virtual Employee Employee { get; set; }
        public int EmpId { get; set; }
        public int EmpSalary { get; set; }
    }

    public class EmployeeProject
    {
        public virtual Employee Employee { get; set; }
        public virtual Projects Projects { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
    }

    public class Projects
    {
        public int ProjectId { get; set; }
        public string Project { get; set; }
    }
}
