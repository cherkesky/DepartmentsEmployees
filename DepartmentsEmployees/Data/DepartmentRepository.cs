using System.Collections.Generic;
using System.Data.SqlClient;
using DepartmentsEmployees.Models;

namespace DepartmentsEmployees.Data
{
    /// <summary>
    ///  An object to contain all database interactions.
    /// </summary>
    public class DepartmentRepository
    {
        /// <summary>
        ///  Represents a connection to the database.
        ///   This is a "tunnel" to connect the application to the database.
        ///   All communication between the application and database passes through this connection.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DepartmentsEmployees;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

    }
}