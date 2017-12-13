using System;
using KoWorkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoWorkersTests
{
    [TestClass]
    public class EmployeeTest
    {
        //[TestMethod]
        //public void ShouldCreateAnEmployee()
        //{
        //    Employee newPerson = new Employee("Lars", "Rasmussen");
        //    Assert.AreEqual("Lars Rasmussen", newPerson.GetName());
        //}
        //[TestMethod]
        //public void ShouldRenameAnEmployee()
        //{
        //    Employee newPerson = new Employee("Lars", "Rasmussen");
        //    newPerson.SetName("Jesper", "Madsen");
        //    Assert.AreEqual("Jesper Madsen", newPerson.GetName());
        //}
        //[TestMethod]
        //public void ShouldPutEmployeesInList()
        //{
        //    EmployeeRepository personRepo = new EmployeeRepository();

        //    Assert.AreEqual(0, personRepo.Count());

        //    Employee newPerson = new Employee("Lars", "Rasmussen");
        //    personRepo.employees.Add(newPerson);

        //    Assert.AreEqual(1, personRepo.Count()); // tilføjet en person

        //    Employee nextPerson = new Employee("Jesper", "Madsen");
        //    personRepo.employees.Add(nextPerson);
        //    Employee nextNextPerson = new Employee("Andreas", "Nielsen");
        //    personRepo.employees.Add(nextNextPerson);

        //    Assert.AreEqual(3, personRepo.Count()); // tilføjet to mere, dvs 3 ialt
        //}
        //[TestMethod]
        //public void ShouldDeleteAnEmployee()
        //{
        //    EmployeeRepository personRepo = new EmployeeRepository();
        //    Assert.AreEqual(0, personRepo.Count());

        //    Employee newPerson = new Employee("Lars", "Rasmussen");
        //    personRepo.employees.Add(newPerson);
        //    Assert.AreEqual(1, personRepo.Count());

        //    Employee nextPerson = new Employee("Jesper", "Madsen");
        //    personRepo.employees.Add(nextPerson);
        //    Assert.AreEqual(2, personRepo.Count());
        //    personRepo.employees.Remove(newPerson);
        //    Assert.AreEqual(1, personRepo.Count());

        //    personRepo.employees.Add(newPerson);
        //    Employee nextNextPerson = new Employee("Andreas", "Nielsen");
        //    personRepo.employees.Add(nextNextPerson);
        //    Assert.AreEqual(3, personRepo.Count());

        //    personRepo.employees.Remove(newPerson);
        //    Assert.AreEqual(2, personRepo.Count());


        //}

        //[TestMethod]
        //public void ShouldListAllEmployees()
        //{
        //    EmployeeRepository personRepo = new EmployeeRepository();
        //    Employee newPerson = new Employee("Lars", "Rasmussen");
        //    personRepo.employees.Add(newPerson);
        //    Assert.AreEqual("Lars Rasmussen", personRepo.ListAllEmployees());
        //}
        [TestMethod]
        public void ShouldShowDateYear()
        {
            TimesheetRepository timesheetRepo = new TimesheetRepository();         
            Assert.AreEqual(2017, timesheetRepo.GetTimesheetYear());
        }

        [TestMethod]
        public void ShouldShowDateMonth()
        {
            TimesheetRepository timesheetRepo = new TimesheetRepository();
            Assert.AreEqual(12, timesheetRepo.GetTimesheetMonth());
        }

    }
}
