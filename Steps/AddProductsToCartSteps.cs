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
    class AddProductsToCartSteps : StepsBase
    {
        public string Id { get; set; }

        public AddProductsToCartSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [When(@"I click on (.*) random products")]
        public void WhenIClickOnRandomProducts(int number)
        {
            for (int i = 0; i < number; i++)
            {
                randomProducts.Add(SelectRandomProduct());
                AddAmount(randomProducts.ElementAt(i).Price);

                cart = randomProducts.ElementAt(i).ClickOnPhoto();
            }
        }

        private void AddAmount(string price)
        {
            NewOrder.TotalAmount += Double.Parse(price.Remove(0, 1));
        }

        private Product SelectRandomProduct()
        {
            var random = new Random();
            var products = Driver.FindElements(By.CssSelector(".shelf-container .shelf-item"));

            Id = products[random.Next(products.Count)].GetAttribute("data-sku");

            return new Product(Driver, Id);
        }

        [Then(@"Cart is opened")]
        public void ThenCartIsOpened()
        {
            Assert.IsTrue(cart.IsOpened());
        }

        [Then(@"Selected product is present in cart")]
        public void ThenSelectedProductIsPresentInCart()
        {
            foreach (var product in randomProducts)
            {
                Assert.That(cart.GetProductNames().Select(e => e.Text).Contains(product.Name), Is.True);
            }
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.AreEqual(NewOrder.TotalAmount.ToString("F"), cart.GetSubtotal());
        }

        private Order NewOrder => container.Resolve<Order>();

        private Cart cart;
        private readonly List<Product> randomProducts = new List<Product>();
    }
}
