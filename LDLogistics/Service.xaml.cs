using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Microsoft.VisualBasic;
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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Window
    {
        // used to add infomation to database
        private void addMore()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "INSERT INTO Service(VehicleNumber,AppointmentTime,AppointmentDate,ServiceToBePerformed,ProcedureCode,Description,Cost,ServiceManagerID) values(@VehicleNumber,@AppointmentTime,@AppointmentDate,@ServiceToBePerformed,@ProcedureCode,@Description,@Cost,@ServiceManagerID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);
            command.Parameters.AddWithValue("@AppointmentTime", Time_txtbox.Text);
            command.Parameters.AddWithValue("@AppointmentDate", Date_txtbox_.Text);
            command.Parameters.AddWithValue("@ServiceToBePerformed", ServiceType_txtbox.Text);
            command.Parameters.AddWithValue("@ProcedureCode", PCode_txtbox.Text);
            command.Parameters.AddWithValue("@Description", Description_txtbox.Text);
            command.Parameters.AddWithValue("@Cost", Cost_txtbox.Text);
            command.Parameters.AddWithValue("@ServiceManagerID", ID_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        // this method will be use to display data on a datagrid
        private void FillDataGrid()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
           

            string CmdString = string.Empty;
            CmdString = "SELECT ServiceManagerID,VehicleNumber,AppointmentTime,ServiceToBePerformed,ProcedureCode,Description,Cost  FROM Service";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Service");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // this will display service requirments report on data grid
        private void ServiceRequirmentsReport()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "SELECT VehicleNumber,AppointmentTime,AppointmentDate,ServiceToBePerformed AS ServiceType,ProcedureCode,Description AS WorkToBeCompleted FROM Service";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Service");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // this will display s Yearly Report on data grid
        private void YearlyReport()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "SELECT VehicleNumber,ServiceToBePerformed AS ServiceDone,Cost FROM Service";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Service");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // this will display Specific Service Report data grid
        private void SpecificServiceReport()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "SELECT VehicleNumber,Description AS ServiceInformation,Cost FROM Service";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Service");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();

        }
        // Used to update records
        private void Update()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "UPDATE Service SET AppointmentTime=@AppointmentTime,AppointmentDate=@AppointmentDate,ServiceToBePerformed=@ServiceToBePerformed,ProcedureCode=@ProcedureCode,Description=@Description,Cost=@Cost,ServiceManagerID=@ServiceManagerID WHERE VehicleNumber = '" + this.VehicleNumber_txtbox.Text+ "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);
            command.Parameters.AddWithValue("@AppointmentTime", Time_txtbox.Text);
            command.Parameters.AddWithValue("@AppointmentDate", Date_txtbox_.Text);
            command.Parameters.AddWithValue("@ServiceToBePerformed", ServiceType_txtbox.Text);
            command.Parameters.AddWithValue("@ProcedureCode", PCode_txtbox.Text);
            command.Parameters.AddWithValue("@Description", Description_txtbox.Text);
            command.Parameters.AddWithValue("@Cost", Cost_txtbox.Text);
            command.Parameters.AddWithValue("@ServiceManagerID", ID_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        // used to delete records
        private void Delete()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "DELETE Service WHERE VehicleNumber = '" + this.VehicleNumber_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);
           
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Service()
        {
            InitializeComponent();
        }
        // button is used to display Daily and weekly service appointment list
        private void DisplayAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
        //button is used to display Service requirement job sheet
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequirmentsReport();
        }
        //button is used to display Yearly report for service complete
        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            YearlyReport();
        }
        //button is used to display Specific service report
        private void SpecficService_btn_Click(object sender, RoutedEventArgs e)
        {
            SpecificServiceReport();
        }

        private void Back_btn_Click_1(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            addMore();
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            VehicleNumber_txtbox.Clear();
            Time_txtbox.Clear();
            Date_txtbox_.Clear();
            ServiceType_txtbox.Clear();
            PCode_txtbox.Clear();
            Description_txtbox.Clear();
            Cost_txtbox.Clear();
            ID_txtbox.Clear();
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
