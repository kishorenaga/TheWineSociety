using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheWineSociety.FunctionalTests.Core.PageObjects;

namespace TheWineSociety.FunctionalTests.Core.Steps
{
    [Binding]
    public  class UserCanBuyWines_Steps:PageInitializer
    {
        

        private readonly ScenarioContext context;

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            commonMethods.NavigateToUrl("https://www.bbc.co.uk/");
        }

        [Given(@"I select Red wines")]
        public void GivenISelectRedWines()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I filter red wines based on (.*) and (.*)")]
        public void WhenIFilterRedWinesBasedOnAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the i see applied filter selections are displayed")]
        public void ThenTheISeeAppliedFilterSelectionsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
