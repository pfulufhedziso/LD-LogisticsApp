﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LDLogistics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            UserSpecification obj = new UserSpecification();
            obj.Show();
            Hide();
        }

        private void EXIT_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
