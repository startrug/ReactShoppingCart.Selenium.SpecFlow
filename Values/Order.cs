using System;

namespace ReactShoppingCart.Selenium.SpecFlow.Settings
{
    public class Order
    {
        public double TotalAmount { get; set; }

        public void AddAmount(string price)
        {
            TotalAmount += Double.Parse(price.Remove(0, 1));
        }

        public void SetAmountUsingQuantity(string price, int quantity)
        {
            TotalAmount = Double.Parse(price.Remove(0, 1)) * quantity;
        }
    }
}