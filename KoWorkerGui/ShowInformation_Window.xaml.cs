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
using System.Windows.Shapes;

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for ShowInformation_Window.xaml
    /// </summary>
    public partial class ShowInformation_Window : Window
    {
        public ShowInformation_Window()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckIn_Window Main = new CheckIn_Window();
            App.Current.MainWindow = Main;
            this.Close();
            Main.Show();
        }
    }
}