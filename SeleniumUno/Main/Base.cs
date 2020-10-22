using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno.Main
{
    class Base
    {
        public static void _initializeDriver()
        {
            SeleniumUno.Main.PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public static void _takesScreenshot(string fileName)
        {
            Screenshot src = ((ITakesScreenshot)SeleniumUno.Main.PropertiesCollection.driver).GetScreenshot();
            src.SaveAsFile("C:\\Users\\ljone\\source\\repos\\SeleniumUno\\SeleniumUno\\Screenshot(s)\\" + fileName + ".png");
            //((ITakesScreenshot)SeleniumUno.Main.PropertiesCollection.driver).GetScreenshot().SaveAsFile(fileName);
            //File.Copy(fileName, "C:\\Users\\ljone\\source\\repos\\SeleniumUno\\SeleniumUno\\Screenshot(s)");
        }


    }
}
