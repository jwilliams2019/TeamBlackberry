using NUnit.Framework;
using BerylCalendar.Controllers;
using System;
using BerylCalendar.Utilities;

namespace BerylCalendar.Tests.Tests
{
    public class CombineDateTime
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CombineDateTime_NewDateTimesReturns_BeginningOfTime(){
            DateTime firstTime = new DateTime();
            DateTime secondTime = new DateTime();

            firstTime = DateTimeUtilities.CombineDateTime(firstTime, secondTime);
            Assert.That(firstTime, Is.EqualTo(DateTime.Parse("01/01/0001 00:00:00")));
        }

        [Test]
        public void CombineDateTime_FirstPresetSecondNewReturns_DateOfFirstNoTime(){
            DateTime firstTime = DateTime.Parse("01/23/1970 14:00:00");
            DateTime secondTime = new DateTime();

            firstTime = DateTimeUtilities.CombineDateTime(firstTime, secondTime);
            Assert.That(firstTime, Is.EqualTo(DateTime.Parse("01/23/1970 00:00:00")));
        }

        [Test]
        public void CombineDateTime_FirstNewSecondPresetReturns_BeginningOfDatePresetTime(){
            DateTime firstTime = new DateTime();
            DateTime secondTime = DateTime.Parse("01/23/1970 14:34:56");

            firstTime = DateTimeUtilities.CombineDateTime(firstTime, secondTime);
            Assert.That(firstTime, Is.EqualTo(DateTime.Parse("01/01/0001 14:34:56")));
        }

        [Test]
        public void CombineDateTime_TwoPresetDateTimesReturns_DateOfFirstTimeOfSecond(){
            DateTime firstTime = DateTime.Parse("12/25/1987 06:30:52");
            DateTime secondTime = DateTime.Parse("08/06/2021 18:30:53");

            firstTime = DateTimeUtilities.CombineDateTime(firstTime, secondTime);
            Assert.That(firstTime, Is.EqualTo(DateTime.Parse("12/25/1987 18:30:53")));
        }
    }
}