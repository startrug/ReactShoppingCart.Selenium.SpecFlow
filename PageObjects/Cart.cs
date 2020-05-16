using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class Cart : PageObjectsBase
    {
        public Cart(IWebDriver driver) : base(driver) { }

        public bool IsOpened() => Driver.FindElement(By.CssSelector(".float-cart--open")).Displayed;

        public string GetSubtotal() => Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text.Replace(" ", "").Remove(0, 1);

        public ReadOnlyCollection<IWebElement> GetProductNames() => Driver.FindElements(By.CssSelector(".float-cart .shelf-item .title"));

        internal void IncreaseQuantity(string productName)
        {
            wait
                .Until(EC.ElementToBeClickable(AddButton(productName)))
                .Click();
        }

        private By AddButton(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/parent::div/following::div/button[text()='+']");

        private By Description(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/following::p[@class='desc']");

        private readonly string openedCartXpath = "//div[contains(@class, 'cart--open')]";

        internal Description GetDescription(string productName)
        {
            var text = wait.Until(EC.ElementIsVisible(Description(productName))).Text;

            return new Description(text);
        }

        internal void WaitForUpdate()
        {
            Thread.Sleep(1500);
        }
    }

    internal class Description
    {
        private static string _text;

        public Description(string text)
        {
            _text = text;
        }

        public int Quantity => Int32.Parse(_text.Last().ToString());
    }
}