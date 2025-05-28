using System;
using OpenQA.Selenium;

namespace SeleniumUITestCsharp.WebDriverExtensions
{
    public static class WebDriverExtensions
    {
        // Common Methods or Reusable Methods for page
        public static void EnterText(this IWebDriver driver, By locator, String value)
        {
            IWebElement element = driver.FindElement(locator);
            if (element.Displayed && element.Enabled)
            {
                element.Clear();
                element.SendKeys(value);
            }
        }

        public static void Click(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            if (element.Displayed && element.Enabled)
            {
                element.Click();
            }
        }

        public static bool isElementDisplayed(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            if (element.Displayed)
            {
                return true;
            }
            return true;
        }

        public static String getText(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            var text = "";
            if (element.Displayed)
            {
                text = element.Text;
            }
            return text;
        }

    }
}