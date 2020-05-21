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
            Cart = HomePage.SelectProducts(number);
        }

        [Then(@"Cart is opened")]
        public void ThenCartIsOpened()
        {
            Assert.IsTrue(Cart.IsOpened());
        }

        [Then(@"Selected product is present in cart")]
        public void ThenSelectedProductIsPresentInCart()
        {
            foreach (var product in Product.List)
            {
                Assert.That(Cart.GetProductNames().Select(e => e.Text).Contains(product.Name), Is.True);
            }
        }

        [Then(@"Correct total amount is displayed")]
        public void ThenCorrectTotalAmountIsDisplayed()
        {
            Assert.AreEqual(Order.TotalAmount.ToString("F"), Cart.GetSubtotal());
        }

        [Then(@"I increase quantity of products to (.*)")]
        public void ThenIIncreaseAquantityOfProductTo(int newQuantity)
        {
            greaterQuantity = newQuantity;
            var product = Product.List.First();

            for (int i = 1; i < greaterQuantity; i++)
            {
                Cart.SetQuantity(ChangeType.Increase, product.Name);
                NewOrder.SetAmountUsingQuantity(product.Price, greaterQuantity);
            }
            Cart.WaitForUpdate();
        }

        [Then(@"Correct quantity of products (.*) is displayed")]
        public void ThenCorrectQuantityOfProductsIsDisplayed(int quantity)
        {
            Assert.AreEqual(quantity, Cart.GetDescription(Product.List.First().Name).Quantity);
        }

        [Then(@"I decrease quantity of products to (.*)")]
        public void ThenIDecreaseQuantityOfProductsTo(int newQuantity)
        {
            lessQuantity = newQuantity;
            var product = Product.List.First();

            for (int i = greaterQuantity; i > lessQuantity; i--)
            {
                Cart.SetQuantity(ChangeType.Decrease, product.Name);
                NewOrder.SetAmountUsingQuantity(product.Price, lessQuantity);
            }
            Cart.WaitForUpdate();
        }

        [Then(@"If quantity equals ""(.*)"" minus button is disabled")]
        public void ThenIfQuantityEqualsMinusButtonIsDisabled(int minimumQuantity)
        {
            if (Cart.GetDescription(Product.List.First().Name).Quantity > minimumQuantity)
            {
                Assert.True(Cart.MinusButton(Product.List.First().Name).Enabled);
            }
            else
            {
                Assert.IsFalse(Cart.MinusButton(Product.List.First().Name).Enabled);
            }
        }

        private Order NewOrder => container.Resolve<Order>();

        private int greaterQuantity;
        private int lessQuantity;
    }
}
