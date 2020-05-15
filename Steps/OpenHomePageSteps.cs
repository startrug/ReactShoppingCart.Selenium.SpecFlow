using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using TechTalk.SpecFlow;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
            wait.Until(EC.VisibilityOfAllElementsLocatedBy(By.TagName("img")));
        }

        [Then(@"Home page title ""(.*)"" is correct")]
        public void ThenHomePageIsCorrect(string title)
        {
            Assert.That(title == Driver.Title);
        }

        private HomePage HomePage => container.Resolve<HomePage>();
    }
}
