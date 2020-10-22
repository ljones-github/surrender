using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno.Standard_Methods
{
    class SetMethods
    {

        public static void EnterText(IWebElement element, string textToSend)
        {
            Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);
            s.Click(element).SendKeys(element, textToSend).Build().Perform();
        }

        public static void SelectDropDown(By elementLocator, string value)
        {
            SelectElement se = new SelectElement(SeleniumUno.Main.PropertiesCollection.driver.FindElement(elementLocator));
            
        }
    }
}
