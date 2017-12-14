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
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            Coworker_Window coworker_Window = new Coworker_Window();
            App.Current.MainWindow = coworker_Window;
            this.Close();
            coworker_Window.Show();


        }

        private void TjekInd_Ud_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckIn_Window CheckIn_Window = new CheckIn_Window();
            App.Current.MainWindow = CheckIn_Window;
            this.Close();
            CheckIn_Window.Show();
        }
    }
}
