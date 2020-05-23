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
        } // sqlconnection








    }//class
}//namespace