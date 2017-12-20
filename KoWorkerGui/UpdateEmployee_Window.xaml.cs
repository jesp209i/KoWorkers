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
    /// Interaction logic for UpdateEmployee_Window.xaml
    /// </summary>
    public partial class UpdateEmployee_Window : Window
    {
        Controller C;
        public UpdateEmployee_Window()
        {
            C = new Controller();
            InitializeComponent();
            
            
        }

        private void FirstName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void ShowSelectedEmployee(int idx)
        {

            FirstName_TextBox.Text = C.ShowSelectedEmployeeFirstName(idx);
            LastName_TextBox.Text = C.ShowSelectedEmployeeLastName(idx);  
            TelephoneNo_TextBox.Text = C.ShowSelectedEmployeeTelephoneNO(idx);
            PinCode_TextBox.Text = C.ShowSelectedEmployeePinCode(idx);
        }

        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
