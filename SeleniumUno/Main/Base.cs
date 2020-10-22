using System;
using System.Collections.Generic;
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


    }
}
