﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        public SurrenderAt20HomePage()
        {
            //Initializes the driver to have waits
            Base._initializeDriver();
            PageFactory.InitElements(SeleniumUno.Main.PropertiesCollection.driver, this);
        }
    }
}