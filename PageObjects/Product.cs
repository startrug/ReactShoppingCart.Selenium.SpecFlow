using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    internal class Product : PageObjectsBase
    {
        public Product(IWebDriver driver, string id) : base(driver)
        {
            Id = id;
        }

        public string Name => GetElement(By.CssSelector($"[data-sku='{Id}'] p")).Text;

        private IWebElement GetElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public string Price => Driver.FindElement(By.CssSelector($"[data-sku='{Id}'] .val")).Text;

        public IWebElement Photo => Driver.FindElement(By.CssSelector($"[data-sku='{Id}'] img"));

        public Cart ClickOnPhoto()
        {
            Photo.Click();

            return new Cart(Driver);
        }

        private readonly string Id;
    }
}