using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReactShoppingCart.Selenium.SpecFlow.Pages;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Settings
{
    [Binding]
    public class TestsHook
    {
        public TestsHook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs(driver);
        }

        public void OpenHomePage()
        {
            homePage = new HomePage(driver);
            objectContainer.RegisterInstanceAs(homePage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();
            objectContainer.Dispose();
        }

        private IWebDriver driver;

        private HomePage homePage;

        private readonly IObjectContainer objectContainer;
    }
}
