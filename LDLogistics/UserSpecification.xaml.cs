using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace LDLogistics
{
    /// <summary>
    /// Interaction logic for UserSpecification.xaml
    /// </summary>
    public partial class UserSpecification : Window
    {
        // Used to  specify user and store in specified database
        private void filldata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-07GSTEC8\SQLEXPRESS;Initial Catalog=LDLogistics;Integrated Security=True");
            connection.Open();
            string query;
           
            if (comboBox.SelectedIndex.Equals(0))
            {
                heading.Content = ("HELLO OFFICE MANAGER");
                query = "INSERT INTO OfficeManager(OfficeManagerID,Name,Surname) values(@OfficeManagerID,@Name,@Surname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OfficeManagerID",UserID_txtbox.Text);
                command.Parameters.AddWithValue("@Name", Name_txtbox.Text);
                command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else if (comboBox.SelectedIndex.Equals(1))
            {
                heading.Content = ("HELLO TIMESHEET MANAGER");
                query = "INSERT INTO TimesheetManager(TimesheetManagerID,Name,Surname) values(@TimesheetManagerID,@Name,@Surname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TimesheetManagerID", UserID_txtbox.Text);
                command.Parameters.AddWithValue("@Name", Name_txtbox.Text);
                command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else if (comboBox.SelectedIndex.Equals(2))
            {
                heading.Content = ("HELLO SERVICE MANAGER");
                query = "INSERT INTO ServiceManager(ServiceManagerId,Name,Surname) values(@ServiceManagerId,@Name,@Surname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceManagerId", UserID_txtbox.Text);
                command.Parameters.AddWithValue("@Name", Name_txtbox.Text);
                command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else if (comboBox.SelectedIndex.Equals(3))
            {
                heading.Content = ("HELLO VEHICLE INFOMATION ADMINISTRATOR");
                query = "INSERT INTO VehicleInfomationAdministrator(ID,Name,Surname) values(@ID,@Name,@Surname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", UserID_txtbox.Text);
                command.Parameters.AddWithValue("@Name", Name_txtbox.Text);
                command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else if (comboBox.SelectedIndex.Equals(4))
            {
                heading.Content = ("HELLO TRIP MANAGER");
                query = "INSERT INTO TripManager(TripManagerID,Name,Surname) values(@TripManagerID,@Name,@Surname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TripManagerID", UserID_txtbox.Text);
                command.Parameters.AddWithValue("@Name", Name_txtbox.Text);
                command.Parameters.AddWithValue("@Surname", Surname_txtbox.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            




        }

        public UserSpecification()
        {
            InitializeComponent();

        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            filldata();
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void EXIT_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Hide();
        }
       
    }
}
