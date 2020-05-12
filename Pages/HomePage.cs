using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.Pages
{
    public class HomePage
    {
        private readonly IWebDriver webDriver;

        public HomePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void GoTo()
        {
            webDriver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
        }
    }
}