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
using KoWorkers;

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for CheckInAndOut_Page.xaml
    /// </summary>
    public partial class CheckInAndOut_Page : Page
    {
        Controller C;
        EmployeeRepository ep;
        public CheckInAndOut_Page()
        {
            InitializeComponent();
            C = new Controller();
            ep = new EmployeeRepository();

            foreach (string employee in C.EmployeeListToCheckInToGui())
            {
                EmployeesCheckInListBox.Items.Add(employee);
            }
            foreach (string employee in C.EmployeeListToCheckOutToGui())
            {
                EmployeesCheckOutListBox.Items.Add(employee);
            }
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Welcome_page.xaml", UriKind.Relative));
        }

        private void GetEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            int pin = int.Parse(PinCode_PassBox.Password);
            message = C.ShowCheckInOutMessageInGui(pin);       
            MessageBox.Show(message, "KoWorkers");
            EmployeesCheckInListBox.Items.Clear();
            EmployeesCheckOutListBox.Items.Clear();
            foreach (string employees in C.EmployeeListToCheckInToGui())
            {
                EmployeesCheckInListBox.Items.Add(employees);
            }
            foreach (string employees in C.EmployeeListToCheckOutToGui())
            {
                EmployeesCheckOutListBox.Items.Add(employees);
            }
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {
            Employee showEmplo = ep.employees[EmployeesCheckOutListBox.SelectedIndex];
            ShowInformation_Window showInformation_Window = new ShowInformation_Window();
            showInformation_Window.FirstName_Button.Text = showEmplo.FirstName;
            showInformation_Window.LastName_Button.Text = showEmplo.LastName;
            showInformation_Window.TelephoneNo_Button.Text = showEmplo.GetTelephoneNO().ToString();
            App.Current.MainWindow = showInformation_Window;
            showInformation_Window.Show();
        }

        private void EmployeesCheckOutListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

