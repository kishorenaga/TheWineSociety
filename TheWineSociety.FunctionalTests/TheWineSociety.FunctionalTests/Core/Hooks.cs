using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using NLog;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.CodeDom.Compiler;
using NUnit.Framework;

namespace TheWineSociety.FunctionalTests.Core
{
    [GeneratedCode("SpecFlow", "3.1.86")]
    [SetUpFixture]
    [Binding]
    public class Hooks
    {

        private static readonly Logger log = LogManager.GetLogger("Hooks");
        public static RemoteWebDriver Driver = null;
        public string Env { get; set; } = "SSU4";
        public string browser { get; set; } = "FIREFOX";
        public string tags { get; set; } = "Test";
        FileReader fileReader = new FileReader();
        private static Boolean takeScreenshot = true;


       // public TestContext Context;
        //public TestContext Context2;


        public Hooks()
        {

 
        //Context = FeatureContext.Current["TestContext"] as TestContext;

        //    try
        //    {
        //        ScenarioContext.Current.Clear();
        //        Env = Context.Properties["environment"].ToString();
        //        browser = Context.Properties["browser"].ToString();
        //        tags = Context.Properties["tag"].ToString();
        //    }
        //    catch (NullReferenceException)
        //    {

        //        log.Info("RunSetting file is not used so defualt to run on SSU4");

        //    }
           // setEnvironment(Env);

        }



        public void setEnvironment(string environment)
        {
            string path = fileReader.readFile(environment);
            // Open the file to read from.
            string writeToFile = "";
            foreach (String item in File.ReadLines(path))
            {
                //log.Info(item);
                String[] itemValue = item.Split('=');

                writeToFile = writeToFile + itemValue[1].Replace("http://", "").Replace("https://", "").Replace("/", "") + ",";
                //  setStandardProperties(itemValue[0], itemValue[1]);
                ScenarioContext.Current.Add(itemValue[0], itemValue[1]);
            }

            Env = environment;
            ScenarioContext.Current.Add("Env", Env);
            ScenarioContext.Current.Add("Browser", browser);
            ScenarioContext.Current.Add("Tag", tags);
            fileReader.witeToFile("JMETER", writeToFile);
        }


        /// <summary>
        /// Webdriver open the Browser
        /// </summary>
        public RemoteWebDriver OpenBrowser()
        {
           
                    try
                    {
                        KillChromeDriver();
                        Environment.CurrentDirectory = fileReader.getCurrentDriverPath();
                        //string path = fileReader.getCurrentDriverPath();
                        log.Info("Driver Path" + Environment.CurrentDirectory);
                        ChromeOptions Options = new ChromeOptions();
                        //Options.AddArgument("--start-maximized");
                        Options.AddArgument("no-sandbox");
                        Driver = new ChromeDriver(Environment.CurrentDirectory, Options, TimeSpan.FromMinutes(1));
                        //Driver.Manage().Window.Maximize();
                        Driver.Manage().Window.Size = new System.Drawing.Size(1280, 900);


                    }
                    catch (Exception e)
                    {

                        log.Info(e);
                    }
                
            
            log.Info("Browser Open");
            log.Info(Driver.Url + "- " + Driver.Title);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(1);
            return Driver;
        }


        private static void KillChromeDriver()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }


        /// <summary>
        /// Before Scenario
        /// </summary>
        [BeforeScenario]
        public void Before()
        {
            Driver = Driver ?? OpenBrowser();
            log.Info("Before Test Run");
            log.Info("====================Scenario :- " + ScenarioContext.Current.ScenarioInfo.Title + "=====================");

            ScenarioContext.Current.Set(Driver);
        }

        /// <summary>
        /// After Scenario
        /// </summary>
        [AfterScenario]
        public void After()
        {
            try
            {


                if (ScenarioContext.Current.TestError != null)
                {
                    log.Info("====================Failed: " + ScenarioContext.Current.ScenarioInfo.Title + "=====================");
                   // if (tags.Equals("Regression") || tags.Equals("Smoke") || tags.Equals("smoke"))
                      //  appTrace.RecordTestResults(ScenarioContext.Current.ScenarioInfo.Title, "Failed", ScenarioContext.Current["Env"].ToString(), ScenarioContext.Current["project"].ToString(), ScenarioContext.Current["Tag"].ToString());
                    //CaptureScreenShot(ScenarioContext.Current.ScenarioInfo.Title);
                }




                if (ScenarioContext.Current.TestError == null)
                {
                    log.Info("====================Passed - " + ScenarioContext.Current.ScenarioInfo.Title + "=====================");
                   // if (tags.Equals("Regression") || tags.Equals("Smoke") || tags.Equals("smoke"))
                       // appTrace.RecordTestResults(ScenarioContext.Current.ScenarioInfo.Title, "Passed", ScenarioContext.Current["Env"].ToString(), ScenarioContext.Current["project"].ToString(), ScenarioContext.Current["Tag"].ToString());
                }

            }
            finally
            {
               // FeatureContext.Current["TestContext"] = Context;
               // profile.Clean();
                ScenarioContext.Current.Clear();
                Driver.Dispose();
                Driver.Quit();
                Driver = null;
                log.Info("Browser Closed Completely after test run");
            }
        }
    }

}

