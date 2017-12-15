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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KoWorkers;

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for RemoveEmployee_page.xaml
    /// </summary>
    public partial class RemoveEmployee_page : Page
    {
        EmployeeRepository ep;
        Controller C;
        public RemoveEmployee_page()
        {
            InitializeComponent();
            ep = new EmployeeRepository();
            C = new Controller();
           

            foreach (string employee in C.EmployeeListToGui())
            {
                RemoveEmployees_ListBox.Items.Add(employee);
            }
        }
        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            Employee removeEmplo = ep.employees[RemoveEmployees_ListBox.SelectedIndex];
            C.RemoveEmployee(removeEmplo);

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CoWorker_page.xaml", UriKind.Relative));
            RemoveEmployees_ListBox.Items.Clear();
        }

        private void RemoveEmployees_ListBox_SelectionChanced(object sender, SelectionChangedEventArgs e)
        {
            ShowSelected_Label.Content = ep.employees[RemoveEmployees_ListBox.SelectedIndex].FirstName;
        }
    }
}
