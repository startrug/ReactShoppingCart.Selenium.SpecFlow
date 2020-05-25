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
            Cart = HomePage.SelectProducts(number);
        }

        [Then(@"Cart is opened")]
        public void ThenCartIsOpened()
        {
            Assert.IsTrue(Cart.IsOpened());
        }

        [Then(@"Selected products are present in cart")]
        public void ThenSelectedProductIsPresentInCart()
        {
            Cart.CheckProducts();
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.AreEqual(Order.GetTotal(), Cart.GetSubtotal());
        }

        [Then(@"I set quantity of products to (.*)")]
        public void ThenIIncreaseAquantityOfProductTo(int newQuantity)
        {
            var product = Order.ProductsList.First();

            Cart.SetQuantity(newQuantity, product);
        }

        [Then(@"Correct quantity of products (.*) is displayed")]
        public void ThenCorrectQuantityOfProductsIsDisplayed(int quantity)
        {
            Assert.AreEqual(quantity, Cart.GetDescription(Order.ProductsList.First().Name).Quantity);
        }

        [Then(@"If quantity equals ""(.*)"" minus button is disabled")]
        public void ThenIfQuantityEqualsMinusButtonIsDisabled(int minimumQuantity)
        {
            if (Cart.GetDescription(Order.ProductsList.First().Name).Quantity > minimumQuantity)
            {
                Assert.True(Cart.MinusButton(Order.ProductsList.First().Name).Enabled);
            }
            else
            {
                Assert.IsFalse(Cart.MinusButton(Order.ProductsList.First().Name).Enabled);
            }
        }
    }
}
