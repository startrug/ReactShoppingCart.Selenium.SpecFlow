using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.Settings;
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

        internal Product Random()
        {
            var random = new Random();
            var products = Driver.FindElements(By.CssSelector(".shelf-container .shelf-item"));

            Id = products[random.Next(products.Count)].GetAttribute("data-sku");

            return new Product(Driver, Id);
        }

        internal Cart SelectProducts(int number)
        {
            var products = new List<Product>();

            for (int i = 0; i < number; i++)
            {
                products.Add(Random());
                Order.AddAmount(products.ElementAt(i).Price);
                products.ElementAt(i).ClickOnPhoto();
            }

            Order.ProductsList = products;

            return new Cart(Driver);
        }
    }
}