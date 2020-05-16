using BoDi;
using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.Steps
{
    class StepsBase
    {
        protected StepsBase(IObjectContainer objectContainer)
        {
            container = objectContainer;
        }

        protected IWebDriver Driver => container.Resolve<IWebDriver>();

        protected readonly IObjectContainer container;
    }
}
