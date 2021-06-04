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
    public sealed class WeekView
    {
        private readonly ScenarioContext _ctx;
        private Table _userTable;
        private string _hostBaseName = @"https://localhost:5001/";//44347/";

        public WeekView(ScenarioContext scenarioContext)
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

        public class TestDisplay
        {
            public DateTime startDateTime = new DateTime(2021, 07, 28);
        }

        [Given(@"that same user has saved events for the current week, starting from sunday")]
        public void UserHasEventFromThisWeek()
        {

        }

        [Given(@"the user is not currently logged in")]
        public void UserNotLoggedIn()
        {
            //_userTable = table;
            //IEnumerable<TestEvents> events = table.CreateSet<TestEvents>();
            //_ctx["Events"] = events;
        }

        [When(@"the user tries to go to the week view")]
        public void UserGoesToWeekView()
        {

        }

        [Then(@"the user will be sent to the login page")]
        public void UserRedirectedToLogin()
        {
            
        }

        [Given(@"the user is logged in")]
        public void UserIsLoggedIn()
        {
            //_userTable = table;
            //IEnumerable<TestEvents> events = table.CreateSet<TestEvents>();
            //_ctx["Events"] = events;
        }

        [When(@"they are on the home page")]
        public void UserOnHomePage()
        {

        }

        [Then(@"the user clicks on the Week button on the navbar")]
        public void UserClicksWeekButton()
        {
            
        }

        [Given(@"the user has created an event under a day of the current week")]
        public void CreatedAnEventInCurrentWeek()
        {
            //_userTable = table;
            //IEnumerable<TestEvents> events = table.CreateSet<TestEvents>();
            //_ctx["Events"] = events;
        }

        [When(@"the user clicks the Week button on the navbar")]
        public void ClicksWeekButtonOnNavbar()
        {

        }

        [Then(@"the user will see that event under the the day the event starts")]
        public void UserSeesAllEventsInWeek()
        {

        }
    }
}
