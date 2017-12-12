using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Menu
    {
        public EmployeeController employeeControl = new EmployeeController();

        public void StartMenu()
        {
            bool keepMenuRunning = true;
            do
            {

            Console.Clear();
            Console.WriteLine("KoWorkers");
            Console.WriteLine("---------");
            Console.WriteLine("1. Medarbejderadministration");
            Console.WriteLine();
            Console.WriteLine("0. Afslut");

                string choice = GetUserChoice("Indtast valg:");
                switch (choice)
                {
                    case "1": StartEmployeeMenu(); break;
                    case "0": keepMenuRunning = false; break;
                    default: MenuError(); break;
                }

            } while (keepMenuRunning);
        }

        private void StartEmployeeMenu()
        {
            bool keepMenuRunning = true;
            do
            {
            Console.Clear();
            Console.WriteLine("KoWorkers // Medarbejderadministration");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("  1. Tilføj medarbejer \n  2. Slet medarbejder \n  3. Opdater medarbejder \n  0. Afslut medarbejderadministration");
            Console.WriteLine();
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine(employeeControl.employeeRepo.ListAllEmployees());

                string choise = GetUserChoice("Indtast valg:");
                switch (choise)
                {
                    case "1": NewEmployee(); break;
                    case "2": RemoveEmployee(); break;
                    case "3": UpdateEmployee(); break;
                    case "0": keepMenuRunning = false; break;
                    default: MenuError(); break;
                }

            } while (keepMenuRunning);
        }
        private void UpdateEmployee()
        {
            Console.Clear();
            Console.WriteLine("Opdater medarbejder");
            Console.WriteLine("--------");
            Console.WriteLine();
            Console.WriteLine("vælg en person fra listen som du vil opdatere");
            Console.WriteLine("--------");
            Console.WriteLine(employeeControl.employeeRepo.ListAllEmployees());
            string getNumberOfEmployee;
            do
            {
                getNumberOfEmployee = GetUserChoice("indtast tal ud for navn");
            } while (!int.TryParse(getNumberOfEmployee, out int s));
            Employee updateEmployee = employeeControl.GetEmployee(int.Parse(getNumberOfEmployee));
            string newFirstName = GetUserChoice("Indtast nyt fornavn");
            string newLastName = GetUserChoice("Indtast nyt efternavn");
            updateEmployee.FirstName = newFirstName;
            updateEmployee.LastName = newLastName;
            employeeControl.UpdateEmployee(updateEmployee);


            Console.WriteLine();
            Console.WriteLine("Tryk en tast for at fortsætte");
            Console.ReadLine();

        }
        private void RemoveEmployee()
        {
            Console.Clear();
            Console.WriteLine("KoWorkers // Medarbejderadministration  // Slet medarbejder");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("Vælg en person fra listen som du vil slette");
            Console.WriteLine("---------");
            Console.WriteLine(employeeControl.employeeRepo.ListAllEmployees());
            string getNumberOfEmployee;
            do
            {
                getNumberOfEmployee = GetUserChoice("Indtast tal ud for navn:");
            } while (!int.TryParse(getNumberOfEmployee,out int s));
            Employee removeEmployee = employeeControl.GetEmployee(int.Parse(getNumberOfEmployee));
            bool hasNotChosenCorrectly = true;
            do
            {
                Console.WriteLine("Er du sikker på at du vil slette " + removeEmployee.GetName());
                string choise = GetUserChoice(" Skriv \"j\" for ja og \"n\" for nej");
                switch (choise)
                {
                    case "j":
                        Console.WriteLine(employeeControl.RemoveEmployee(removeEmployee) + " blev fjernet");
                        hasNotChosenCorrectly = false;
                        break;
                    case "n":
                        Console.WriteLine("Ingen medarbejder er blevet slettet.");
                        hasNotChosenCorrectly = false;
                        break;
                    default: MenuError(); break;
                }
            } while (hasNotChosenCorrectly);
            
            Console.WriteLine();
            Console.WriteLine("Tryk en tast for at fortsætte");
            Console.ReadLine();
        }

        private void NewEmployee()
        {
            string firstName;
            string lastName;
            int pinCode;
            int telephoneNo;
            Console.Clear();
            Console.WriteLine("KoWorkers // Medarbejderadministration  // Tilføj medarbejder");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("Vi skal bruge et fornavn og et efternavn.");
            Console.WriteLine("---------");
            firstName = GetUserChoice("Først fornavn:");
            Console.WriteLine();
            lastName = GetUserChoice("Efternavn:");
            Console.WriteLine();
            pinCode = GetDigits(4);
            Console.WriteLine();
            telephoneNo = GetDigits(8);
            employeeControl.AddEmployee(firstName, lastName, pinCode, telephoneNo);
        }

       

        private void MenuError()
        {
            Console.WriteLine("Forkert indtastning.\nTryk en tast for at gå tilbage...");
            Console.ReadKey();
        }

       
        public string GetUserChoice(string text)
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine();
            return userInput;
        }

        private int GetDigits(int numberLength)
        {
            int value;
            bool isNumber = false;
            
            do
            {
                Console.WriteLine("indtast tal:");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out value) && userInput.Length == numberLength)
                {
                    Console.WriteLine("tal indtastet");
                    Console.ReadKey();
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Forkert indtastning, pin må kun indeholde tal");
                    Console.ReadKey();
                }
            } while (isNumber == false);
            return value;
        }
        public void CheckIn()
        {
            int pin;
            pin = GetDigits(4);

            employeeControl.CheckInByPin(pin);
            
        }

    }
}
