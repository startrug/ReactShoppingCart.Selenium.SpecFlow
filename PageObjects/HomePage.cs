using System;
using OpenQA.Selenium;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class HomePage : PageObjectsBase
    {
        public string Id { get; set; }
        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
        }

        internal void WaitForImages() => wait.Until(EC.VisibilityOfAllElementsLocatedBy(By.TagName("img")));

        internal Product SelectRandomProduct()
        {
            var random = new Random();
            var products = Driver.FindElements(By.CssSelector(".shelf-container .shelf-item"));

            Id = products[random.Next(products.Count)].GetAttribute("data-sku");

            return new Product(Driver, Id);
        }
    }
}