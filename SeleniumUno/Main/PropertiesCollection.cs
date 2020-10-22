using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUno.Main
{

    enum BrowserType
    {
        Firefox,
        Chrome,
        Safari,
        InternetExplorer

    }
    class PropertiesCollection
    {
        //Auto-implemented property
        public static IWebDriver driver { get; set; }

        

    }
}
