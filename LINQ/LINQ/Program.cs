// See https://aka.ms/new-console-template for more information


using LINQ;

//Using Array
string[] names = { "Bill", "James", "Mohan"};
var myQuery = from name in names
              where name.Contains("a")
              select name;
foreach(var name in myQuery)
{
    Console.WriteLine(name);
}

IList<string> stringList = new List<string>() 
{"Canada", "Singapore", "USA", "Austrailia", "Sri Lanka"};

//LINQ Query Syntax
var result1 = from s in stringList
              where s.Contains("S")
              select s;

//LINQ Mthod Syntax
var result2 = stringList.Where(s => s.Contains("S"));

IList < Employee > employees = new List<Employee>()
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

//Query Syntax
var selectedEmployees1 = from emp in employees
                        join bnd in employeeBands on emp.EmpId equals bnd.EmpId
                        join salary in employeeSalaries on emp.EmpId equals salary.EmpId
                        where salary.EmpSalary > 50000
                        select new
                        {
                            EmpId = emp.EmpId,
                            EmpName = emp.Name,
                            Band = bnd.EmpBand
                        };

//Method Syntax
var selectedEmployees2 = employees.Join(employeeBands, emp1 => emp1.EmpId, bnd => bnd.EmpId, (emp1, bnd) => new
{
    emp1, bnd
}).Join(employeeSalaries, emp2 => emp2.emp1.EmpId, sal => sal.EmpId, (emp2, sal) => new
{
    emp2, sal
}).Where(s => s.sal.EmpSalary > 50000).Select(s => new { 
    EmpId = s.emp2.emp1.EmpId,
    EmpName = s.emp2.emp1.Name,
    Band = s.emp2.bnd.EmpBand
});

//Query Syntax
var sumOfSalaries1 = from salary in employeeSalaries
                    join empProj in employeeProjects on salary.EmpId equals empProj.EmpId
                    join proj in projects on empProj.ProjectId equals proj.ProjectId
                    where proj.Project == "PQS"
                    select salary;

var sum = sumOfSalaries1.Sum(s => s.EmpSalary);

Console.WriteLine("Sum:" + sum);

//Method Syntax
var sumOfSalaries2 = employeeSalaries.Join(employeeProjects, sal => sal.EmpId, empProj1 => empProj1.EmpId, (sal, empProj1) => new 
{ 
    sal, empProj1
}).Join(projects, empProj2 => empProj2.empProj1.ProjectId, proj => proj.ProjectId, (empProj2, proj) => new 
{
    empProj2, proj
}).Where(s => s.proj.Project == "PQS").Sum(m => m.empProj2.sal.EmpSalary);

Console.WriteLine("End");

