using LandingPageTestsAutomated.BasePage;
using LandingPageTestsAutomated.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace LandingPageTestsAutomated.Tests
{
    [TestClass]
    public class HomeTest : BaseClass
    {
        public HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new HomePage(driver);
        }

        [TestMethod]
        [TestCategory("Validation of the Banner exchange operation by clicking on the 'Fichas de Verificação' button.")]
        [Description("Validation of the Banner exchange operation by clicking on the 'Fichas de Verificação' button.")]
        public void ValidationOfTheBannerExchangeOperationByClickingOnTheFichasDeVerificacaoButton()
        {
            homePage.SelectBanner(homePage.FichasVerificacaoButton);

            string textoDoBanner = driver.FindElement(HomePage.ContainerTextBanner1).Text;
            Assert.IsTrue(textoDoBanner.Contains("Verificações de Serviços e Materiais descomplicadas"), "O texto esperado não foi encontrado no banner.");
        }

        [TestMethod]
        [TestCategory("Validation of the Banner exchange operation by clicking on the 'Segurança do Trabalho' button.")]
        [Description("Validation of the Banner exchange operation by clicking on the 'Segurança do Trabalho' button.")]
        public void ValidationOfTheBannerExchangeOperationByClickingOnTheSegurancaDoTrabalhoButton()
        {
            homePage.SelectBanner(homePage.SegurancaTrabalhoButton);

            string textoDoBanner = driver.FindElement(HomePage.ContainerTextBanner2).Text;
            Assert.IsTrue(textoDoBanner.Contains("Controle e Auditoria de segurança do trabalho"), "O texto esperado não foi encontrado no banner.");
        }

        [TestMethod]
        [TestCategory("Validation of the Banner exchange operation by clicking on the 'Planos de ação' button.")]
        [Description("Validation of the Banner exchange operation by clicking on the 'Planos de ação' button.")]
        public void ValidationOfTheBannerExchangeOperationByClickingOnThePlanosDeAcaoButton()
        {
            homePage.SelectBanner(homePage.PlanosAcaoButton);

            string textoDoBanner = driver.FindElement(HomePage.ContainerTextBanner3).Text;
            Assert.IsTrue(textoDoBanner.Contains("Monte planos de ação para cada não conformidade identificada"), "O texto esperado não foi encontrado no banner.");
        }

        [TestMethod]
        [TestCategory("Validation of the Banner exchange operation by clicking on the 'Dashboards e relatórios' button.")]
        [Description("Validation of the Banner exchange operation by clicking on the 'Dashboards e relatórios' button.")]
        public void ValidationOfTheBannerExchangeOperationByClickingOnTheDashboardsRelatoriosButton()
        {
            homePage.SelectBanner(homePage.DashboardRelatoriosButton);

            string textoDoBanner = driver.FindElement(HomePage.ContainerTextBanner4).Text;
            Assert.IsTrue(textoDoBanner.Contains("Acompanhe os principais resultados da sua gestão de qualidade"), "O texto esperado não foi encontrado no banner.");
        }

        [TestMethod]
        [TestCategory("Validation of the form being filled out correctly.")]
        [Description("Validation of the form being filled out correctly.")]
        public void ValidationOfTheFormBeingFilledOutCorrectly()
        {
            homePage.FillingOutTheAccessFormCorrectly();
            
            IAlert alert = driver.SwitchTo().Alert(); // Muda o foco do Selenium para o alerta
            string alertText = alert.Text; // Captura o texto do alerta

            Assert.IsTrue(alertText.Contains("Obrigado! Seu acesso ao webinar estará disponível no seu e-mail"),
                $"Texto do alerta não contém o esperado. Texto real: '{alertText}'");
            alert.Accept();
        }

        [TestMethod]
        [TestCategory("Validation of form completion incorrectly.")]
        [Description("Validation of form completion incorrectly.")]
        public void ValidationOfFormCompletionIncorrectly()
        {
            homePage.InvalidFormSubmissionAttempt();

            string ErrorMessageEmailInvalid = driver.FindElement(HomePage.ErrorEmailInvalidMessage).Text;
            Assert.IsTrue(ErrorMessageEmailInvalid.Contains("Endereço de e-mail inválido"), "O texto esperado não foi encontrado.");

            string ErrorMessageCelular = driver.FindElement(HomePage.ErrorCelularMessage).Text;
            Assert.IsTrue(ErrorMessageCelular.Contains("Este campo deve ter no mínimo 18 caracteres."), "O texto esperado não foi encontrado.");

        }

        [TestMethod]
        [TestCategory("Validation of the attempt to send the empty form.")]
        [Description("Validation of the attempt to send the empty form.")]
        public void ValidationOfTheAttemptToSendTheEmptyForm()
        {
            homePage.AttemptToSubmitEmptyForm();

            string ErrorMessageName = driver.FindElement(HomePage.ErrorNameMessage).Text;
            Assert.IsTrue(ErrorMessageName.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageEmailEmpty = driver.FindElement(HomePage.ErrorEmailEmptyMessage).Text;
            Assert.IsTrue(ErrorMessageEmailEmpty.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageCelular = driver.FindElement(HomePage.ErrorCelularMessage).Text;
            Assert.IsTrue(ErrorMessageCelular.Contains("Este campo deve ter no mínimo 18 caracteres."), "O texto esperado não foi encontrado.");

            string ErrorMessageEmpresa = driver.FindElement(HomePage.ErrorEmpresaMessage).Text;
            Assert.IsTrue(ErrorMessageEmpresa.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageCargoSeletor = driver.FindElement(HomePage.ErrorCargoSeletorMessage).Text;
            Assert.IsTrue(ErrorMessageCargoSeletor.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageTipoObraSeletor = driver.FindElement(HomePage.ErrorTipoObraSeletorMessage).Text;
            Assert.IsTrue(ErrorMessageTipoObraSeletor.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageQuantidadeObrasSeletor = driver.FindElement(HomePage.ErrorQuantidadeObrasSeletorMessage).Text;
            Assert.IsTrue(ErrorMessageQuantidadeObrasSeletor.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");

            string ErrorMessageOrcamentoObrasSeletor = driver.FindElement(HomePage.ErrorOrcamentoObrasSeletorMessage).Text;
            Assert.IsTrue(ErrorMessageOrcamentoObrasSeletor.Contains("Campo obrigatório"), "O texto esperado não foi encontrado.");
        }
    }
}