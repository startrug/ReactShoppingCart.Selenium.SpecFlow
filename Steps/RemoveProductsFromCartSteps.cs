using System.Linq;
using BoDi;
using NUnit.Framework;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    class RemoveProductsFromCartSteps : StepsBase
    {
        public RemoveProductsFromCartSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [Given(@"I select product to remove")]
        public void GivenISelectProductToRemove()
        {
            productName = Cart.GetProductNames().Select(p => p.Text).First();
        }

        [When(@"I click on delete button")]
        public void WhenIClickOnDeleteButton()
        {
            Cart.Delete(Product.List.First());
        }

        [Then(@"Product is removed from cart")]
        public void ThenProductIsRemovedFromCart()
        {
            Assert.That(Cart.GetProductNames().Select(e => e.Text).Contains(productName), Is.False);
        }

        [Then(@"Expected message is present in cart")]
        public void ThenExpectedMessageIsPresentInCart()
        {
            Assert.IsTrue(Cart.NoProductsMessage.Displayed);
        }

        private string productName;

    }
}
