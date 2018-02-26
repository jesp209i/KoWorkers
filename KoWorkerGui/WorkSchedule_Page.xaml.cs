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
    /// Interaction logic for WorkSchedule_Page.xaml
    /// </summary>
    public partial class WorkSchedule_Page : Page
    {
        public WorkSchedule_Page()
        {
            InitializeComponent();
        }

        private void CreateWorkschedule_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddWorkSchedule_page.xaml", UriKind.Relative));
        }
    }
}
