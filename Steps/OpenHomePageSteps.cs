using System;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using TechTalk.SpecFlow;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    public class OpenHomePageSteps
    {
        private readonly WebDriverWait wait;
        private readonly IObjectContainer container;

        private IWebDriver Driver => container.Resolve<IWebDriver>();
        private HomePage HomePage => container.Resolve<HomePage>();

        public OpenHomePageSteps(IObjectContainer objectContainer)
        {
            container = objectContainer;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }


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
    }
}
