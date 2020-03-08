using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Fluent;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace TheWineSociety.FunctionalTests.Core
{
    public class CommonMethods
    {

        protected static RemoteWebDriver driver

        {
            get { return ScenarioContext.Current.Get<RemoteWebDriver>(); }
            set { }
        }

        public void NavigateToUrl(string url)
        {
            Log.Info("Navigate into site using: " + url);
            driver.Navigate().GoToUrl(url);
            //WaitForPageToLoad();

        }
    }
}
