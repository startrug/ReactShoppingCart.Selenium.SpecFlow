using System;
using System.Collections.Generic;
using ReactShoppingCart.Selenium.SpecFlow.PageObjects;

namespace ReactShoppingCart.Selenium.SpecFlow.Settings
{
    public class Order
    {
        public static double TotalAmount { get; set; }

        public static List<Product> ProductsList { get; set; }

        public static void AddAmount(string price)
        {
            TotalAmount += ConvertToNumber(price);
        }

        public static void SetAmountUsingQuantity(string price, int quantity)
        {
            TotalAmount = ConvertToNumber(price) * quantity;
        }

        public static void SubtractAmount(string price)
        {
            TotalAmount -= ConvertToNumber(price);
        }

        public static string GetTotal() => TotalAmount.ToString("F");

        private static double ConvertToNumber(string price) => Double.Parse(price.Remove(0, 1));
    }
}