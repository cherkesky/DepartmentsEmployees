﻿using System;
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

            // ******************** GET ONE ********************
            Console.WriteLine("----------------------------");
            Console.WriteLine("getting DEPARTMENT with id 1");
            Department singleDepartment = departmentRepo.GetDepartmentById(1);
            Console.WriteLine($"{singleDepartment.Id} {singleDepartment.DeptName}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("getting EMPLOYEE with id 1");
            Employee singleEmployee = employeeRepo.getEmployeeById(1);
            Console.WriteLine($"{singleEmployee.Id} {singleEmployee.FirstName} {singleEmployee.LastName} {singleEmployee.DepartmentId}");


            // ******************** GET ALL + DEPT ********************

            DepartmentRepository departmentRepoAll = new DepartmentRepository();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Getting All Employees With Departments:");

            List<Employee> allEmployeesAll = employeeRepo.GetAllEmployeesWithDepartment();

            foreach (Employee e in allEmployeesAll)
            {
                Console.WriteLine($"{e.Id} {e.FirstName} {e.LastName} - {e.Department.DeptName}");

            }


            // ******************** ADD ********************	
            Department legalDept = new Department
            {
                DeptName = "Legal"
            };

            departmentRepo.AddDepartment(legalDept); // departmentRepo has been initialized in line 13

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Added the new Legal Department!");

            Employee cherkesky = new Employee
            {
                FirstName = "Guy",
                LastName = "Cherkesky",
                DepartmentId = 2
            };

            employeeRepo.AddEmployee(cherkesky); // employeeRepo has been initialized in line 25

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Added the new talented Employee!");








        }
    }
}
