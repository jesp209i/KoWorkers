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
using System.Data;

namespace KoWorkerGui.CheckIn
{
    /// <summary>
    /// Interaction logic for CheckInAndOut_Page.xaml
    /// </summary>
    public partial class CheckInAndOut_Page : Page
    {
        private static CheckInAndOut_Page instance = null;
        private CheckInAndOut_Page()
        {
            InitializeComponent();
            DataContext = Controller.GetInstance();
        }
        public static CheckInAndOut_Page GetInstance()
        {
            if (instance == null)
            {
                instance = new CheckInAndOut_Page();
                
            }
            instance.CheckedInOut_ListView.Items.Refresh();
            return instance;
            
        }
        private void GetEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            int pin = int.Parse(PinCode_PassBox.Password);
            message = Controller.GetInstance().UpdateCheckInStatus(pin);       
            MessageBox.Show(message, "KoWorkers");
            CheckedInOut_ListView.Items.Refresh();
        }
        private void ShowInfo_DoubleClick(object sender, RoutedEventArgs e)
        {
            ShowInfo_Window();
        }
        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {
            ShowInfo_Window();
        }
        private void ShowInfo_Window()
        {
            ShowInformation_Window showInformation_Window = new ShowInformation_Window();
            showInformation_Window.DataContext = Controller.GetInstance().CurrentEmployee;
            App.Current.MainWindow = showInformation_Window;
            showInformation_Window.Show();
        }
       
    }
}

