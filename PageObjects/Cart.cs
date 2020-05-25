using System.Collections.ObjectModel;
using System.Linq;
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
            foreach (var product in Order.ProductsList)
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

        public void SetQuantity(int targetQuantity, Product product)
        {

            while (GetDescription(product.Name).Quantity > targetQuantity)
            {
                Driver.FindElement(MinusButtonLocator(product.Name)).Click();
            }

            while (GetDescription(product.Name).Quantity < targetQuantity)
            {
                Driver.FindElement(PlusButtonLocator(product.Name)).Click();
            }

            Order.SetAmountUsingQuantity(product.Price, targetQuantity);
        }

        public Description GetDescription(string productName)
        {
            var text = wait.Until(EC.ElementIsVisible(Description(productName))).Text;

            return new Description(text);
        }

        public IWebElement MinusButton(string productName) => Driver.FindElement(MinusButtonLocator(productName));

        private By MinusButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/parent::div/following::div/button[text()='-']");
        private By PlusButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/parent::div/following::div/button[text()='+']");

        private By DeleteButtonLocator(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/preceding::div[contains(@class, 'del')]");

        private By Description(string productName) => By.XPath($"{openedCartXpath}//p[text()='{productName}']/following::p[@class='desc']");

        private readonly string openedCartXpath = "//div[contains(@class, 'cart--open')]";
    }
}