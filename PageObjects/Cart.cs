using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using ReactShoppingCart.Selenium.SpecFlow.Settings;
using ReactShoppingCart.Selenium.SpecFlow.Values;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class Cart : PageObjectsBase
    {
        public IWebElement NoProductsMessage => wait.Until(EC.ElementIsVisible(By.CssSelector(".shelf-empty")));

        public Cart(IWebDriver driver) : base(driver) { }

        public bool IsOpened() => Driver.FindElement(By.CssSelector(".float-cart--open")).Displayed;

        public string GetSubtotal() => Driver.FindElement(By.CssSelector(".float-cart .sub-price p")).Text.Replace(" ", "").Remove(0, 1);

        public void CheckProducts()
        {
            foreach (var product in Product.List)
            {
                Assert.That(GetProductNames().Select(e => e.Text).Contains(product.Name), Is.True);
            }
        }

        internal void Delete(Product productToRemove)
        {
            wait
                .Until(EC.ElementToBeClickable(DeleteButtonLocator(productToRemove.Name)))
                .Click();
            Order.SubtractAmount(productToRemove.Price);
        }

        public ReadOnlyCollection<IWebElement> GetProductNames() => Driver.FindElements(By.CssSelector(".float-cart .shelf-item .title"));

        public void SetQuantity(ChangeType type, string productName)
        {
            wait
                .Until(EC.ElementToBeClickable(ChangeQuantity(type, productName)))
                .Click();
        }

        public Description GetDescription(string productName)
        {
            var text = wait.Until(EC.ElementIsVisible(Description(productName))).Text;

            return new Description(text);
        }

        public IWebElement MinusButton(string productName) => Driver.FindElement(MinusButtonLocator(productName));

        public void WaitForUpdate()
        {
            Thread.Sleep(1500);
        }

        private By ChangeQuantity(ChangeType type, string productName)
        {
            switch (type)
            {
                case ChangeType.Increase:
                    return PlusButtonLocator(productName);
                case ChangeType.Decrease:
                    return MinusButtonLocator(productName);
                default:
                    throw new Exception("Incorrect change quantity type");
            }
        }

        private By MinusButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/parent::div/following::div/button[text()='-']");
        private By PlusButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/parent::div/following::div/button[text()='+']");

        private By DeleteButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/preceding::div[contains(@class, 'del')]");

        private By Description(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/following::p[@class='desc']");

        private readonly string openedCartXpath = "//div[contains(@class, 'cart--open')]";
    }
}