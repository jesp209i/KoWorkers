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
        Controller C;
        public RemoveEmployee_page()
        {
            InitializeComponent();
            C = new Controller();
            RemoveEmployees_ListBox.Items.Clear();
            RemoveEmployees_ListBox.ItemsSource = C.GetAllEmployees();
        }
        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            int idx = RemoveEmployees_ListBox.SelectedIndex;
            C.RemoveEmployeeToGui(idx);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CoWorker_page.xaml", UriKind.Relative));
        }

        private void RemoveEmployees_ListBox_SelectionChanced(object sender, SelectionChangedEventArgs e)
        {
            //ShowSelected_Label.Content = ep.employees[RemoveEmployees_ListBox.SelectedIndex].FirstName;
        }
    }
}
