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

namespace KoWorkerGui.WorkSchedule
{
    /// <summary>
    /// Interaction logic for WorkSchedule_Page.xaml
    /// </summary>
    public partial class WorkSchedule_Page : Page
    {
        private static WorkSchedule_Page instance = null;
        private WorkSchedule_Page()
        {
            InitializeComponent();
        }
        public static WorkSchedule_Page GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkSchedule_Page();
            }
            return instance;
        }

        private void CreateWorkschedule_Button_Click(object sender, RoutedEventArgs e)
        {
            SetDate_Window sdw = new SetDate_Window(this);
            App.Current.MainWindow = sdw;
            sdw.Show();
        }
    }
}
