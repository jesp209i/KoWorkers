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
    /// Interaction logic for RemoveEmployee_Window.xaml
    /// </summary>
    public partial class RemoveEmployee_Window : Window
    {
        Controller C;
        EmployeeRepository ep;
        public RemoveEmployee_Window()
        {
            InitializeComponent();
            C = new Controller();
            ep = new EmployeeRepository();
        }

        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            Employee removeEmplo = ep.employees[RemoveEmployees_ListBox.SelectedIndex];            
            C.RemoveEmployee(removeEmplo);

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Coworker_Window coworker_Window = new Coworker_Window();
            App.Current.MainWindow = coworker_Window;
            this.Close();
            coworker_Window.Show();
        }

        private void RemoveEmployees_ListBox_SelectionChanced(object sender, SelectionChangedEventArgs e)
        {
            ShowSelected_Label.Content = ep.employees[RemoveEmployees_ListBox.SelectedIndex].FirstName;
        }
    }
}
