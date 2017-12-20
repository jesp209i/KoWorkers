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

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for ShowInformation_Window.xaml
    /// </summary>
    public partial class ShowInformation_Window : Window
    {
        Controller C;
        public ShowInformation_Window()
        {
            CheckInAndOut_Page check = new CheckInAndOut_Page();
            InitializeComponent();
            C = new Controller();
            FillComboBoxes();
        }
        int Idx { get; set; }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }
        private void FillComboBoxes()
        {
            string[] years = new string[] { "2017", "2016", "2015", "2014" };
            string[] months = new string[] { "Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December" };
            foreach (string month in months)
            { MonthComboBox.Items.Add(month); }
            foreach (string year in years)
            { YearComboBox.Items.Add(year); }
        }

        private void MonthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showCalculatedHours();   
        }
        public void SetIndexNumber(int idx)
        {
            Idx = idx;
        }

        public int GetIdx()
        {
            return Idx;
        }
        public void ShowSelectedEmployee(int idx)
        {
            int month = MonthComboBox.SelectedIndex;
            int year = YearComboBox.SelectedIndex;
            if (month == -1 && year == -1)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
            }
            DateTime dateTime = new DateTime(year, month,20);
            FirstName_Label.Content = C.ShowSelectedEmployeeFirstName(idx);
            LastName_Label.Content = C.ShowSelectedEmployeeLastName(idx);
            TelephoneNo_Label.Content = C.ShowSelectedEmployeeTelephoneNO(idx);
            //LastShift_Label.Content = C.ShowSelectedEmployeeCurrentShift(idx);
            TotalHours_Label.Content = C.ShowSelectedEmployeeCalculatedHours(idx, month, year);
            Idx = idx;
        }

        public void showCalculatedHours()
        {
            int month = MonthComboBox.SelectedIndex+1;
            int year = 0;
            if (YearComboBox.SelectedIndex == -1)
            { year = DateTime.Now.Year; }
            else
            {
                year = int.Parse(YearComboBox.SelectedItem.ToString());
            }
            if (month == 0)
            {
                month = DateTime.Now.Month;         
            }
            DateTime dateTime = new DateTime(year, month, 20);

            TotalHours_Label.Content = C.ShowSelectedEmployeeCalculatedHours(Idx, month, year);
        }
        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showCalculatedHours();
        }
    }
}
