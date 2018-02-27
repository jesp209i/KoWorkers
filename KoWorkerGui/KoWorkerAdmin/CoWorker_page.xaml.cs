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
namespace KoWorkerGui.KoWorkerAdmin
{
    /// <summary>
    /// Interaction logic for CoWorker_page.xaml
    /// </summary>
    public partial class CoWorker_page : Page
    {
        Controller control;
        private static CoWorker_page instance = null;
        private CoWorker_page()
        {
            InitializeComponent();
            control = Controller.GetInstance();
        }
        public static CoWorker_page GetInstance()
        {
            if (instance == null)
            {
                instance = new CoWorker_page();
            }
            return instance;
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee_Window addEmployee = new AddEmployee_Window();
            App.Current.MainWindow = addEmployee;
            addEmployee.Show();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Welcome_page.xaml", UriKind.Relative));
        }

        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("KoWorkerAdmin/RemoveEmployee_page.xaml", UriKind.Relative));
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("KoWorkerAdmin/UpdateEmployee_page.xaml", UriKind.Relative));
        }
    }
}
