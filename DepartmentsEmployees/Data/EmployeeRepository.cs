using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DepartmentsEmployees
{
    public class EmployeeRepository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=DESKTOP-B0AS73Q\\SQLEXPRESS;Initial Catalog=DepartmentsEmployees;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                return new SqlConnection(_connectionString);
            }
        } // sqlconnection settings


        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FirstName, LastName, DepartmentId FROM Employee";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int employeeFirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string employeeFirstNameValue = reader.GetString(employeeFirstNameColumnPosition);

                        int employeeLastNameColumnPosition = reader.GetOrdinal("LastName");
                        string employeeLastNameValue = reader.GetString(employeeLastNameColumnPosition);

                        int deptNameColumnPosition = reader.GetOrdinal("DepartmentId");
                        int deptNameValue = reader.GetInt32(deptNameColumnPosition);

                        Employee employee = new Employee
                        {
                            Id = idValue,
                            FirstName = employeeFirstNameValue,
                            LastName = employeeLastNameValue,
                            DepartmentId = deptNameValue
                        }; // dont forget the ;

                        employees.Add(employee);
                    }//while loop
                    reader.Close();
                    return employees;
                } // sqlconnection use
            }// sqlconnection use
        } //GET ALL()

        public Employee getEmployeeById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select Id, FirstName, LastName, DepartmentId from Employee Where Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id",id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = null;
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = id,
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId"))
                        };
                    }
                    reader.Close();
                    return employee;
                }
            }
        }//GET ONE()


        public List<Employee> GetAllEmployeesWithDepartment()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT e.Id, e.FirstName, e.Lastname, e.DepartmentId, d.Id, d.DeptName
                                        FROM Employee e
                                        LEFT JOIN Department d ON e.DepartmentId = d.Id";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);

                        int lastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumnPosition);

                        int deptIdColumn = reader.GetOrdinal("DepartmentId");
                        int deptValue = reader.GetInt32(deptIdColumn);

                        int deptNameColumnPosition = reader.GetOrdinal("DeptName");
                        string deptNameValue = reader.GetString(deptNameColumnPosition);

                        Employee employee = new Employee
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            DepartmentId = deptValue,
                            Department = new Department()
                            {
                                Id = deptValue,
                                DeptName = deptNameValue
                            }
                        };

                        employees.Add(employee);
                    }

                    reader.Close();

                    return employees;
                }
            }
        } // GET ALL + DEPT

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // These SQL parameters are annoying. Why can't we use string interpolation?
                    // ... sql injection attacks!!!
                    cmd.CommandText = @"
                    INSERT INTO Employee (FirstName, LastName, DepartmentId) 
                    OUTPUT INSERTED.Id
                    Values (@FirstName, @LastName, @DepartmentId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
                    cmd.Parameters.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));

                    int id = (int)cmd.ExecuteScalar();

                    employee.Id = id;
                }
            }

            // when this method is finished we can look in the database and see the new department.
        }





    }//class
}//namespace