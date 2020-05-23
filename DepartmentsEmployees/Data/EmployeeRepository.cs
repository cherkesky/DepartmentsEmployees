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



    }//class
}//namespace