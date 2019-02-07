using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public string productName { get; set; }
        public string productLocation { get; set; }
        public decimal productPrice { get; set; }
        public string productType { get; set; }
        public int amountInMachine { get; set; }

        public Product(string location, string name, decimal price, string type)
        {
            productLocation = location;
            productName = name;
            productPrice = price;
            productType = type;
            amountInMachine = 5;
        }

        public Product()
        {
        }
    }
}
