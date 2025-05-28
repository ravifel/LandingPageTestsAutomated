using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace LandingPageTestsAutomated.BasePage
{
    // Initialize the driver - Setup driver
    // Reusable methods
    public class BaseClass
    {
        public static IWebDriver driver;
        [TestInitialize]

        public void Init()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Inicia com a janela maximizada

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.agilean.com.br/qualidade-old");
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup() 
        {
            driver.Close();
        }

    }
}