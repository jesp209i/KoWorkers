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
    /// Interaction logic for Coworker_Window.xaml
    /// </summary>
    public partial class Coworker_Window : Window
    {
        EmployeeRepository ep;
        public Coworker_Window()
        {
            InitializeComponent();
            ep = new EmployeeRepository();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee_Window addEmployee = new AddEmployee_Window();
            App.Current.MainWindow = addEmployee;
            this.Close();
            addEmployee.Show();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            App.Current.MainWindow = Main;
            this.Close();
            Main.Show();
        }

        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            
            RemoveEmployee_Window Remove = new RemoveEmployee_Window();
            App.Current.MainWindow = Remove;
            foreach(Employee employee in ep.employees)
            {
                Remove.RemoveEmployees_ListBox.Items.Add(employee.EmployeeId + ". " + employee.GetName() + " Tlf: " + employee.GetTelephoneNO());
            }
            this.Close();
            Remove.Show();        
        }
    }
}
