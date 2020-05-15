using OpenQA.Selenium;

namespace ReactShoppingCart.Selenium.SpecFlow.PageObjects
{
    public class HomePage : PageObjectsBase
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
        }
    }
}