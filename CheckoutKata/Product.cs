using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Product : IProduct
    {
        public Product()
        {
        }

        public Product(string itemSKU, int unitPrice)
        {
            this.ItemSKU = itemSKU;
            this.UnitPrice = unitPrice;
        }

        public string ItemSKU { get; set; }
        public int UnitPrice { get; set; }
    }
}
