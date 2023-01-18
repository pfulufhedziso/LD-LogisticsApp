using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LDLogistics
{
    /// <summary>
    /// Interaction logic for Timesheet.xaml
    /// </summary>
    public partial class Timesheet : Window
    {
        // used to add information to the database
        private void addMore()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "INSERT INTO Employee(EmployeeID,Name,Surname,Position) values(@EmployeeID,@Name,@Surname,@Position)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmID_txtbox.Text);
            command.Parameters.AddWithValue("@Name", EmName_txtbox.Text);
            command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
            command.Parameters.AddWithValue("@Position", EmPosition_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();

        }
        // used to add information to the database
        private void addMore2()
 {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            
            string query = "INSERT INTO DailyTimesheetReport(EmployeeID,HoursWorks,TimesheetManagerID) values(@EmployeeID,@HoursWorks,@TimesheetManagerID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmID_txtbox.Text);
            command.Parameters.AddWithValue("@HoursWorks", Hours_txtbox.Text);
            command.Parameters.AddWithValue("@TimesheetManagerID", TmID_txtbox.Text);

            command.ExecuteNonQuery();
            connection.Close();

        }
        // used to display Employee database on to datagrid
        private void DisplayEmployee()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();


            string CmdString = string.Empty;
            CmdString = "SELECT *  FROM Employee";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Employee");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
          
            connection.Close();
        }
        // used to display DailyTimesheetReport database on to datagrid
        private void displayTimesheet()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();


            string CmdString = string.Empty;
            CmdString = "SELECT *  FROM DailyTimesheetReport";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("DailyTimesheetReport");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // used to update records
        private void Update1()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "UPDATE Employee SET EmployeeID=@EmployeeID,Name=@Name,Surname=@Surname,Position=@Position WHERE EmployeeID = '" + this.EmID_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmID_txtbox.Text);
            command.Parameters.AddWithValue("@Name", EmName_txtbox.Text);
            command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
            command.Parameters.AddWithValue("@Position", EmPosition_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        // used to delete records
        private void Delete()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "DELETE Employee WHERE VehicleNumber = '" + this.EmID_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", EmID_txtbox.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public Timesheet()
        {
            InitializeComponent();
        }

        private void Employee_btn_Click(object sender, RoutedEventArgs e)
        {
            DisplayEmployee();
        }

        private void Timesheet_btn_Click(object sender, RoutedEventArgs e)
        {
            displayTimesheet();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            addMore();
            addMore2();
        }

        private void Back_btn_Click_1(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            EmID_txtbox.Clear();
            EmName_txtbox.Clear();
            Surname_txtbox.Clear();
            EmPosition_txtbox.Clear();
            Hours_txtbox.Clear();
            TmID_txtbox.Clear();
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            Update1();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
