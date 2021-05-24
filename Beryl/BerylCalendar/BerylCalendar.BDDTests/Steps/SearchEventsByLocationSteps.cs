using BerylCalendar.BDDTests.src;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow.Assist;

namespace BerylCalendar.BDDTests.Steps
{
    [Binding]
    public sealed class SearchEventsByLocation
    {
        private readonly ScenarioContext _ctx;
        private Table _userTable;
        private string _hostBaseName = @"https://localhost:5001/";//44347/";

        public SearchEventsByLocation(ScenarioContext scenarioContext)
        {
            _ctx = scenarioContext;

            //    //ChromeOptions options = new ChromeOptions();
            //    //options.AcceptInsecureCertificates = true;
            //    //_ctx["WebDriver"] = new ChromeDriver(options);
        }

        public class TestEvents
        {
            public string Title { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            public string Location { get; set; }
            public string Details { get; set; }

        }

        public class TestUser
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
        }

        public class TestDisplay
        {
            public DateTime startDateTime = new DateTime(2021, 07, 28);
        }

        [Given(@"that the user has multiple events scheduled for the same day")]
        public void MultipleEventsSameDay()
        {

        }

        [Given(@"that the main display only shows events for the current day")]
        public void DisplayShowsEventsInCurrentDay()
        {

        }

        [Given(@"the (.*) is not logged in")]
        public void UserNotLoggedIn(string user)
        {
            if (user.Any())
            {

            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"the user tries to go to the day view")]
        public void UserGoesToDayMonthView()
        {

        }

        [Then(@"the user will be sent to the login page instead")]
        public void UserWillBeRedirectedToLoginPage()
        {

        }

        [Given(@"a (.*) is logged in")]
        public void UserIsLoggedIn(string user)
        {
            if (user.Any())
            {

            }
            else
            {
                Assert.Fail();
            }
        }

        [Given(@"the logged in user is on the day view")]
        public void UserIsOnDayView()
        {

        }

        [When(@"the user types in part of all of a location for an event that is on that day")]
        public void UserTypesPartOrAllOfLocation()
        {

        }

        [Then(@"the user will be shown all events that have a location matching the text that was submitted")]
        public void ShowAllEventsWithThatLocation()
        {
            
        }
    }
}
