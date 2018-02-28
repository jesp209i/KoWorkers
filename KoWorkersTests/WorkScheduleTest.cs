using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoWorkers.WorkSchedule;
using KoWorkers;
using System.Globalization;

namespace KoWorkersTests
{
    [TestClass]
    public class WorkScheduleTest
    {
        Employee testEmployee = new Employee("Niels", "Hansen", 1234, 12345678);
        DateTime thisMoment = new DateTime(2018,2,1,08,0,0);
        DateTime otherMoment = new DateTime(2018, 2, 28, 08, 0, 0);
        
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
            Assert.AreEqual("08:00:00 - 10:00:00",newShift.ToString());
            Assert.AreEqual(120, newShift.TotalNumberOfMinutes);
        }
        [TestMethod]
        public void CreateNewSchedule()
        {
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, thisMoment, thisMoment.AddHours(2));
            WorkSchedule testSchedule = new WorkSchedule(2018, 2);
            Assert.AreEqual(2018, testSchedule.Year);
            Assert.AreEqual(2, testSchedule.Month);
            Assert.AreEqual(0, testSchedule.GetAllShifts().Count);
            testSchedule.AddShiftToSchedule(newShift);
            Assert.AreEqual(1, testSchedule.GetAllShifts().Count);
        }
        [TestMethod]
        public void CreateNewScheduleRepo()
        {
            WorkScheduleRepository wsp = WorkScheduleRepository.GetInstance();
            WorkSchedule first = new WorkSchedule(2018, 3);
            WorkSchedule second = new WorkSchedule(2018, 4);
            WorkSchedule third = new WorkSchedule(2018, 5);
            WorkSchedule fourth = new WorkSchedule(2018, 6);
            wsp.AddWorkSchedule(first);
            wsp.AddWorkSchedule(second);
            wsp.AddWorkSchedule(third);
            wsp.AddWorkSchedule(fourth);
            Assert.AreEqual(4, wsp.GetAllWorkSchedules().Count);
            Assert.AreEqual(5, wsp.GetSchedule(2018, 5).Month);
            Assert.AreEqual(null, wsp.GetSchedule(2017, 1));
        }
        [TestMethod]
        public void MonthWeekNumbers()
        {
            WorkSchedule workSchedule = new WorkSchedule(2018, 3);
            DateTime firstday = new DateTime(workSchedule.Year, workSchedule.Month, 1);
            DateTime lastday = firstday.AddMonths(1).AddDays(-1);
            Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            Assert.AreEqual("2018 03 01",firstday.ToString("yyyy MM dd"));
            Assert.AreEqual("2018 03 31", lastday.ToString("yyyy MM dd"));
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, otherMoment, otherMoment.AddHours(2));
            Assert.AreEqual(9, newShift.WeekNumber);
            Assert.AreEqual(10, cal.GetWeekOfYear(firstday.AddDays(7), DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek));
            Assert.AreEqual(11, cal.GetWeekOfYear(firstday.AddDays(14), DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek));
            Assert.AreEqual(12, cal.GetWeekOfYear(firstday.AddDays(21), DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek));
        }
    }
}
