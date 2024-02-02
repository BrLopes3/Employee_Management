using Lab1_BrunoLopes_V3.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_BrunoLopes_V3.DAL
{
    public class EmployeeDB
    {
        //method to save an employee
        public static void SaveRecord(Employee employee)
        {
            //Open connection with database
            SqlConnection conn = UtilityDB.GetDBConnection();

            //Create a SQL command object
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId, FirstName, LastName, JobTitle) VALUES (@EmployeeId, @FirstName, @LastName, @JobTitle)";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", employee.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmdInsert.ExecuteNonQuery();

            //Close connection
            conn.Close();

        }

        //method to get all employees
        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();
            //Open connection with database
            SqlConnection conn = UtilityDB.GetDBConnection();
            //Create a SQL command object
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            //Execute the command
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Employee emp;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add(emp);
            }
            
            conn.Close();
            return listE;
        }

        //method to get an employee by id
        public static Employee SearchEmployeeId(int employeeId)
        {
            Employee emp;
            //open connection
            SqlConnection conn = UtilityDB.GetDBConnection();
            //create a sql command object
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;

            cmdSearch.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
            cmdSearch.Parameters.AddWithValue("@EmployeeId", employeeId);

            SqlDataReader reader = cmdSearch.ExecuteReader();

            if (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                emp = null;
            }
            conn.Close();
            return emp;

        }

        //verify if the id is unique
        public static bool IsUniqueId (int id)
        {
            Employee emp = new Employee();
            emp = SearchEmployeeId(id);
            if(emp != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //method to search an employee by first name
        public static List<Employee> SearchEmployeeFName(string employeeFName)
        {
            List<Employee> listEmpFn = new List<Employee>();

            Employee emp;
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;

            cmdSearch.CommandText = "SELECT * FROM Employees WHERE FirstName = @EmployeeFName";
            cmdSearch.Parameters.AddWithValue("@EmployeeFName", employeeFName);

            SqlDataReader reader = cmdSearch.ExecuteReader();

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listEmpFn.Add(emp);
            }

            conn.Close();
            return listEmpFn;
        }

        //method to search an employee by last name
        public static List<Employee> SearchEmployeeLName(string employeeLName)
        {
            List<Employee> listEmpLn = new List<Employee>();

            Employee emp;
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;

            cmdSearch.CommandText = "SELECT * FROM Employees WHERE LastName = @EmployeeLName";
            cmdSearch.Parameters.AddWithValue("@EmployeeLName", employeeLName);

            SqlDataReader reader = cmdSearch.ExecuteReader();

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listEmpLn.Add(emp);
            }
            conn.Close();
            return listEmpLn;
        }

        //method to search an employee by first and last name
        public static List<Employee> SearchEmployee(string FirstName, string LastName)
        {
            List<Employee> listEmp = new List<Employee>();

            Employee emp;
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;

            cmdSearch.CommandText = "SELECT * FROM Employees WHERE FirstName = @FirstName AND LastName = @LastName";
            cmdSearch.Parameters.AddWithValue("@FirstName", FirstName);
            cmdSearch.Parameters.AddWithValue("@LastName", LastName);

            SqlDataReader reader = cmdSearch.ExecuteReader();

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listEmp.Add(emp);
            }
            conn.Close();
            return listEmp;
        }

        //method to update an employee
        public static void UpdateEmployee(Employee emp)
        {
            //Open connection with database
            SqlConnection conn = UtilityDB.GetDBConnection();

            //Create a SQL command object
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle WHERE EmployeeId = @EmployeeId";
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeID);
            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdUpdate.ExecuteNonQuery();

            //Close connection
            conn.Close();
        }

        //method to delete an employee
        public static void DeleteEmployee(Employee emp)
        {
            //Open connection with database
            SqlConnection conn = UtilityDB.GetDBConnection();

            //Create a SQL command object
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
            cmdDelete.Parameters.AddWithValue("@EmployeeId", emp.EmployeeID);
            cmdDelete.ExecuteNonQuery();

            //Close connection
            conn.Close();
        }

    }
}