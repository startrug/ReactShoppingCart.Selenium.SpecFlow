using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
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

        public void InitializeNewOrder()
        {
            order = new Order();
            objectContainer.RegisterInstanceAs(order);
            cart = new Cart(driver);
            objectContainer.RegisterInstanceAs(cart);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Order.TotalAmount = 0;
            driver.Close();
            driver.Dispose();
            objectContainer.Dispose();
        }

        private IWebDriver driver;

        private HomePage homePage;
        private Order order;
        private Cart cart;

        private readonly IObjectContainer objectContainer;
    }
}
