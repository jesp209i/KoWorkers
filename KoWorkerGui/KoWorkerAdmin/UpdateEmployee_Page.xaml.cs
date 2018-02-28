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
    /// Interaction logic for UpdateEmployee_Page.xaml
    /// </summary>
    public partial class UpdateEmployee_Page : Page
    {
        Controller controller;
        private static UpdateEmployee_Page instance = null;
        private UpdateEmployee_Page()
        {
            controller = Controller.GetInstance();
            InitializeComponent();
            DataContext = controller;
        }
        public static UpdateEmployee_Page GetInstance()
        {
            if (instance== null)
            {
                instance = new UpdateEmployee_Page();
            }
            return instance;
        }
        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            int idx = UpdateEmployees_ListBox.SelectedIndex;           
            UpdateEmployee_Window updateEmployee_Window = new UpdateEmployee_Window();
            updateEmployee_Window.DataContext = controller.CurrentEmployee;
            App.Current.MainWindow = updateEmployee_Window;
            updateEmployee_Window.Show();
         
        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee_Window addEmployee = new AddEmployee_Window();
            App.Current.MainWindow = addEmployee;
            addEmployee.Show();
        }
        private void RemoveEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil fjerne: " + controller.CurrentEmployee.FullName + "?", "Bekræft venligst", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    controller.RemoveEmployee(controller.CurrentEmployee);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Medarbejderen blev ikke fjernet", "KoWorker");
                    break;
            }
        }
    }

}
