using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Lab1_BrunoLopes_V3.BLL;
using Lab1_BrunoLopes_V3.VALIDATION;
using Lab1_BrunoLopes_V3.DAL;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Globalization;

namespace Lab1_BrunoLopes_V3.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate the dropdownlist
            if (!Page.IsPostBack)
            {
                DropDownListSearchOption.Items.Add("Select an option");
                DropDownListSearchOption.Items.Add("ID");
                DropDownListSearchOption.Items.Add("First Name");
                DropDownListSearchOption.Items.Add("Last Name");
                DropDownListSearchOption.Items.Add("First and Last Name");
            }

            string option = ViewState["Option"] as string;
            TextBoxInputLastName.Visible = false;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //validate the input id
            string input  = TextBoxID.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Employee Id must be 4-digit number.","Invalid ID", MessageBoxButtons.OK,MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            //verify duplicate id
            Employee employee = new Employee();
            if(!employee.IsUniqueId(Convert.ToInt32(input)))
            {
                MessageBox.Show("Employee Id already exists.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            //verify first name
            input = TextBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("First Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxFirstName.Text = string.Empty;
                TextBoxFirstName.Focus();
                return;
            }
            //verify last name
            input = TextBoxLastName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Last Name must contain only letters.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxLastName.Text = string.Empty;
                TextBoxLastName.Focus();
                return;
            }
            //if all validations are ok, save the employee

            //create a textInfo object do apply the formating
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            //saving all information in the object
            employee.EmployeeID = Convert.ToInt32(TextBoxID.Text);
            employee.FirstName = TextBoxFirstName.Text.Trim().ToLower();
            employee.LastName = TextBoxLastName.Text.Trim().ToLower();
            employee.JobTitle = TextBoxJobTitle.Text.Trim().ToLower();

            //formating the strings to have only the first letter capitalized
            employee.FirstName = textInfo.ToTitleCase(employee.FirstName);
            employee.LastName = textInfo.ToTitleCase(employee.LastName);
            employee.JobTitle = textInfo.ToTitleCase(employee.JobTitle);
            
            //saving into the database
            employee.SaveEmployee(employee);
            MessageBox.Show("Employee saved successfully.", "Employee Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TextBoxID.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxJobTitle.Text = string.Empty;

            //clear the dropdownlist
            DropDownListSearchOption.SelectedIndex = 0;
            LabelDisplay.Text = string.Empty;
            LabelLastName.Visible = false;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            //validate the input id
            string input = TextBoxID.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Employee Id must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            //verify if id exists
            Employee employee = new Employee();
            if (employee.IsUniqueId(Convert.ToInt32(input)))
            {
                MessageBox.Show("Employee Id does not exist, it should be saved before updated.", "ID does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            //verify first name
            input = TextBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("First Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxFirstName.Text = string.Empty;
                TextBoxFirstName.Focus();
                return;
            }
            //verify last name
            input = TextBoxLastName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Last Name must contain only letters.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxLastName.Text = string.Empty;
                TextBoxLastName.Focus();
                return;
            }
            //if all validations are ok, update the employee
            employee.EmployeeID = Convert.ToInt32(TextBoxID.Text);
            employee.FirstName = TextBoxFirstName.Text.Trim();
            employee.LastName = TextBoxLastName.Text.Trim();
            employee.JobTitle = TextBoxJobTitle.Text.Trim();

            DialogResult result = MessageBox.Show($"Are you sure do you want to update this employee?\nID: {employee.EmployeeID}\nFirst Name: {employee.FirstName}\nLast Name: {employee.LastName}\nJob Title: {employee.JobTitle}", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            
            employee.UpdateEmployee(employee);
            MessageBox.Show("Employee updated successfully.", "Employee Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TextBoxID.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxJobTitle.Text = string.Empty;

            //clear the dropdownlist
            DropDownListSearchOption.SelectedIndex = 0;
            LabelDisplay.Text = string.Empty;
            LabelLastName.Visible = false;


        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            //validate the input id
            string input = TextBoxID.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Employee Id must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            //verify if id exists
            Employee employee = new Employee();
            if (employee.IsUniqueId(Convert.ToInt32(input)))
            {
                MessageBox.Show("Employee Id does not exist, it should be saved before deleted.", "ID does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxID.Text = string.Empty;
                TextBoxID.Focus();
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure do you want to delete this employee?\nID: {TextBoxID.Text}\nFirst Name: {TextBoxFirstName.Text}\nLast Name: {TextBoxLastName.Text}\nJob Title: {TextBoxJobTitle.Text}", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            //if all validations are ok, delete the employee
            employee.EmployeeID = Convert.ToInt32(TextBoxID.Text);
            employee.DeleteEmployee(employee);
            MessageBox.Show("Employee deleted successfully.", "Employee Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TextBoxID.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxJobTitle.Text = string.Empty;
            TextBoxInput.Text = string.Empty;

            //clear the dropdownlist
            DropDownListSearchOption.SelectedIndex = 0;
            LabelDisplay.Text = string.Empty;
            LabelLastName.Visible = false;

        }

        protected void ButtonList_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            GridViewEmployee.DataSource = employee.GetAllEmployees();
            GridViewEmployee.DataBind();
            DropDownListSearchOption.SelectedIndex = 0;
            LabelDisplay.Text = string.Empty;
            TextBoxInput.Text = string.Empty;
            LabelLastName.Visible = false;

            TextBoxID.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxJobTitle.Text = string.Empty;
        }

        string option; //option selected in the dropdownlist

        protected void DropDownListSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            option = DropDownListSearchOption.SelectedValue.ToString();
            TextBoxInput.Text = string.Empty;

            ViewState["Option"] = option;

            switch (option)
            {
                case "Select an option":
                    LabelDisplay.Text = string.Empty;
                    LabelLastName.Visible = false;
                    break;
                case "ID":
                    LabelDisplay.Text = "Enter Employee Id:";
                    LabelLastName.Visible = false;
                    break;
                case "First Name":
                    LabelDisplay.Text = "Enter First Name:";
                    LabelLastName.Visible = false;
                    break;
                case "Last Name":
                    LabelDisplay.Text = "Enter Last Name:";
                    LabelLastName.Visible = false;
                    break;
                case "First and Last Name":
                    LabelDisplay.Text = "Enter First Name:";
                    LabelLastName.Visible = true;
                    LabelLastName.Text = "Enter Last Name:";
                    TextBoxInputLastName.Visible = true;
                    break;
            }

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            option = DropDownListSearchOption.SelectedValue.ToString();
            switch (option)
            {
                case "ID":
                   
                    string input = TextBoxInput.Text.Trim();
                    if(!Validator.IsValidId(input,4))
                    {
                        MessageBox.Show("Employee Id must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();
                        return;
                    }

                    List<Employee> employeesId = new List<Employee>();
                    Employee empFound = new Employee();
                    empFound = employee.SearchEmployee(Convert.ToInt32(input));

                    if (empFound != null)
                    {
                        //show the information in the textboxes
                        TextBoxID.Text = empFound.EmployeeID.ToString();
                        TextBoxFirstName.Text = empFound.FirstName;
                        TextBoxLastName.Text = empFound.LastName;
                        TextBoxJobTitle.Text = empFound.JobTitle;

                        //show the information in the gridview
                        employeesId.Add(empFound);
                        GridViewEmployee.DataSource = employeesId;
                        GridViewEmployee.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Employee not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();
                        return;
                    }
                    break;

                case "First Name":
                    string fname = TextBoxInput.Text.Trim();
                    if (!Validator.IsValidName(fname))
                    {
                        MessageBox.Show("First Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();
                        return;
                    }

                    List<Employee> employeesFn = new List<Employee>();
                    employeesFn = employee.SearchEmpFirstName(fname);

                    if (employeesFn != null && employeesFn.Count>0)
                    {
                        GridViewEmployee.DataSource = employeesFn;
                        GridViewEmployee.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Employee not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();
                        return;
                    }
                    break;

                case "Last Name":

                    string lname = TextBoxInput.Text.Trim();
                    if (!Validator.IsValidName(lname))
                    {
                        MessageBox.Show("Last Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();                       
                        return;
                    }

                    List<Employee> employeesLn = new List<Employee>();
                    employeesLn = employee.SearchEmpLastName(lname);

                    if (employeesLn != null && employeesLn.Count > 0)
                    {
                        GridViewEmployee.DataSource = employeesLn;
                        GridViewEmployee.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Employee not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();                       
                        return;
                    }
                    break;

                case "First and Last Name":

                    string name1 = TextBoxInput.Text.Trim();
                    string name2 = TextBoxInputLastName.Text.Trim();
                    if (!Validator.IsValidName(name1))
                    {
                        MessageBox.Show("First Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInput.Focus();
                        return;

                    }else if (!Validator.IsValidName(name2))
                    {
                        MessageBox.Show("Last Name must contain only letters.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInputLastName.Text = string.Empty;
                        TextBoxInputLastName.Visible = true;
                        TextBoxInputLastName.Focus();
                        return;
                    }

                    List<Employee> employeesN = new List<Employee>();
                    employeesN = employee.SearchEmpName(name1, name2);
                    TextBoxInput.Text = string.Empty;
                    TextBoxInputLastName.Text = string.Empty;
                    TextBoxInputLastName.Visible = true;
                    LabelLastName.Visible = true;

                    if (employeesN != null && employeesN.Count > 0)
                    {
                        GridViewEmployee.DataSource = employeesN;
                        GridViewEmployee.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Employee not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = string.Empty;
                        TextBoxInputLastName.Text = string.Empty;
                        TextBoxInputLastName.Visible = true;
                        LabelLastName.Visible = true;
                        TextBoxInput.Focus();
                        return;
                    }
                    break;
            }


        }

       
    }
}