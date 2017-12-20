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
    /// Interaction logic for UpdateEmployee_Page.xaml
    /// </summary>
    public partial class UpdateEmployee_Page : Page
    {
        Controller C;
        public UpdateEmployee_Page()
        { C = new Controller();

            InitializeComponent();
            UpdateEmployees_ListBox.Items.Clear();
            UpdateEmployees_ListBox.ItemsSource = C.GetAllEmployees();
        }
        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            int idx = UpdateEmployees_ListBox.SelectedIndex;           
            UpdateEmployee_Window updateEmployee_Window = new UpdateEmployee_Window();
           updateEmployee_Window.ShowSelectedEmployee(idx);
            App.Current.MainWindow = updateEmployee_Window;
            updateEmployee_Window.Show();
         
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CoWorker_page.xaml", UriKind.Relative));
        }

        private void UpdateEmployees_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmployees_ListBox.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
        }
    
            
      
    }

}
