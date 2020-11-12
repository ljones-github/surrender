using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

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

        public static void _takeFullScreenshot(string fileName, string additional = "")
        {
            //This is using the Noksa.WebDriver.ScreenshotsExtensions nuget package
            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            SeleniumUno.Main.PropertiesCollection.driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save("C:\\Users\\ljone\\source\\repos\\SeleniumUno\\SeleniumUno\\Screenshot(s)\\" + fileName + "__" + additional + ".png");
            
            // This would direct you to the temp folder. 
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public static Boolean verifyUrlConnection(string url, log4net.ILog log)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            Boolean flag = false;
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            if (myHttpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                log.Error($"Error with url: {url}. HttpResponse was {myHttpWebResponse.StatusDescription}");
            }
            else
            {
                log.Info("Url status is OK");
                flag = true;
            }
                
            // Releases the resources of the response.
            myHttpWebResponse.Close();
            return flag;
        }

    }
}
