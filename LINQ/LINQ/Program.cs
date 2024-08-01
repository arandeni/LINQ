// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using LINQ;

IList<Employee> employees = new List<Employee>()
{
    new Employee(){ EmpId = 123, Name = "Jon", DOB = new DateTime(1989, 01, 07)},
    new Employee(){ EmpId = 124, Name = "Alex", DOB= new DateTime(1985, 07, 06)},
};

IList<EmployeeBand> employeeBands = new List<EmployeeBand>()
{
    new EmployeeBand(){ EmpId = 123, EmpBand=1},
    new EmployeeBand(){ EmpId = 124, EmpBand=2}
};

IList<EmployeeSalary> employeeSalaries = new List<EmployeeSalary>()
{
    new EmployeeSalary(){ EmpId = 123, EmpSalary = 20000 },
    new EmployeeSalary(){ EmpId = 124, EmpSalary = 80000},
     new EmployeeSalary(){ EmpId = 125, EmpSalary = 20000},
};

IList<EmployeeProject> employeeProjects = new List<EmployeeProject>()
{
    new EmployeeProject(){ EmpId = 123, ProjectId = 1},
    new EmployeeProject(){ EmpId = 124, ProjectId = 2},
    new EmployeeProject(){ EmpId = 125, ProjectId = 2}
};

IList<Projects> projects = new List<Projects>() {
    new Projects(){ ProjectId = 1, Project = "ABC"},
    new Projects(){ ProjectId = 2, Project = "PQS"}
};

var selectedEmployees = from emp in employees
                        join bnd in employeeBands on emp.EmpId equals bnd.EmpId
                        join salary in employeeSalaries on emp.EmpId equals salary.EmpId
                        where salary.EmpSalary > 50000
                        select new
                        {
                            EmpId = emp.EmpId,
                            EmpName = emp.Name,
                            Band = bnd.EmpBand
                        };

var sumOfSalaries = from salary in employeeSalaries
                    join empProj in employeeProjects on salary.EmpId equals empProj.EmpId
                    join proj in projects on empProj.ProjectId equals proj.ProjectId
                    where proj.Project == "PQS"
                    select salary;

var sum = sumOfSalaries.Sum(s => s.EmpSalary);

Console.WriteLine("Sum:" + sum);

