using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            driver = new ChromeDriver();
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();
            objectContainer.Dispose();
        }

        private IWebDriver driver;

        private readonly IObjectContainer objectContainer;
    }
}
