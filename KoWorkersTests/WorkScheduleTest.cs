using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoWorkers.WorkSchedule;
using KoWorkers;

namespace KoWorkersTests
{
    [TestClass]
    public class WorkScheduleTest
    {
        Employee testEmployee = new Employee("Niels", "Hansen", 1234, 12345678);
        DateTime thisMoment = DateTime.Now;
        
        [TestInitialize]
        public void Initialize()
        {
        }
        [TestMethod]
        public void CreateNewShift()
        {
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, thisMoment, thisMoment.AddHours(2));
            TimeSpan timeSpan = new TimeSpan(2, 0, 0);
            Assert.AreEqual("Niels Hansen", newShift.Employee.FullName);
            Assert.AreEqual(timeSpan, newShift.EndTime.Subtract(newShift.StartTime));
            Assert.AreEqual(120, newShift.TotalNumberOfMinutes);
        }
        [TestMethod]
        public void CreateNewSchedule()
        {
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, thisMoment, thisMoment.AddHours(2));
            WorkSchedule testSchedule = new WorkSchedule(2018, 3);
            Assert.AreEqual(2018, testSchedule.Year);
            Assert.AreEqual(0, testSchedule.GetAllShifts().Count);
            testSchedule.AddShiftToSchedule(newShift);
            Assert.AreEqual(1, testSchedule.GetAllShifts().Count);
        }
    }
}
