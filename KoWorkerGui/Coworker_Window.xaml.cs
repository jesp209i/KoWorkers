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

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for Coworker_Window.xaml
    /// </summary>
    public partial class Coworker_Window : Window
    {
        public Coworker_Window()
        {
            InitializeComponent();
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

        }
    }
}
