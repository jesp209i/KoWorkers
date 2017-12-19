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

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for CheckInAndOut_Page.xaml
    /// </summary>
    public partial class CheckInAndOut_Page : Page
    {
        Controller C;
        public CheckInAndOut_Page()
        {
            InitializeComponent();
            C = new Controller();
            CheckedInOut_ListView.ItemsSource = C.GetAllEmployees();
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Welcome_page.xaml", UriKind.Relative));
        }

        private void GetEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            int pin = int.Parse(PinCode_PassBox.Password);
            message = C.ShowCheckInOutMessageInGui(pin);       
            MessageBox.Show(message, "KoWorkers");
            CheckedInOut_ListView.Items.Refresh();
        }
        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {                   
            ShowInformation_Window showInformation_Window = new ShowInformation_Window();
            int idx = CheckedInOut_ListView.SelectedIndex;
            showInformation_Window.ShowSelectedEmployee(idx);
            App.Current.MainWindow = showInformation_Window;
            showInformation_Window.Show();
        }
       
    }
}

