using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Basket : IBasket
    {
        public Basket()
        {
            this.Products = new List<IProduct>();
        }

        public List<IProduct> Products { get; set; }

        public void AddProductToBasket(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            this.Products.Add(product);
        }

        public int CalculateTotalPrice()
        {
            return this.Products.Sum(x => x.UnitPrice);
        }
    }
}
