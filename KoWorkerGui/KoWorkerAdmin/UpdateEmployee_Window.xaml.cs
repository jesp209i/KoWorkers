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

namespace KoWorkerGui.KoWorkerAdmin
{
    
    /// <summary>
    /// Interaction logic for UpdateEmployee_Window.xaml
    /// </summary>
    public partial class UpdateEmployee_Window : Window
    {
        Controller control;
        int idx;
        public UpdateEmployee_Window()
        {
            control = Controller.GetInstance();
            InitializeComponent();
            idx = control.CurrentEmployee.EmployeeId;
        }
        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            control.CurrentEmployee.FirstName = FirstName_TextBox.Text;
            control.CurrentEmployee.LastName = LastName_TextBox.Text;
            control.CurrentEmployee.TelephoneNo = int.Parse(TelephoneNo_TextBox.Text);
            control.CurrentEmployee.PinCode = int.Parse(PinCode_TextBox.Text);
            control.UpdateEmployee(control.CurrentEmployee);
            this.Close();
        }

        private void Abort_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
