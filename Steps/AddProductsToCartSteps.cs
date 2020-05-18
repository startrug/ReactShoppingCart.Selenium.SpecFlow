using System.Collections.Generic;
using System.Linq;
using BoDi;
using NUnit.Framework;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using ReactShoppingCart.Selenium.SpecFlow.Settings;
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
            quantity = newQuantity;
            var product = randomProducts.First();

            for (int i = 1; i < quantity; i++)
            {
                cart.IncreaseQuantity(product.Name);
                NewOrder.SetAmountUsingQuantity(product.Price, quantity);
            }
            cart.WaitForUpdate();
        }

        [Then(@"Correct quantity of products is displayed")]
        public void ThenCorrectQuantityOfProductsIsDisplayed()
        {
            Assert.AreEqual(quantity, cart.GetDescription(randomProducts.First().Name).Quantity);
        }

        [Then(@"I decrease quantity of products to (.*)")]
        public void ThenIDecreaseQuantityOfProductsTo(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"If quantity equals ""(.*)"" minus button is disabled")]
        public void ThenIfQuantityEqualsMinusButtonIsDisabled(int p0)
        {
            ScenarioContext.Current.Pending();
        }



        private Order NewOrder => container.Resolve<Order>();

        private Cart cart;
        private readonly List<Product> randomProducts = new List<Product>();
        private int quantity;
    }
}
