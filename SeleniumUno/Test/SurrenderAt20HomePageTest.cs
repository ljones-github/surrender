using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumUno.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SeleniumUno
{
    public class Surrender
    {
        //string methodName;
        SeleniumUno.Main.BrowserType myBrowser = SeleniumUno.Main.BrowserType.Chrome;
       /// private static readonly log4net.ILog log = LogHelper.initLog();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        MethodBase m;
        static void Main(string[] args)
        {
            /*Surrender s = new Surrender();
            
            s.navigateToSurrender(testDriver);
            s.countLinks(testDriver);
            s.sendToSearchBox("God-King", testDriver);
            testDriver.Close();*/
        }
       

        /*
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            log 
        }
        */

        [SetUp]
        public void InitializeDriver()
        {
            m = MethodBase.GetCurrentMethod();
            
            try
            {
                if (myBrowser == SeleniumUno.Main.BrowserType.Firefox)
                {
                    log.Info("Attempting to initialize driver");
                    SeleniumUno.Main.PropertiesCollection.driver = new FirefoxDriver();
                    log.Debug("Driver initialized successfully");
                }
                else
                {
                    log.Info("Attempting to initialize driver");
                    SeleniumUno.Main.PropertiesCollection.driver = new ChromeDriver();
                    log.Debug("Driver initialized successfully");
                }
            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }
           

            SeleniumUno.Main.PropertiesCollection.driver.Manage().Window.Maximize();
            SeleniumUno.Main.PropertiesCollection.driver.Navigate().GoToUrl("http://www.surrenderat20.net");
            SeleniumUno.Main.PropertiesCollection.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Console.WriteLine("Current URL: " + SeleniumUno.Main.PropertiesCollection.driver.Url);
            Console.WriteLine("Current Title: " + SeleniumUno.Main.PropertiesCollection.driver.Title);


        }

        [Test]
        public void CountLinks()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            System.Threading.Thread.Sleep(6000);
            //var wait = new WebDriverWait(SeleniumUno.Main.PropertiesCollection.driver, TimeSpan.FromMilliseconds(5000));
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.TagName("a"))));
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            
            try
            {
                log.Info("Attempting to acquire links...");
                foreach (IWebElement link in sur.links)
                {
                    Console.WriteLine(SeleniumUno.Standard_Methods.GetMethods.GetUrl(link));
                }
                log.Debug("Links successfully acquired.");
            }
            catch (Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }
            
            Console.WriteLine("Number of links on the page is " + sur.links.Count);

        }
        
       [Test]
        public void _clickHome()
        {
            System.Threading.Thread.Sleep(6000);
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            String myUrl = SeleniumUno.Main.PropertiesCollection.driver.Url;
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            WebDriverWait myWait = new WebDriverWait(SeleniumUno.Main.PropertiesCollection.driver, TimeSpan.FromSeconds(3));
            myWait.Until(ExpectedConditions.ElementToBeClickable(sur.homeButton));
            Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);

            try
            {
                log.Info("Attempting to click on button: log.debug");
                s.Click(sur.homeButton).Build().Perform();
                log.Debug("Button clicked successfully: log.info");
            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }
            
            myWait.Until(ExpectedConditions.ElementToBeClickable(sur.homeButton));
            Assert.IsTrue(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("index.html"), "Failed because " + myUrl + " does NOT contain 'index.html'");
            Base._takesScreenshot(m.Name);
        }


        [Test]
        public void SendToSearchBox()
        {
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            string s = "God-King";
            SeleniumUno.Standard_Methods.SetMethods.EnterText(sur.searchBox, s);
            Assert.That(sur.searchBox.GetAttribute("value").Equals(s));
            sur.submitSearch.Submit();
            System.Threading.Thread.Sleep(4000);

            
        }

        [Test]
        public void _clickPbe()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                log.Info("Attempting to click on button...");
                sur.pbeButton.Click();
                System.Threading.Thread.Sleep(6000);
                log.Debug("Button clicked successfully");
            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }

            Base._takesScreenshot(m.Name);
            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("PBE"));

        }

        [Test]
        public void _clickReleases()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                sur.releasesButton.Click();
                System.Threading.Thread.Sleep(6000);
                Console.WriteLine("Button clicked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in clicking the element. Desc: " + e);
            }

            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("Releases"));

        }

        [Test]
        public void _clickRedposts()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                sur.redPostsButton.Click();
                System.Threading.Thread.Sleep(6000);
                Console.WriteLine("Button clicked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in clicking the element. Desc: " + e);
            }

            Console.WriteLine("Current Url: {0}",SeleniumUno.Main.PropertiesCollection.driver.Url);
            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("Posts"));

        }

        [Test]
        public void _clickRotations()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                sur.rotationsButton.Click();
                System.Threading.Thread.Sleep(6000);
                Console.WriteLine("Button clicked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in clicking the element. Desc: " + e);
            }

            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("Rotations"));

        }

        [Test]
        public void _clickEsports()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                sur.esportsButton.Click();
                System.Threading.Thread.Sleep(6000);
                Console.WriteLine("Button clicked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in clicking the element. Desc: " + e);
            }

            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("Esports"));

        }

        [Test]
        public void _featuredContent()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            foreach (IWebElement e in sur.featuredContentLinks)
            {
                Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);
                s.KeyDown(Keys.Control).Click(e).Build().Perform();
            }

            IReadOnlyCollection<String> windowIds = SeleniumUno.Main.PropertiesCollection.driver.WindowHandles;
            foreach (string id in windowIds)
            {
                int count = 1;
                SeleniumUno.Main.PropertiesCollection.driver.SwitchTo().Window(id);
                Console.WriteLine($"Link {count}'s URL is: {SeleniumUno.Main.PropertiesCollection.driver.Url}");
            }
        }

        [Test]
        public void _supportLink()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            m = MethodBase.GetCurrentMethod();
            try
            {
                log.Info("Attempting to click on link");
                sur.supportLink.Click();
                log.Debug("Clicked on link successfully.");


            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }
            System.Threading.Thread.Sleep(4000);
            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("support"));
            Base._takesScreenshot(m.Name);
            
        }

        [Test]
        public void _thisWeeksHeadlines()
        {
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            int count = 1;
            int countCheck = 1;
            try
            {
                log.Info("Attempting to open all links");
                foreach(IWebElement link in sur.weekHeadlines)
                {
                    s.KeyDown(Keys.Control).Click(link).Build().Perform();
                }
                log.Debug("Links clicked successfully");
            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }

            countCheck = countCheck + SeleniumUno.Main.PropertiesCollection.driver.WindowHandles.Count;
            foreach(string id in SeleniumUno.Main.PropertiesCollection.driver.WindowHandles)
            {

                SeleniumUno.Main.PropertiesCollection.driver.SwitchTo().Window(id);
                Console.WriteLine($"Url {count} is: {SeleniumUno.Main.PropertiesCollection.driver.Url}");
                count++;
            }

            Assert.That(count == countCheck);
        }

        [Test]
        public void _blogArchive()
        {
            m = MethodBase.GetCurrentMethod();
            log.Info(m);
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            IList<IWebElement> selectOptions = sur.blogArchive.AllSelectedOptions;
            int count = 1;

            foreach(IWebElement option in selectOptions)
            {
                log.Info($"Option number {count} is {option}");
                count++;
            }

        }

        [Test]
        public void _skinSpotlight()
        {
            m = MethodBase.GetCurrentMethod();
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                log.Debug("Attempting to click on link..");
                sur.skinSpotlight.Click();
                log.Info("Link clicked successfully!");
            }
            catch(Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }

            IReadOnlyCollection<string> windowIds = SeleniumUno.Main.PropertiesCollection.driver.WindowHandles;
            foreach(string id in windowIds)
            {
                SeleniumUno.Main.PropertiesCollection.driver.SwitchTo().Window(id);
            }

            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("skinspotlights"));
            Base._takesScreenshot(m.Name);
        }

        [Test]
        public void _footerLinks()
        {
            m = MethodBase.GetCurrentMethod();
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                log.Debug("Attempting to click on links");
                log.Info(SeleniumUno.Standard_Methods.GetMethods.ClickAllLinks(sur.footerLinks));
                log.Info("Links clicked successfully!");
            }
            catch( Exception e)
            {
                log.Error($"Class: {m.ReflectedType.Name} || Method: {m.Name} || Error: {e}");
            }
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            System.Threading.Thread.Sleep(2000);
            SeleniumUno.Main.PropertiesCollection.driver.Quit();
            //Console.ReadLine();
        }
    }

}
