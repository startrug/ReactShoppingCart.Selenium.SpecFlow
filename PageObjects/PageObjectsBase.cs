using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class PageObjectsBase
    {
        protected IWebDriver Driver;

        public PageObjectsBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}