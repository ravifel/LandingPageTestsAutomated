using System.Threading;
using OpenQA.Selenium;
using SeleniumUITestCsharp.WebDriverExtensions;

namespace LandingPageTestsAutomated.Pages
{
    public class HomePage
    {
        public static IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            HomePage.driver = driver;
        }

        // Components
        public static readonly By AcceptCookiesButton = By.CssSelector("a[aria-label='allow cookies']");

                    // Banners
        public By FichasVerificacaoButton = By.XPath("//span[normalize-space()='Fichas de Verificação']");
        public By SegurancaTrabalhoButton = By.XPath("//span[normalize-space()='Segurança do Trabalho']");
        public By PlanosAcaoButton = By.XPath("//span[normalize-space()='Planos de ação']");
        public By DashboardRelatoriosButton = By.XPath("//span[normalize-space()='Dashboards e relatórios']");
        public static readonly By ContainerTextBanner1 = By.CssSelector("#comp-ma2l888s4 span.wixui-rich-text__text");
        public static readonly By ContainerTextBanner2 = By.CssSelector("#comp-ma2l8884 span.wixui-rich-text__text");
        public static readonly By ContainerTextBanner3 = By.XPath("//div[@data-testid='richTextElement']//h2/span[contains(text(),'Monte planos de ação')]");
        public static readonly By ContainerTextBanner4 = By.XPath("//span[contains(text(),'Acompanhe os principais resultados')]");

                    // Form
        public static readonly By FormDemostracaoButton = By.XPath("//span[contains(text(),'Quero uma demonstração')]");
        public static readonly By IframeFormulario = By.CssSelector("iframe[name='htmlComp-iframe']");
        public static readonly By NameFieldForm = By.CssSelector("#rd-text_field-m0r4qe9l");
        public static readonly By EmailFieldForm = By.CssSelector("#rd-email_field-m0r4qe9m");
        public static readonly By CelularFieldForm = By.CssSelector("#rd-phone_field-m0r4qe9n");
        public static readonly By EmpresaFieldForm = By.CssSelector("#rd-text_field-m0r4qe9o");
        public static readonly By CargoSelectorFieldForm = By.CssSelector("#rd-select_field-m0r4qe9p");
        public static readonly By TipoObraSelectorFieldForm = By.CssSelector("#rd-select_field-m0r4qe9q");
        public static readonly By QuantidadeObrasSelectorFieldForm = By.CssSelector("#rd-select_field-m0r4qe9r");
        public static readonly By OrcamentoObrasSelectorFieldForm = By.CssSelector("#rd-select_field-m0r4qe9s");
        public static readonly By SendFormButton = By.Id("rd-button-lanvjyf1");
        public static readonly By ErrorNameMessage = By.XPath("//label[@for='rd-text_field-m0r4qe9l'][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorEmailEmptyMessage = By.XPath("//label[contains(@for,'rd-email_field-m0r4qe9m')][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorEmailInvalidMessage = By.XPath("//label[normalize-space()='Endereço de e-mail inválido']");
        public static readonly By ErrorCelularMessage = By.XPath("//label[normalize-space()='Este campo deve ter no mínimo 18 caracteres.']");
        public static readonly By ErrorEmpresaMessage = By.XPath("//label[contains(@for,'rd-text_field-m0r4qe9o')][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorCargoSeletorMessage = By.XPath("//label[contains(@for,'rd-select_field-m0r4qe9p')][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorTipoObraSeletorMessage = By.XPath("//label[contains(@for,'rd-select_field-m0r4qe9q')][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorQuantidadeObrasSeletorMessage = By.XPath("//label[contains(@for,'rd-select_field-m0r4qe9r')][normalize-space()='Campo obrigatório']");
        public static readonly By ErrorOrcamentoObrasSeletorMessage = By.XPath("//label[contains(@for,'rd-select_field-m0r4qe9s')][normalize-space()='Campo obrigatório']");

        // Methods
        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickMethod(By component)
        {
            driver.Click(component);
        }


        public void FillingOutTheAccessFormCorrectly()
        {
            driver.Click(AcceptCookiesButton);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            driver.Click(FormDemostracaoButton);
            Thread.Sleep(5000);

            // Troca do foco para o iframe
            var iframe = driver.FindElement(IframeFormulario);
            driver.SwitchTo().Frame(iframe);

            driver.FindElement(NameFieldForm).SendKeys("Matheus Jorge Duarte Teste");
            driver.FindElement(EmailFieldForm).SendKeys("matheus_jorge_duarte@quarttus.com.br");
            driver.FindElement(CelularFieldForm).SendKeys("1135717499");
            driver.FindElement(EmpresaFieldForm).SendKeys("Empresa Teste Natheus Jorge Teste");

            driver.FindElement(CargoSelectorFieldForm).Click();
            driver.FindElement(CargoSelectorFieldForm).SendKeys(Keys.Down);
            driver.FindElement(CargoSelectorFieldForm).SendKeys(Keys.Enter);

            driver.FindElement(TipoObraSelectorFieldForm).Click();
            driver.FindElement(TipoObraSelectorFieldForm).SendKeys(Keys.Down);
            driver.FindElement(TipoObraSelectorFieldForm).SendKeys(Keys.Enter);

            driver.FindElement(QuantidadeObrasSelectorFieldForm).Click();
            driver.FindElement(QuantidadeObrasSelectorFieldForm).SendKeys(Keys.Down);
            driver.FindElement(QuantidadeObrasSelectorFieldForm).SendKeys(Keys.Enter);

            driver.FindElement(OrcamentoObrasSelectorFieldForm).Click();
            driver.FindElement(OrcamentoObrasSelectorFieldForm).SendKeys(Keys.Down);
            driver.FindElement(OrcamentoObrasSelectorFieldForm).SendKeys(Keys.Enter);

            driver.FindElement(SendFormButton).Click();
            Thread.Sleep(2000);
        }

        public void AttemptToSubmitEmptyForm()
        {
            driver.Click(AcceptCookiesButton);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            driver.Click(FormDemostracaoButton);
            Thread.Sleep(4000);

            // Troca do foco para o iframe
            var iframe = driver.FindElement(IframeFormulario);
            driver.SwitchTo().Frame(iframe);

            driver.FindElement(SendFormButton).Click();
            Thread.Sleep(2000);
        }

        public void InvalidFormSubmissionAttempt()
        {
            driver.Click(AcceptCookiesButton);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            driver.Click(FormDemostracaoButton);
            Thread.Sleep(4000);

            // Troca do foco para o iframe
            var iframe = driver.FindElement(IframeFormulario);
            driver.SwitchTo().Frame(iframe);

            driver.FindElement(EmailFieldForm).SendKeys("Email in invalid format");
            driver.FindElement(CelularFieldForm).SendKeys("1234");

            driver.FindElement(SendFormButton).Click();
            Thread.Sleep(2000);
        }

        public void SelectBanner(By buttonBanner)
        {
            driver.Click(AcceptCookiesButton);
            Thread.Sleep(2000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 800);");

            driver.Click(buttonBanner);
            Thread.Sleep(2000);
        }
    }
}