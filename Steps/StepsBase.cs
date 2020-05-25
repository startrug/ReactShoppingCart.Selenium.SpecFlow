using System.Collections.Generic;
using BoDi;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    [Binding]
    abstract class StepsBase
    {
        protected StepsBase(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        protected IWebDriver Driver => container.Resolve<IWebDriver>();

        protected HomePage HomePage => container.Resolve<HomePage>();

        protected readonly IObjectContainer container;

        protected Cart Cart
        {
            get => container.Resolve<Cart>();
            set { }
        }
    }
}
