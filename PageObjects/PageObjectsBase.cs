using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class PageObjectsBase
    {
        public PageObjectsBase(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected IWebDriver Driver;
        protected readonly WebDriverWait wait;
    }
}