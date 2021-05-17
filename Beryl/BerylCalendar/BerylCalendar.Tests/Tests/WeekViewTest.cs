using NUnit.Framework;
using Moq;
using BerylCalendar.Data.Abstract;
using BerylCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerylCalendar.Data;
using BerylCalendar.Data.Concrete;

namespace BerylCalendar.Tests.Tests
{
    public class WeekViewTest
    {
        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }

        [Test]
        public void WeekViewTest_EventStartDays_AreCorrectDayOfWeek()
        {
            List<Event> events = new List<Event>
            {
                new Event {Id = 1, TypeId = 1, AccountId = 2, Title = "I love titles", StartDateTime = new DateTime(2021, 5, 10), EndDateTime = new DateTime(2021, 5, 11), Location = "TitleLoveLand", Details = "idk man I just like titles", Account = new Account { Id = 2, Username = "user2" } },
                new Event {Id = 2, TypeId = 2, AccountId = 2, Title = "I hate titles", StartDateTime = new DateTime(2021, 5, 11), EndDateTime = new DateTime(2021, 5, 11), Location = "TitleHateLand", Details = "idk man I just hate titles", Account = new Account { Id = 2, Username = "user2" }},
                new Event {Id = 3, TypeId = 3, AccountId = 2, Title = "I despise titles", StartDateTime = new DateTime(2021, 5, 12), EndDateTime = new DateTime(2021, 5, 11), Location = "TitleDespiseLand", Details = "idk man I just despise titles", Account = new Account { Id = 2, Username = "user2" }},
            };

            Mock<DbSet<Event>> mockEvents = GetMockDbSet(events.AsQueryable());

            Mock<BerylDbContext> mockContext = new Mock<BerylDbContext>();
            mockContext.Setup(ctx => ctx.Events).Returns(mockEvents.Object);



            //Arrange
            IEventRepository eventRepo = new EventRepository(mockContext.Object);
            DateTime sunday = new DateTime(2021, 5, 9); // this is 5/9/2021, a sunday
            DateTime saturday = new DateTime(2021, 5, 15); //this is 5/15/2021, a saturday (after the earlier sunday)

            //Act

            //var test = eventRepo.GetEventsFromThisWeek("user2", sunday, saturday);
            //var eventsInWeek = await eventRepo.GetEventsFromThisWeek("user2", sunday, saturday); 

            //Not sure why this doesn't work even as an async function. Tried for hours and can't get it to work as it should.
            //Even a similar function in EventRepository that doesn't take a username as a parameter still doesn't work. I don't know why.

            var xd = eventRepo.DeleteByIdAsync(2); //This one however does work, and does not crash the test. I can't figure out how to get the one above to work.
            var thisOneWorks = eventRepo.GetAll(); //This one however does work, and does not crash the test. I can't figure out how to get the one above to work.

            //Assert
            Assert.That(events[0].StartDateTime.DayOfWeek == DayOfWeek.Monday);
            Assert.That(events[1].StartDateTime.DayOfWeek == DayOfWeek.Tuesday);
            Assert.That(events[2].StartDateTime.DayOfWeek == DayOfWeek.Wednesday);
        }
    }
}