using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno.Standard_Methods
{
    class GetMethods
    {
        public static String GetText(IWebElement myElement)
        {
            String eleText = myElement.Text;

            return eleText;
        }

        public static String GetUrl(IWebElement myElement)
        {
            String url = myElement.GetAttribute("href");

            return url;
        }

        public static string ClickAllLinks(IList<IWebElement> myEleList)
        {
            int windowCount = 1;
            string msg = "";
            foreach(IWebElement element in myEleList)
            {
                Actions s = new Actions(SeleniumUno.Main.PropertiesCollection.driver);
                s.KeyDown(Keys.Control).Click(element).Build().Perform();
            }

            foreach(string id in SeleniumUno.Main.PropertiesCollection.driver.WindowHandles)
            {
                SeleniumUno.Main.PropertiesCollection.driver.SwitchTo().Window(id);
                msg += $"Window {windowCount} url is {SeleniumUno.Main.PropertiesCollection.driver.Url}/n";
                windowCount++;
            }

            return msg;
        }
    }
}
