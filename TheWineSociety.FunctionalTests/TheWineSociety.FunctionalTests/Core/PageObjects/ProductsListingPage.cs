using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Fluent;
using OpenQA.Selenium.Support.PageObjects;

namespace TheWineSociety.FunctionalTests.Core.PageObjects
{
    public class ProductsListingPage : CommonMethods
    {

       // PageInitializer pageInitializer = new PageInitializer();
  
        public ProductsListingPage()
        {
            PageFactory.InitElements(driver, this);

        }
    }
}
