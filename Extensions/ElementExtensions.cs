using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinopticBgTests.Extensions
{
    public static class ElementExtensions
    {
        public static void Type(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);

        }

        public static void HighlightElement(this IWebElement element, IWebDriver driver)
        {
            // Get the original style of the element
            string originalStyle = element.GetAttribute("style");

            // Change the style of the element to highlight it in green
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 5px solid red;');", element);

            // Wait for a short period to see the highlighted element (optional)
            System.Threading.Thread.Sleep(500);

            // Restore the original style of the element
            js.ExecuteScript($"arguments[0].setAttribute('style', '{originalStyle}');", element);
        }

    }
}
