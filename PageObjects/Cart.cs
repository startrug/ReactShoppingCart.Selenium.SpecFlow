using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class Cart : PageObjectsBase
    {
        public Cart(IWebDriver driver) : base(driver) { }

        public bool IsOpened() => Driver.FindElement(By.CssSelector(".float-cart--open")).Displayed;

        public string GetSubtotal() => Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text.Replace(" ", "").Remove(0, 1);

        public ReadOnlyCollection<IWebElement> GetProductNames() => Driver.FindElements(By.CssSelector(".float-cart .shelf-item .title"));
    }
}