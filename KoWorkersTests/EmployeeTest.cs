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
        //[TestMethod]
        //public void ShouldShowDateHMS()
        //{

        //    Assert.AreEqual(DateTime.Now, ShiftRepository.GetInstance().GetTime());
        //}
        [TestMethod]
        public void ShowTotalMinutesInShift()
        {
            DateTime first = DateTime.Parse("19-12-2017 06:00:00");
            DateTime second = DateTime.Parse("19-12-2017 13:33:00");
            Shift testShift = new Shift(45, first, second);
            TimeSpan ts = second.Subtract(first);
            //Assert.AreEqual(ts, "hest");
            Assert.AreEqual(480, testShift.TotalNumberOfMinutes);
        }
    }
}
