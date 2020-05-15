using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    class StepsBase
    {
        protected StepsBase(IObjectContainer objectContainer)
        {
            container = objectContainer;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected IWebDriver Driver => container.Resolve<IWebDriver>();

        protected readonly IObjectContainer container;

        protected readonly WebDriverWait wait;
    }
}
