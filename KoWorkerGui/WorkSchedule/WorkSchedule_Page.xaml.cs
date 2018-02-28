using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace KoWorkerGui.WorkSchedule
{
    /// <summary>
    /// Interaction logic for WorkSchedule_Page.xaml
    /// </summary>
    public partial class WorkSchedule_Page : Page
    {
        private static WorkSchedule_Page instance = null;
        KoWorkers.WorkSchedule.ViewModel.WorkScheduleViewModel wsvm;
        public List<KoWorkers.WorkSchedule.ViewModel.WorkScheduleViewModel.WorkScheduleShiftViewModel> viewList;
        private DateTime startTime;
        private DateTime endTime;
        public DateTime StartTime { get { return startTime; } set { startTime = value; } }
        public DateTime EndTime { get { return endTime; } set { endTime = value; } }
        Controller control;
        private WorkSchedule_Page()
        {
            control = Controller.GetInstance();
            wsvm = KoWorkers.WorkSchedule.ViewModel.WorkScheduleViewModel.GetInstance();
            InitializeComponent();
            List<Employee> employeeList = control.Employees;
           // DataContext = employeeList;

             viewList = wsvm.ListForViewModel;
            DataContext = viewList;
            AddWorkSchedule_datagrid.ItemsSource = viewList;
            
            
            
        }
        public static WorkSchedule_Page GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkSchedule_Page();
            }
            return instance;
        }

        private void Cell_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddShift_Window asw = new AddShift_Window();
            App.Current.MainWindow = asw;
            asw.Show();
        }

        private void CreateWorkschedule_Button_Click(object sender, RoutedEventArgs e)
        {

            SetDate_Window sdw = new SetDate_Window(this);
            App.Current.MainWindow = sdw;
            sdw.Show();
            startTime = sdw.StartTime;
           
           
        }

        public int StartWeekNumber()
        {
            
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                System.Globalization.Calendar cal = dfi.Calendar;
                return cal.GetWeekOfYear(StartTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            
        }

        public int EndWeekNumber()
        {

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(EndTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
           

        }

        private void PickWeek_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int startdate = PickWeek_ComboBox.SelectedIndex + StartWeekNumber();
        }

       
    }
}
