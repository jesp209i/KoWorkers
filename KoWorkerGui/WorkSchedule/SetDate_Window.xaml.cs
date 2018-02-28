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
using KoWorkers;
namespace KoWorkerGui.WorkSchedule
{
    /// <summary>
    /// Interaction logic for SetDate_Window.xaml
    /// </summary>
    public partial class SetDate_Window : Window
    {
        WorkSchedule_Page main;
        Controller control; 
        public SetDate_Window(WorkSchedule_Page workSchedule_Page)
        {
            main = workSchedule_Page;
            control = Controller.GetInstance();
            InitializeComponent();
            FillComboBoxes();
        }
        private DateTime startTime;
        public DateTime StartTime { get { return startTime; } set { startTime = value; } }
        private void FillComboBoxes()
        {
            string[] years = new string[] { "2018", "2017", "2016", "2015" };
            string[] months = new string[] { "Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December" };
            foreach (string month in months)
            { SetMonth_ComboBox.Items.Add(month); }
            foreach (string year in years)
            { SetYear_ComboBox.Items.Add(year); }
        }

        private void Set_Button_Click(object sender, RoutedEventArgs e)
        {
            int month = -1;
            int year = -1;
            month = SetMonth_ComboBox.SelectedIndex + 1;
            if (month == 0 && year == -1)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
            }
            else
            {
                year = int.Parse(SetYear_ComboBox.SelectedItem.ToString());
            }

            startTime = new DateTime(year, month, 1);
            main.StartTime = startTime;
            main.EndTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
         
           
            control.AddNewScheduleToGui(year, month);
            //main.NavigationService.Navigate(new Uri("WorkSchedule/AddWorkSchedule_page.xaml", UriKind.Relative));
            main.Month_Label.Content = startTime.Month.ToString();
            main.EndDay_label.Content = main.EndTime.Date.ToShortDateString();
            main.Year_label.Content = main.StartTime.Year.ToString();
            main.StartDay_label.Content = main.StartTime.Date.ToString();
            this.Close();
        }

     
    }
}
