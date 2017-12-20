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
        Controller control;
        public UpdateEmployee_Window()
        {
            control = Controller.GetInstance();
            InitializeComponent();
            
            
        }
        int Idx { get; set; }

        private void FirstName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void ShowSelectedEmployee(int idx)
        {

            FirstName_TextBox.Text = control.ShowSelectedEmployeeFirstName(idx);
            LastName_TextBox.Text = control.ShowSelectedEmployeeLastName(idx);  
            TelephoneNo_TextBox.Text = control.ShowSelectedEmployeeTelephoneNO(idx);
            PinCode_TextBox.Text = control.ShowSelectedEmployeePinCode(idx);
            Idx = idx;
        }

        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName_TextBox.Text;
            string lastName = LastName_TextBox.Text;
            int telephoneNo = int.Parse(TelephoneNo_TextBox.Text);
            int pinCode = int.Parse(PinCode_TextBox.Text);
            control.UpdateEmployeeToGuiFirstName(Idx, firstName,lastName,telephoneNo,pinCode);

        }
        

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
       
           
        }
    }
}
