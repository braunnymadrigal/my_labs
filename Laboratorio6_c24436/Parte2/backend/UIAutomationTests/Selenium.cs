using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class Selenium
    {
        private const int MILISECONDS_TO_WAIT = 2000;
        private const string HOMEPAGE_URL = "http://localhost:8080/";
        private const string COUNTRY_NAME = "Nuevo País Selenium";
        private const string LANGUAGE_NAME = "Idioma Selenium";
        private const string CONFIRMATION_MESSAGE = "País creado con éxito.";

        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public async Task Create_Country_Test()
        {
            try
            {
                // Arrange
                // Maximiza la pantalla.
                _driver.Manage().Window.Maximize();

                // Crea la espera.
                var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(MILISECONDS_TO_WAIT));

                // Act
                // Navega a la página que se necesita probar.
                _driver.Navigate().GoToUrl(HOMEPAGE_URL);
                await CustomTaskWait();

                // Encontrar el botón Agregar país. Luego, Clickear el botón.
                var listButton = _driver.FindElement(By.CssSelector("#app > div > div > div > a > button"));
                listButton.Click();
                await CustomTaskWait();

                // Encontrar el campo Nombre del formulario. Luego, Escribir en dicho campo.
                var formFirstItem = _driver.FindElement(By.Id("name"));
                formFirstItem.SendKeys(COUNTRY_NAME);
                await CustomTaskWait();

                // Encontrar la opción Oceanía dentro del select del formulario. Luego, Seleccionar dicha opción.
                var formSelectOceania = _driver.FindElement(By.CssSelector("#continente > option:nth-child(6)"));
                formSelectOceania.Click();
                await CustomTaskWait();

                // Encontrar el campo Idioma del formulario. Luego, Escribir en dicho campo.
                var formThirdItem = _driver.FindElement(By.Id("idioma"));
                formThirdItem.SendKeys(LANGUAGE_NAME);
                await CustomTaskWait();

                // Encontrar el botón Guardar. Luego, Clickear el botón.
                var formButton = _driver.FindElement(By.CssSelector("#app > div > div > form > div:nth-child(4) > button"));
                formButton.Click();

                // Esperar por el elemento toast. Luego, Encontrar el elemento toast.
                var toast = wait.Until(d => d.FindElement(By.Id("toast")));
                //await CustomTaskWait();

                // Assert
                // Verifica que el elemento toast aparezca en pantalla.
                Assert.IsTrue(toast.Displayed);

                // Verifica que el elemento toast contenga el texto adecuado.
                Assert.That(toast.Text, Is.EqualTo(CONFIRMATION_MESSAGE));
                await CustomTaskWait();

                // Verifica que nos encontremos nuevamente en el homepage.
                Assert.That(_driver.Url, Is.EqualTo(HOMEPAGE_URL));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
        }

        private async Task CustomTaskWait()
        {
            await Task.Delay(MILISECONDS_TO_WAIT);
        }
    }
}
