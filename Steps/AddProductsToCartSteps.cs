using System.Collections.Generic;
using System.Linq;
using BoDi;
using NUnit.Framework;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using ReactShoppingCart.Selenium.SpecFlow.Settings;
using ReactShoppingCart.Selenium.SpecFlow.Values;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    class AddProductsToCartSteps : StepsBase
    {
        public AddProductsToCartSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [When(@"I click on (.*) random products")]
        public void WhenIClickOnRandomProducts(int number)
        {
            for (int i = 0; i < number; i++)
            {
                randomProducts.Add(HomePage.SelectRandomProduct());
                NewOrder.AddAmount(randomProducts.ElementAt(i).Price);

                cart = randomProducts.ElementAt(i).ClickOnPhoto();
            }
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

        [Then(@"I increase quantity of products to (.*)")]
        public void ThenIIncreaseAquantityOfProductTo(int newQuantity)
        {
            greaterQuantity = newQuantity;
            var product = randomProducts.First();

            for (int i = 1; i < greaterQuantity; i++)
            {
                cart.SetQuantity(ChangeType.Increase, product.Name);
                NewOrder.SetAmountUsingQuantity(product.Price, greaterQuantity);
            }
            cart.WaitForUpdate();
        }

        [Then(@"Correct quantity of products (.*) is displayed")]
        public void ThenCorrectQuantityOfProductsIsDisplayed(int quantity)
        {
            Assert.AreEqual(quantity, cart.GetDescription(randomProducts.First().Name).Quantity);
        }

        [Then(@"I decrease quantity of products to (.*)")]
        public void ThenIDecreaseQuantityOfProductsTo(int newQuantity)
        {
            lessQuantity = newQuantity;
            var product = randomProducts.First();

            for (int i = greaterQuantity; i > lessQuantity; i--)
            {
                cart.SetQuantity(ChangeType.Decrease, product.Name);
                NewOrder.SetAmountUsingQuantity(product.Price, lessQuantity);
            }
            cart.WaitForUpdate();
        }

        [Then(@"If quantity equals ""(.*)"" minus button is disabled")]
        public void ThenIfQuantityEqualsMinusButtonIsDisabled(int minimumQuantity)
        {
            if (cart.GetDescription(randomProducts.First().Name).Quantity > minimumQuantity)
            {
                Assert.True(cart.MinusButton(randomProducts.First().Name).Enabled);
            }
            else
            {
                Assert.IsFalse(cart.MinusButton(randomProducts.First().Name).Enabled);
            }
        }

        private Order NewOrder => container.Resolve<Order>();

        private Cart cart;
        private readonly List<Product> randomProducts = new List<Product>();
        private int greaterQuantity;
        private int lessQuantity;
    }
}
