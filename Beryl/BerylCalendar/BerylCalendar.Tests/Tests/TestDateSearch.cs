using NUnit.Framework;
using BerylCalendar.Controllers;
using System;
using BerylCalendar.Utilities;
using Microsoft.AspNetCore.Mvc;

//Hayden Orn
//As an account holder, I want to be able search for specific events between dates so I can see if I have an opening to make an event.
//ID #176834915
namespace BerylCalendar.Tests.Tests
{
    public class TestDateSearch
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDateSearch_ConfirmsStringsConvertToDatetTime()
        {
            DateTime tempDatetime;

            //TEST ONE

            string stringBroughtInFromViewOnePass = "1/7/1994 4/2/1993";
            string[] dates1 = stringBroughtInFromViewOnePass.Split(' ');
            string stringOne = dates1[0];
            string stringTwo = dates1[1];

            Assert.That(stringOne == "1/7/1994");
            Assert.That(stringTwo == "4/2/1993");

            DateTime tempDateTime2 = new DateTime(1994, 1, 7);
            DateTime.TryParse(stringOne, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));

            tempDateTime2 = new DateTime(1993, 4, 2);
            DateTime.TryParse(stringTwo, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));

            //TEST TWO

            string stringBroughtInFromViewTwoFail = "aw 1/5/2014";
            string[] dates2 = stringBroughtInFromViewTwoFail.Split(' ');
            stringOne = dates2[0];
            stringTwo = dates2[1];

            Assert.That(stringTwo == "1/5/2014");

            if (DateTime.TryParse(stringOne, out tempDatetime))
            {
                Assert.Fail();
                if (DateTime.TryParse(stringTwo, out tempDatetime))
                {
                    Assert.Fail();
                }
            }

            tempDateTime2 = new DateTime(2014, 1, 5);
            DateTime.TryParse(stringTwo, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));


            //TEST THREE

            string stringBroughtInFromViewThreeFail = "12/3/2021 da";
            string[] dates3 = stringBroughtInFromViewThreeFail.Split(' ');
            stringOne = dates3[0];
            stringTwo = dates3[1];

            Assert.That(stringOne == "12/3/2021");

            if (DateTime.TryParse(stringOne, out tempDatetime))
            {
                if (DateTime.TryParse(stringTwo, out tempDatetime))
                {
                    Assert.Fail();
                }
            }

            tempDateTime2 = new DateTime(2021, 12, 3);
            DateTime.TryParse(stringOne, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));

            //TEST FOUR

            string stringBroughtInFromViewFourPass = "12/3/2020 12/5/2020 adad";
            string[] dates4 = stringBroughtInFromViewFourPass.Split(' ');
            stringOne = dates4[0];
            stringTwo = dates4[1];

            Assert.That(stringOne == "12/3/2020");
            Assert.That(stringTwo == "12/5/2020");

            tempDateTime2 = new DateTime(2020, 12, 3);
            DateTime.TryParse(stringOne, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));

            tempDateTime2 = new DateTime(2020, 12, 5);
            DateTime.TryParse(stringTwo, out tempDatetime);
            Assert.That(tempDatetime, Is.EqualTo(tempDateTime2));

            Assert.Pass();
        }
    }
}