using System;
using System.Linq;

namespace ReactShoppingCart.Selenium.SpecFlow.Values
{
    public class Description
    {
        private static string _text;

        public Description(string text)
        {
            _text = text;
        }

        public int Quantity => Int32.Parse(_text.Last().ToString());
    }
}
