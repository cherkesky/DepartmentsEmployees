using System;
using System.Collections.Generic;


namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)

             // ******************** GET ALL ********************
        {
            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Getting All Departments:");
            Console.WriteLine();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id} {dept.DeptName}");

            }
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Console.WriteLine();
            Console.WriteLine("Getting All Employees:");
            Console.WriteLine();

            List<Employee> allEmployees = employeeRepo.GetAllEmployees();

            foreach (Employee e in allEmployees)
            {
                Console.WriteLine($"{e.Id} {e.FirstName} {e.LastName} {e.DepartmentId}");

            }


            //// ******************** get one ********************

            //console.writeline("----------------------------");
            //console.writeline("getting department with id 1");

            //department singledepartment = departmentrepo.getdepartmentbyid(1);

            //console.writeline($"{singledepartment.id} {singledepartment.deptname}");


            //// ******************** add ********************
            //department legaldept = new department
            //{
            //    deptname = "legal"
            //};

            //departmentrepo.adddepartment(legaldept);

            //console.writeline("-------------------------------");
            //console.writeline("added the new legal department!");






        }
    }
}
