using OpenQA.Selenium;
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
    }
}
