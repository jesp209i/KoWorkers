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

namespace KoWorkerGui
{
    /// <summary>
    /// Interaction logic for SetDate_Window.xaml
    /// </summary>
    public partial class SetDate_Window : Window
    {
        public SetDate_Window()
        {
            InitializeComponent();
            FillComboBoxes();
        }
        private void FillComboBoxes()
        {
            string[] years = new string[] { "2018", "2017", "2016", "2015" };
            string[] months = new string[] { "Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December" };
            foreach (string month in months)
            { SetMonth_ComboBox.Items.Add(month); }
            foreach (string year in years)
            { SetYear_ComboBox.Items.Add(year); }
        }
    }
}
