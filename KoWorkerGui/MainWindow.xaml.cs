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

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    using KoWorkers;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(CheckIn.CheckInAndOut_Page.GetInstance());
        }
        private void MnuCheckIn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(CheckIn.CheckInAndOut_Page.GetInstance());
        }
        private void MnuWorkPlan_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(WorkSchedule.WorkSchedule_Page.GetInstance());
        }
        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MnuWorkerAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(KoWorkerAdmin.UpdateEmployee_Page.GetInstance());
        }
        private void MnuAbout_Click(object sender,RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            App.Current.MainWindow = aboutWindow;
            aboutWindow.Show();
        }
    }
}
