using System;
using System.Collections.Generic;
using System.Linq;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using ReactShoppingCart.Selenium.SpecFlow.Settings;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    class AddProductsToCartSteps
    {
        private readonly IObjectContainer container;

        private IWebDriver Driver => container.Resolve<IWebDriver>();

        private Order NewOrder => container.Resolve<Order>();

        public string Id { get; set; }

        private Product randomProduct;

        private readonly List<Product> randomProducts = new List<Product>();

        public AddProductsToCartSteps(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        [When(@"I click on random product")]
        public void WhenIClickOnRandomProduct()
        {
            randomProduct = SelectRandomProduct();
            randomProduct.ClickOnPhoto();

            AddAmount(randomProduct.Price);
        }

        [When(@"I click on (.*) random products")]
        public void WhenIClickOnRandomProducts(int number)
        {
            for (int i = 0; i < number; i++)
            {
                randomProducts.Add(SelectRandomProduct());
                AddAmount(randomProducts.ElementAt(i).Price);
                randomProducts.ElementAt(i).Photo.Click();
            }
        }

        private void AddAmount(string price)
        {
            NewOrder.TotalAmount += Double.Parse(price.Remove(0, 1));
        }

        private Product SelectRandomProduct()
        {
            Random random = new Random();

            var allProducts = Driver.FindElements(By.CssSelector(".shelf-container .shelf-item"));

            Id = allProducts[random.Next(allProducts.Count)].GetAttribute("data-sku");

            return new Product(Driver, Id);
        }

        [Then(@"Cart is opened")]
        public void ThenCartIsOpened()
        {
            Assert.That(Driver.FindElement(By.CssSelector(".float-cart--open")).Displayed, Is.True);
        }

        [Then(@"Selected product is present in cart")]
        public void ThenSelectedProductIsPresentInCart()
        {
            var productsInCart = Driver.FindElements(By.CssSelector(".float-cart .shelf-item .title"));
            foreach (var product in randomProducts)
            {
                Assert.That(Driver.FindElements(By.CssSelector(".float-cart .shelf-item .title")).Select(e => e.Text).Contains(product.Name), Is.True);
            }
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.AreEqual(NewOrder.TotalAmount.ToString("F"), Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text.Replace(" ", "").Remove(0, 1));
        }

    }
}
