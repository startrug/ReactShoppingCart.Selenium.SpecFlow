using BoDi;
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
            //ScenarioContext.Current.Pending();
        }

        [When(@"I click on delete button")]
        public void WhenIClickOnDeleteButton()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Product is removed from cart")]
        public void ThenProductIsRemovedFromCart()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Expected message is present in cart")]
        public void ThenExpectedMessageIsPresentInCart()
        {
            //ScenarioContext.Current.Pending();
        }

    }
}
