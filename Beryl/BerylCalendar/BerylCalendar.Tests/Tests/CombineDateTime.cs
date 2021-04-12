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
        public void CombineDateTime_NullDateTimesReturns_BeginningOfTime()
        {
            DateTime firstTime = new DateTime();
            DateTime secondTime = new DateTime();

            firstTime = DateTimeUtilities.CombineDateTime(firstTime, secondTime);
            Assert.That(firstTime, Is.EqualTo("01/01/0001 12:00:00"));
        }
    }
}