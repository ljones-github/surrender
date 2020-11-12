using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno.Main
{
    class SurrenderAt20HomePage
    {

        [FindsBy(How = How.CssSelector, Using = "[class='menu-home-active']")]  
        protected internal IWebElement homeButton{ get; set; }

        [FindsBy(How = How.TagName, Using = "a")]
        protected internal IList<IWebElement> links { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='q']")]
        protected internal IWebElement searchBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".menu-pbe")]
        protected internal IWebElement pbeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".menu-releases")]
        protected internal IWebElement releasesButton;

        [FindsBy(How = How.CssSelector, Using = ".menu-redposts")]
        protected internal IWebElement redPostsButton;

        [FindsBy(How = How.CssSelector, Using = ".menu-rotations")]
        protected internal IWebElement rotationsButton;

        [FindsBy(How = How.CssSelector, Using = ".menu-esports")]
        protected internal IWebElement esportsButton;

        protected internal IList<IWebElement> featuredContentLinks => SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.XPath("//div[@id='HTML5']/div[1]/a"));

        protected internal IWebElement supportLink => SeleniumUno.Main.PropertiesCollection.driver.FindElement(By.XPath("//div[@class='widget-content']/a/h4"));

        protected internal IList<IWebElement> weekHeadlines => SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.XPath("//div[@id='popularpostsbody']/ul/li"));

        protected internal SelectElement blogArchive => new SelectElement(SeleniumUno.Main.PropertiesCollection.driver.FindElement(By.CssSelector("#BlogArchive2_ArchiveMenu")));

        protected internal IWebElement submitSearch => SeleniumUno.Main.PropertiesCollection.driver.FindElement(By.XPath("//td[@class='gsc-search-button']"));

        protected internal IWebElement skinSpotlight => SeleniumUno.Main.PropertiesCollection.driver.FindElement(By.CssSelector("a[href*='skinspotlights']"));

        protected internal IList<IWebElement> footerLinks => SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.XPath(("//div[@id='footer-content']/a")));
        
        protected internal IReadOnlyCollection<IWebElement> continueReadings => SeleniumUno.Main.PropertiesCollection.driver.FindElements(By.XPath("//*[text()='CONTINUE READING »']"));
        public SurrenderAt20HomePage()
        {
            //Initializes the driver to have waits
            Base._initializeDriver();
            PageFactory.InitElements(SeleniumUno.Main.PropertiesCollection.driver, this);
        }
    }
}
