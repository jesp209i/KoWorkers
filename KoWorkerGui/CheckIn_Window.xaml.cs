using System;
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
using KoWorkers;

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for CheckIn_Window.xaml
    /// </summary>
    public partial class CheckIn_Window : Window
    {
        Controller C;
        EmployeeRepository ep;
        public CheckIn_Window()
        {
            InitializeComponent();
            C = new Controller();
            ep = new EmployeeRepository();
            
            foreach (Employee employee in ep.employees)
            {
                string prettyEmployeeString = employee.GetName() + " id: " + employee.EmployeeId + ". Shift: "  + employee.GetOpenShift() + " PIN: " + employee.PinCode;
                if (employee.GetOpenShift() == -1)
                {
                    EmployeesCheckOutListBox.Items.Add(prettyEmployeeString);
                }
                else
                {
                    EmployeesCheckInListBox.Items.Add(prettyEmployeeString);
                }
                

            }
            
        }

        
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            App.Current.MainWindow = Main;
            this.Close();
            Main.Show();
        }

        private void GetEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            int pin = int.Parse(PinCode_PassBox.Password);
            C.CheckInByPin(pin);
         

        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {
            Employee showEmplo = ep.employees[EmployeesCheckInListBox.SelectedIndex];
            ShowInformation_Window showInformation_Window = new ShowInformation_Window();
            showInformation_Window.FirstName_Button.Text = showEmplo.FirstName;
            showInformation_Window.LastName_Button.Text = showEmplo.LastName;
            showInformation_Window.TelephoneNo_Button.Text = showEmplo.GetTelephoneNO().ToString();
            App.Current.MainWindow = showInformation_Window;
            showInformation_Window.Show();
        }
    }
}
