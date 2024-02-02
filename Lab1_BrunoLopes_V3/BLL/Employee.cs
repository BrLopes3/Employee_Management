using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Lab1_BrunoLopes_V3.DAL;

namespace Lab1_BrunoLopes_V3.BLL
{
    public class Employee
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        //default constructor
        public Employee()
        {
            employeeID = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        //parameterized constructor
        public Employee(int employeeID, string firstName, string lastName, string jobTitle)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }
        
        //custom methods
        public void SaveEmployee (Employee employee)
        {
            //call the method to save an employee
            EmployeeDB.SaveRecord(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            //call the method to update an employee
            EmployeeDB.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            //call the method to delete an employee
            EmployeeDB.DeleteEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            //call the method to get all employees
            return EmployeeDB.GetAllRecords();
        }

        public Employee SearchEmployee(int employeeId)
        {
            //call the method to get an employee by id
            return EmployeeDB.SearchEmployeeId(employeeId);
        }

        public List<Employee> SearchEmpFirstName(string firstName)
        {
            //call the method to get an employee by first name
            return EmployeeDB.SearchEmployeeFName(firstName);
        }

        public List<Employee> SearchEmpLastName(string lastName)
        {
            //call the method to get an employee by last name
            return EmployeeDB.SearchEmployeeLName(lastName);
        }

        public List<Employee> SearchEmpName(string firstName, string lastName)
        {
            //call the method to get an employee by name
            return EmployeeDB.SearchEmployee(firstName, lastName);
        }

        //verify if ID is unique before saving (using lambda expression)
        public bool IsUniqueId(int id) => EmployeeDB.IsUniqueId(id);

    }
}