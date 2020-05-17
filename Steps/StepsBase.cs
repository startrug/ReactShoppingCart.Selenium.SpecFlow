using BoDi;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    class StepsBase
    {
        protected StepsBase(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        protected IWebDriver Driver => container.Resolve<IWebDriver>();

        protected HomePage HomePage => container.Resolve<HomePage>();

        protected readonly IObjectContainer container;
    }
}
