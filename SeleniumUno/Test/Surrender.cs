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
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno
{
    public class Surrender
    {
        //string methodName;
        SeleniumUno.Main.BrowserType myBrowser = SeleniumUno.Main.BrowserType.Chrome;
        static void Main(string[] args)
        {
            /*Surrender s = new Surrender();
            
            s.navigateToSurrender(testDriver);
            s.countLinks(testDriver);
            s.sendToSearchBox("God-King", testDriver);
            testDriver.Close();*/
        }

        [SetUp]
        public void InitializeDriver()
        {

            if(myBrowser == SeleniumUno.Main.BrowserType.Firefox)
            {
                SeleniumUno.Main.PropertiesCollection.driver = new FirefoxDriver();
            }
            else
            {
                SeleniumUno.Main.PropertiesCollection.driver = new ChromeDriver();
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
            System.Threading.Thread.Sleep(6000);
            //var wait = new WebDriverWait(SeleniumUno.Main.PropertiesCollection.driver, TimeSpan.FromMilliseconds(5000));
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.TagName("a"))));
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            
            foreach (IWebElement link in sur.links)
            {
                Console.WriteLine(SeleniumUno.Standard_Methods.GetMethods.GetUrl(link));
            }
            Console.WriteLine("Number of links on the page is " + sur.links.Count);

            ArrayList myList = new ArrayList(new object[] { "LaRon","James", "Jones"});
            String[] array = (String[])myList.ToArray(typeof(String));

            Dictionary<string, string> supers = new Dictionary<string, string>();
            supers.Add("Superman", "Clark Kent");
            supers.TryGetValue("Superman", out string secretId);
            supers.

        }
        
       [Test]
        public void ClickHomePageButton()
        {
            System.Threading.Thread.Sleep(6000);
            String myUrl = SeleniumUno.Main.PropertiesCollection.driver.Url;
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            WebDriverWait myWait = new WebDriverWait(SeleniumUno.Main.PropertiesCollection.driver, TimeSpan.FromSeconds(3));
            myWait.Until(ExpectedConditions.ElementToBeClickable(sur.homeButton));
            Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);
            Console.WriteLine("Attempting to click on button: log.debug");
            s.Click(sur.homeButton).Build().Perform();
            Console.WriteLine("Button clicked successfully: log.info");
            myWait.Until(ExpectedConditions.ElementToBeClickable(sur.homeButton));
            Assert.IsTrue(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("index.html"), "Failed because " + myUrl + " does NOT contain 'index.html'");


        }


        [Test]
        public void SendToSearchBox()
        {
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            string s = "God-King";
            SeleniumUno.Standard_Methods.SetMethods.EnterText(sur.searchBox, s);
            System.Threading.Thread.Sleep(6000);

            Assert.That(sur.searchBox.GetAttribute("value").Equals(s));
        }

        [Test]
        public void _clickPbe()
        {
            SurrenderAt20HomePage sur = new SurrenderAt20HomePage();
            try
            {
                sur.pbeButton.Click();
                System.Threading.Thread.Sleep(6000);
                Console.WriteLine("Button clicked successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in clicking the element. Desc: " + e);
            }
            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("PBE"));

        }

        [Test]
        public void _clickReleases()
        {
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

            Console.WriteLine("Current Url: {0}",SeleniumUno.Main.PropertiesCollection.driver.Url);
            Assert.That(SeleniumUno.Main.PropertiesCollection.driver.Url.Contains("Red Posts"));

        }

        [Test]
        public void _clickRotations()
        {
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

        [TearDown]
        public void CloseBrowser()
        {
            SeleniumUno.Main.PropertiesCollection.driver.Close();
        }
    }

}
