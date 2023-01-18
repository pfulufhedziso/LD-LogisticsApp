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
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Window
    {
        // this method will be use to display data on a datagrid
        private void FillDataGrid()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "INSERT INTO Vehicle(VehicleNumber,Registration,VehicleType,Manufacturer,EngineSize,CurrentOdmeterReading,NextServiceOdmeterReading,VIAID) values(@VehicleNumber,@Registration,@VehicleType,@Manufacturer,@EngineSize,@CurrentOdmeterReading,@NextServiceOdmeterReading,@VIAID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);
            command.Parameters.AddWithValue("@Registration", Reg_txtbox.Text);
            command.Parameters.AddWithValue("@VehicleType", Type_txtbox.Text);
            command.Parameters.AddWithValue("@Manufacturer", Manu_txtbox.Text);
            command.Parameters.AddWithValue("@EngineSize", Engine_txtbox.Text);
            command.Parameters.AddWithValue("@CurrentOdmeterReading", CurrentOD_txtbox.Text);
            command.Parameters.AddWithValue("@NextServiceOdmeterReading", NextOD_txtbox.Text);
            command.Parameters.AddWithValue("@VIAID", AdminID_txtbox.Text);
            command.ExecuteNonQuery();          
            connection.Close();
        }
        // Used to display Vehicle status report on data gride
        private void Report()
        {

            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "SELECT VIAID,VehicleNumber,Registration,VehicleType,Manufacturer,EngineSize,CurrentOdmeterReading,NextServiceOdmeterReading  FROM Vehicle";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Vehicle");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // Used to update records
        private void Update()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "UPDATE Vehicle SET Registration=@Registration,VehicleType=@VehicleType,Manufacturer=@Manufacturer,EngineSize=@EngineSize,CurrentOdmeterReading=@CurrentOdmeterReading,NextServiceOdmeterReading=@NextServiceOdmeterReading,VIAID=@VIAID WHERE VehicleNumber = '" + this.VehicleNumber_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);
            command.Parameters.AddWithValue("@Registration", Reg_txtbox.Text);
            command.Parameters.AddWithValue("@VehicleType", Type_txtbox.Text);
            command.Parameters.AddWithValue("@Manufacturer", Manu_txtbox.Text);
            command.Parameters.AddWithValue("@EngineSize", Engine_txtbox.Text);
            command.Parameters.AddWithValue("@CurrentOdmeterReading", CurrentOD_txtbox.Text);
            command.Parameters.AddWithValue("@NextServiceOdmeterReading", NextOD_txtbox.Text);
            command.Parameters.AddWithValue("@VIAID", AdminID_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        // Used to delete
        private void Delete()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "DELETE Vehicle WHERE VehicleNumber = '" + this.VehicleNumber_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber_txtbox.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public Vehicle()
        {
            InitializeComponent();
        }

        private void DisplayAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Report_btn_Click(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            VehicleNumber_txtbox.Clear();
            Reg_txtbox.Clear();
            Type_txtbox.Clear();
            Manu_txtbox.Clear();
            Engine_txtbox.Clear();
            CurrentOD_txtbox.Clear();
            NextOD_txtbox.Clear();
            AdminID_txtbox.Clear();
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
