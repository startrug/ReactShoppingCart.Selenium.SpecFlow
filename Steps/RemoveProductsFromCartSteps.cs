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
    class RemoveProductsFromCartSteps : StepsBase
    {
        public RemoveProductsFromCartSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [Given(@"I select number of products to remove: (.*)")]
        public void GivenISelectNumberOfProductsToRemove(int numberOfProducts)
        {
            productsToRemove = Order.ProductsList.Select(p => p).Take(numberOfProducts);
        }

        [When(@"I click on delete button")]
        public void WhenIClickOnDeleteButton()
        {
            productsToRemove.ToList().ForEach(ptr => Cart.Delete(ptr));
        }

        [Then(@"Product is removed from cart")]
        public void ThenProductIsRemovedFromCart()
        {
            productsToRemove.ToList().ForEach(ptr
                => Assert.IsFalse(Cart.GetProductNames().Select(e => e.Text).Contains(ptr.Name)));
        }

        [Then(@"Expected message is present in cart")]
        public void ThenExpectedMessageIsPresentInCart()
        {
            Assert.IsTrue(Cart.NoProductsMessage.Displayed);
        }

        private IEnumerable<Product> productsToRemove;
    }
}
