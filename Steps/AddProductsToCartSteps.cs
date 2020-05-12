using System;
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

        private IWebElement _selectedProduct;

        public AddProductsToCartSteps(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        [When(@"I click on random product")]
        public void WhenIClickOnRandomProduct()
        {
            SelectRandomProduct();
            _selectedProduct.Click();
        }

        private void SelectRandomProduct()
        {
            Random random = new Random();

            var allProducts = Driver.FindElements(By.CssSelector(".shelf-item p"));

            _selectedProduct = allProducts[random.Next(allProducts.Count)];
            Console.WriteLine(_selectedProduct.Text);
        }

        [When(@"I open cart")]
        public void WhenIOpenCart()
        {
            Assert.That(Driver.FindElement(By.CssSelector(".float-cart--open")).Displayed, Is.True);
        }

        [Then(@"Selected product is present in cart")]
        public void ThenSelectedProductIsPresentInCart()
        {
            Assert.AreEqual(_selectedProduct.Text, Driver.FindElement(By.CssSelector(".float-cart .shelf-item .title ")).Text);
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.IsTrue(Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Displayed);
            Console.WriteLine(Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text);
        }

    }
}
