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
    /// Interaction logic for Welcome_page.xaml
    /// </summary>
    public partial class Welcome_page : Page
    {
        public Welcome_page()
        {
            InitializeComponent();
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CoWorker_page.xaml", UriKind.Relative));
            


        }

        private void TjekInd_Ud_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CheckInAndOut_page.xaml", UriKind.Relative));
        }

        private void WorkSchedule_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WorkSchedule_page.xaml", UriKind.Relative));
        }
    }
}
