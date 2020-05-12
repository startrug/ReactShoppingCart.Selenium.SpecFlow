using System;
using System.Collections.Generic;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    class AddProductsToCartSteps
    {
        private readonly IObjectContainer container;

        private IWebDriver Driver => container.Resolve<IWebDriver>();

        public string Id { get; set; }

        private Product randomProduct;

        private List<Product> randomProducts = new List<Product>();

        public AddProductsToCartSteps(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        [When(@"I click on random product")]
        public void WhenIClickOnRandomProduct()
        {
            randomProduct = SelectRandomProduct();
            randomProduct
                .Photo
                .Click();
        }

        [When(@"I click on ""(.*)"" random products")]
        public void WhenIClickOnRandomProducts(int number)
        {
            for (int i = 0; i < number; i++)
            {
                randomProducts.Add(SelectRandomProduct());
                randomProducts.ForEach(p => p.Photo.Click());
            }
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
            Assert.AreEqual(randomProduct.Name, Driver.FindElement(By.CssSelector(".float-cart .shelf-item .title ")).Text);
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.AreEqual(randomProduct.Price, Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text.Replace(" ", ""));
        }

    }
}
