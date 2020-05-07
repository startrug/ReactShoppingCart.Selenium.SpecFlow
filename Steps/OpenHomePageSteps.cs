using System;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public OpenHomePageSteps(IObjectContainer objectContainer)
        {
            container = objectContainer;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }


        [Given(@"I enter to ""(.*)"" page")]
        public void GivenIEnterToPage(string pageName)
        {
            var url = string.Empty;

            if (pageName == "home")
            {
                url = "https://react-shopping-cart-67954.firebaseapp.com/";
            }

            Driver.Navigate().GoToUrl(url);
        }

        [When(@"Home page is loaded")]
        public void WhenHomePageIsLoaded()
        {
            wait.Until(EC.VisibilityOfAllElementsLocatedBy(By.TagName("img")));
        }

        [Then(@"Home page title ""(.*)"" is correct")]
        public void ThenHomePageIsCorrect(string title)
        {
            Assert.That(title == this.Driver.Title);
        }


    }
}
