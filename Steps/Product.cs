using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    internal class Product
    {
        private readonly IWebDriver Driver;
        private readonly string Id;

        public Product(IWebDriver driver, string id)
        {
            Driver = driver;
            Id = id;
        }

        public string Name
        {
            get => GetName(Id);
        }
        public string Price
        {
            get => GetPrice(Id);
        }

        public IWebElement Photo
        {
            get => GetPhoto(Id);
        }

        public string GetName(string id) => Driver.FindElement(By.CssSelector($"[data-sku='{id}'] p")).Text;

        public string GetPrice(string id) => Driver.FindElement(By.CssSelector($"[data-sku='{id}'] .val")).Text;

        public IWebElement GetPhoto(string id) => Driver.FindElement(By.CssSelector($"[data-sku='{id}'] img"));
    }
}