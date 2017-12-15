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
    /// Interaction logic for CoWorker_page.xaml
    /// </summary>
    public partial class CoWorker_page : Page
    {
        Controller c;
        public CoWorker_page()
        {
            InitializeComponent();
            c = new Controller();
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
            this.NavigationService.Navigate(new Uri("RemoveEmployee_page.xaml", UriKind.Relative));
            RemoveEmployee_Window Remove = new RemoveEmployee_Window();
            App.Current.MainWindow = Remove;
            Remove.Show();


        }
    }
}
