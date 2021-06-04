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
    public sealed class DarkMode
    {
        private readonly ScenarioContext _ctx;
        private Table _userTable;
        private string _hostBaseName = @"https://localhost:5001/";//44347/";

        public DarkMode(ScenarioContext scenarioContext)
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

        [Given(@"the user is logged into an account")]
        public void UserLoggedIn()
        {

        }

        [Then(@"the sites css will be changed to a dark mode view, with a black background, instead of the original gray light mode.")]
        public void CSSChangeToDarkView()
        {

        }

        [Given(@"the the user is in dark mode")]
        public void InDarkMode()
        {
            //_userTable = table;
            //IEnumerable<TestEvents> events = table.CreateSet<TestEvents>();
            //_ctx["Events"] = events;
        }

        [When(@"the user clicks the dark mode switch")]
        public void ClicksOnDarkModeWhileInDark()
        {

        }

        [Then(@"the sites css will be changed to a light mode view, with a grey background, instead of the black dark mode")]
        public void CSSChangeToLightView()
        {
            
        }
    }
}
