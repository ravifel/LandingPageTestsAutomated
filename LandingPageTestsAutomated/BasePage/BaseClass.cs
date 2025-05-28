using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LandingPageTestsAutomated.BasePage
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public TestContext TestContext { get; set; } // Para acessar o nome do teste, status e etc.
        [TestInitialize]

        public void Init()
        {
            KillDriverProcesses(); // (Opcional) Finaliza processos travados do ChromeDriver

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Inicia com a janela maximizada

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90); // Tempo máximo de carregamento da página
            driver.Navigate().GoToUrl("https://www.agilean.com.br/qualidade-old");
            driver.Manage().Window.Maximize();

            // Aguarda o carregamento completo da página (document.readyState === "complete")
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [TestCleanup]
        public void Cleanup() 
        {
            // Captura screenshot se o teste falhar
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                string filePath = Path.Combine(screenshotsDir, $"{TestContext.TestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

                Console.WriteLine($"Screenshot salvo em: {filePath}");
            }

            if (driver != null)
            {
                try
                {
                    driver.Quit(); // Encerra a sessão do navegador corretamente
                    driver.Dispose(); // Libera memória e recursos
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao finalizar o WebDriver: " + e.Message);
                }
            }
        }

        // Mata processos zumbis do ChromeDriver entre execuções consecutivas
        private void KillDriverProcesses()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao matar processo do ChromeDriver: " + ex.Message);
                }
            }

        }

        }
}