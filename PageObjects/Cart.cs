using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    internal class Cart
    {
        private IWebDriver Driver;

        public Cart(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}