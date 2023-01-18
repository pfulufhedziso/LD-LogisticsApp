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

namespace LDLogistics
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Vehicle_btn_Click(object sender, RoutedEventArgs e)
        {
            Vehicle obj = new Vehicle();
            obj.Show();
            this.Hide();
        }

        private void Service_btn_Click(object sender, RoutedEventArgs e)
        {
            Service obj = new Service();
            obj.Show();
            this.Hide();
        }

        private void Trip_btn_Click(object sender, RoutedEventArgs e)
        {
            Trip obj = new Trip();
            obj.Show();
            this.Hide();
        }

       

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            UserSpecification obj = new UserSpecification();
            obj.Show();
            this.Hide();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Timesheet_btn_Click(object sender, RoutedEventArgs e)
        {
            Timesheet obj = new Timesheet();
            obj.Show();
            this.Hide();
        }
    }
}
