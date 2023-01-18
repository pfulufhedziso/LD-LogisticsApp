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
    /// Interaction logic for Trip.xaml
    /// </summary>
    public partial class Trip : Window
    {
        private void ADDMore()
        {

            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "INSERT INTO Trip(VehicleNumber,Destination,DistanceInKilometers,TripManagerID,ActualKilometersTravelled) values(@VehicleNumber,@Destination,@DistanceInKilometers,@TripManagerID,@ActualKilometersTravelled)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehcileNumber_txtbox.Text);
            command.Parameters.AddWithValue("@Destination", Des_txtbox.Text);
            command.Parameters.AddWithValue("@DistanceInKilometers", Travelled_txtbox.Text);
            command.Parameters.AddWithValue("@ActualKilometersTravelled", HaveTravelled_txtbox_.Text);
            command.Parameters.AddWithValue("@TripManagerID", ID_txtbox.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        // this method will be use to display data on a datagrid
        private void DailyPlanned()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            

            string CmdString = string.Empty;
            CmdString = "SELECT TripManagerID,VehicleNumber,Destination,DistanceInKilometers   FROM Trip";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Trip");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // Used  to display dail complete report
        private void DailyCompleted()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string CmdString = string.Empty;
            CmdString = "SELECT TripManagerID,VehicleNumber,Destination,ActualKilometersTravelled  FROM Trip";
            SqlCommand cmd = new SqlCommand(CmdString, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Trip");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        // Used to update records
        private void Update()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "UPDATE Trip SET Destination=@Destination,DistanceInKilometers=@DistanceInKilometers,TripManagerID=@TripManagerID,ActualKilometersTravelled=@ActualKilometersTravelled WHERE VehicleNumber = '" + this.VehcileNumber_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehcileNumber_txtbox.Text);
            command.Parameters.AddWithValue("@Destination", Des_txtbox.Text);
            command.Parameters.AddWithValue("@DistanceInKilometers", Travelled_txtbox.Text);
            command.Parameters.AddWithValue("@ActualKilometersTravelled", HaveTravelled_txtbox_.Text);
            command.Parameters.AddWithValue("@TripManagerID", ID_txtbox.Text);
            
            command.ExecuteNonQuery();
            connection.Close();
        }
        //Used to delete records
        private void Delete()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query = "DELETE Trip WHERE VehicleNumber = '" + this.VehcileNumber_txtbox.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VehicleNumber", VehcileNumber_txtbox.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public Trip()
        {
            InitializeComponent();
        }
        // BUTTON FOR DISPLAYING Daily planned trip report
        private void DisplayAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            DailyPlanned();
        }
        // BUTTON FOR DISPLAYING Daily planned trip report
        private void SpecficService_btn_Click(object sender, RoutedEventArgs e)
        {
            DailyCompleted();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            ADDMore();
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            VehcileNumber_txtbox.Clear();
            Des_txtbox.Clear();
            Travelled_txtbox.Clear();
            HaveTravelled_txtbox_.Clear();
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
