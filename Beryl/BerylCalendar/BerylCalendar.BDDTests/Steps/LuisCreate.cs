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
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BerylCalendar.BDDTests.Steps
{
    [Binding]
    public sealed class LuisCreate
    {
        private readonly ScenarioContext _ctx;
        private string _hostBaseName = @"https://localhost:5001/";
        private readonly IWebDriver _driver;

        public SearchEventsByLocation(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _ctx = scenarioContext;
            _driver = driver;
        }

        // GIVENS

        [Given(@"I am logged in as a user")]
        public void GivenIAmLoggedInAsAUser(){
            _ctx["User"] = user;
        }

        [Given(@"I am on the Display Page")]
        public void GivenIAmOnTheDisplayPage(){
            _driver.Navigate().GoToUrl(_hostBaseName + "/Event/Display");
        }

        [Given(@"I have clicked the '(.*)' text box")]
        public void GivenIHaveClickedTheTextBox(string Feature){
            if (Feature.Equals("Luis")){
                IWebElement textBox = _driver.FindElement(Byte.Id("phrase"));
                if (textBox == null){
                    Assert.Fail();
                }
            }
        }

        [Given(@"I have typed '(.*)' in the Luis text box")]
        public void GivenIHaveTypedInTheLuisBox(string Query){
            _driver.FindElement(By.Id("phrase")).SendKeys(Query);
            _ctx["SentQuery"] = Query;
        }

        // WHENS

        [When(@"I type '(.*)' on the keyboard")]
        public void WhenIType(string Phrase){
            _driver.FindElement(By.Id("phrase")).SendKeys(Phrase);
            _ctx["SentPhrase"] = Phrase;
        }

        [When(@"I click the Interpret button")]
        public void WhenIClickTheInterpretButton(){
            _driver.FindElement("ReadAsCommand").Click();
        }

        // THENS
        [Then(@"'(.*)' shows up in the text box")]
        public void ThenShowsUpInTheTextBox(string ResultPhrase){
            IWebElement textbox = _driver.FindElement(By.Id("phrase"));
            Assert.That(textbox.Text, Does.Contain((string)_ctx["SentPhrase"]));
        }

        [Then(@"the CreateEvent page will be opened with default values")]
        public void ThenTheCreateEventPageWillBeOpenedWithDefaultValues(){
            IWebElement T = _driver.FindElement(By.Id("Title"));
            IWebElement SDT = _driver.FindElement(By.Id("StartDateTime"));
            IWebElement ST = _driver.FindElement(By.Id("startTime"));
            IWebElement EDT = _driver.FindElement(By.Id("EndDateTime"));
            IWebElement ET = _driver.FindElement(By.Id("endTime"));
            IWebElement L = _driver.FindElement(By.Id("Location"));
            IWebElement D = _driver.FindElement(By.Id("Details"));
            IWebElement TI = _driver.FindElement(By.Id("typeId"));
            Assert.That(T.Equals(string.Empty));
            Assert.That(SDT.Equals((string)DateTime.Today));
            Assert.That(ST.Equals("12:00:000 AM"));
            Assert.That(EDT.Equals((string)DateTime.Today));
            Assert.That(ET.Equals("12:00:000 AM"));
            Assert.That(L.Equals(string.Empty));
            Assert.That(D.Equals(string.Empty));
            Assert.That(TI.Equals(1));
        }

        [Then(@"the CreateEvent page will be opened with the Title being '(.*)'")]
        public void ThenTheCreateEventPageWillBeOpenedWithTheTitleBeing(string Title){
            IWebElement Title = _driver.FindElement(By.Id("Title"));
            Assert.That(Title.Text.Equals(Title));
        }















    }
}