using BoDi;
using NUnit.Framework;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    class OpenHomePageSteps : StepsBase
    {
        public OpenHomePageSteps(IObjectContainer objectContainer) : base(objectContainer) { }

        [Given(@"I enter to home page")]
        public void GivenIEnterToHomePage()
        {
            HomePage.GoTo();
        }

        [When(@"Home page is loaded")]
        public void WhenHomePageIsLoaded()
        {
            HomePage.WaitForImages();
        }

        [Then(@"Home page title ""(.*)"" is correct")]
        public void ThenHomePageIsCorrect(string title)
        {
            Assert.That(title == Driver.Title);
        }
    }
}
