using System.Collections.Generic;
using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class Product : PageObjectsBase
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

        public static List<Product> List { get; set; }

        public void ClickOnPhoto() => Photo.Click();

        private readonly string Id;
    }
}