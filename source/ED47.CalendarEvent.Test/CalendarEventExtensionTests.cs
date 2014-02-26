using System;
using Amido.NAuto;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ED47.CalendarEvent.Test
{
    [TestClass]
    public class CalendarEventExtensionTests
    {
        [TestMethod]
        public void MaxOverlapPercentageTestWithOverlap1()
        {
            var event1 = A.Fake<ICalendarEvent>();
            event1.StartDate = new DateTime(2010, 1, 1);
            event1.EndDate = new DateTime(2010, 12, 31);
            event1.AllDay = true;

            var event2 = A.Fake<ICalendarEvent>();
            event2.StartDate = new DateTime(2010, 12, 1);
            event2.EndDate = new DateTime(2011, 2, 1);
            event2.AllDay = true;

            var events = new[] { event1, event2 };
            var result = events.MaxOverlapPercentage();

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void MaxOverlapPercentageTestWithOverlap2()
        {
            var event1 = A.Fake<ICalendarEvent>();
            event1.StartDate = new DateTime(2010, 12, 1);
            event1.EndDate = new DateTime(2011, 2, 1);
            event1.AllDay = true;

            var event2 = A.Fake<ICalendarEvent>();
            event2.StartDate = new DateTime(2010, 1, 1);
            event2.EndDate = new DateTime(2010, 12, 31);
            event2.AllDay = true;

            var events = new[] { event1, event2 };
            var result = events.MaxOverlapPercentage();

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void MaxOverlapPercentageTestNoOverlap1()
        {
            var event1 = A.Fake<ICalendarEvent>();
            event1.StartDate = new DateTime(2010, 1, 1);
            event1.EndDate = new DateTime(2010, 12, 31);
            event1.AllDay = true;
            
            var event2 = A.Fake<ICalendarEvent>();
            event2.StartDate = new DateTime(2011, 1, 1);
            event2.EndDate = new DateTime(2011, 2, 1);
            event2.AllDay = true;

            var events = new[] { event1, event2 };
            var result = events.MaxOverlapPercentage();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaxOverlapPercentageTestNoOverlap2()
        {
            var event1 = A.Fake<ICalendarEvent>();
            event1.StartDate = new DateTime(2010, 12, 1);
            event1.EndDate = new DateTime(2011, 2, 1);
            event1.EndDate = new DateTime(2011, 2, 1);

            var event2 = A.Fake<ICalendarEvent>();
            event2.StartDate = new DateTime(2010, 1, 1);
            event2.EndDate = new DateTime(2010, 11, 30);
            event2.AllDay = true;

            var events = new[] { event1, event2 };
            var result = events.MaxOverlapPercentage();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ToFullCalendarEventsTest()
        {
            var event1 = A.Fake<ICalendarEvent>();
            event1.StartDate = new DateTime(2010, 12, 1);
            event1.EndDate = new DateTime(2011, 2, 1);
            event1.EndDate = new DateTime(2011, 2, 1);
            event1.Name = "Richard's fantastic event";

            var event2 = A.Fake<ICalendarEvent>();
            event2.StartDate = new DateTime(2010, 1, 1);
            event2.EndDate = new DateTime(2010, 11, 30);
            event2.AllDay = true;
            event2.Name = "Micheal's holidays";
            
            var events = new[] { event1, event2 };
            var result = events.ToFullCalendarEvents();

            Assert.IsNotNull(result);
        }
    }
}
