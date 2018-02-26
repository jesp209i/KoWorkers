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
    /// Interaction logic for AddWorkSchedule_Page.xaml
    /// </summary>
    public partial class AddWorkSchedule_Page : Page
    {
        Controller control;
        public AddWorkSchedule_Page()
        {
            control = Controller.GetInstance();
            InitializeComponent();
            AddWorkSchedule_datagrid.ItemsSource = control.GetAllEmployees();
        }

        private void SetMonthAndYear_Button_Click(object sender, RoutedEventArgs e)
        {
            SetDate_Window sdw = new SetDate_Window();
            App.Current.MainWindow = sdw;
           sdw.Show();
        }
    }
}
