using NUnit.Framework;
using BerylCalendar.Controllers;
using System;
using BerylCalendar.Utilities;
using System.Linq;
using BerylCalendar.Data.Abstract;
using BerylCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

//Hayden Orn
//As an account holder, I want to be able to search for events by types so that I can see how often I plan to go shopping and if I need to make an extra trip for a large event.
//ID #176834978
namespace BerylCalendar.Tests.Tests
{
    public class TestTypeSearch
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBySearch_MakesSureThatFirstLetterIsChar()
        {
            //To determine if the string coming in from the view is a date or a type, we check if the first character in the string is a letter.
            //If it is, we assume it is a type. If not, it will assume it is a date and then enter validation for a different user story.

            string stringComingInThroughViewOne = "test";
            string stringComingInThroughViewTwo = "1test";
            string stringComingInThroughViewThree = "@test";
            bool isPossiblyType = char.IsLetter(stringComingInThroughViewOne.FirstOrDefault());
            Assert.That(Char.IsLetter(stringComingInThroughViewOne.FirstOrDefault()));
            Assert.That(!Char.IsLetter(stringComingInThroughViewTwo.FirstOrDefault()));
            Assert.That(!Char.IsLetter(stringComingInThroughViewThree.FirstOrDefault()));

            Assert.Pass();
        }
    }
}