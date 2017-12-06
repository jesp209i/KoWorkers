﻿using System;
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

                string choise = GetUserChoise("Indtast valg:");
                switch (choise)
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
            Console.WriteLine("  1. Tilføj medarbejer - 0. Afslut medarbejderadministration");
                Console.WriteLine("  S. Slet medarbejder");
            Console.WriteLine();
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine(employeeControl.employeeRepo.ListAllEmployees());

                string choise = GetUserChoise("Indtast valg:");
                switch (choise)
                {
                    case "1": NewEmployee(); break;
                    case "S": RemoveEmployee(); break;
                    case "0": keepMenuRunning = false; break;
                    default: MenuError(); break;
                }

            } while (keepMenuRunning);
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
                getNumberOfEmployee = GetUserChoise("Indtast tal ud for navn:");
            } while (!int.TryParse(getNumberOfEmployee,out int s));
            Employee removeEmployee = employeeControl.GetEmployee(int.Parse(getNumberOfEmployee));
            bool hasNotChosenCorrectly = true;
            do
            {
                Console.WriteLine("Er du sikker på at du vil slette " + removeEmployee.GetName());
                string choise = GetUserChoise(" Skriv \"j\" for ja og \"n\" for nej");
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
            Console.Clear();
            Console.WriteLine("KoWorkers // Medarbejderadministration  // Tilføj medarbejder");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("Vi skal bruge et fornavn og et efternavn.");
            Console.WriteLine("---------");
            firstName = GetUserChoise("Først fornavn:");
            Console.WriteLine();
            lastName = GetUserChoise("Efternavn:");
            employeeControl.AddEmployee(firstName, lastName);
        }

       

        private void MenuError()
        {
            Console.WriteLine("Forkert indtastning.\nTryk en tast for at gå tilbage...");
            Console.ReadKey();
        }

       
        public string GetUserChoise(string text)
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
