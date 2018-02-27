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

namespace KoWorkerGui.WorkSchedule
{
    /// <summary>
    /// Interaction logic for AddWorkSchedule_Page.xaml
    /// </summary>
    public partial class AddWorkSchedule_Page : Page
    {
        Controller control;
       
        
        public AddWorkSchedule_Page()
        {
            control = Controller.GetInstance();
            InitializeComponent();
            List<Employee> employeeList = control.Employees;
            DataContext = employeeList;
            AddWorkSchedule_datagrid.ItemsSource = employeeList;
        }

        private void Cell_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            AddShift_Window asw = new AddShift_Window();
            App.Current.MainWindow = asw;
            asw.Show();
        }
        private void SetMonthAndYear_Button_Click(object sender, RoutedEventArgs e)
        {
           // SetDate_Window sdw = new SetDate_Window(this);
           // App.Current.MainWindow = sdw;
           //sdw.Show();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WorkSchedule_Page", UriKind.Relative));
        }
    }
}
