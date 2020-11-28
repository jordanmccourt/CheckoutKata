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

        public void AddProductToBasket(IProduct product, int numberToAdd)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
                        
            if (numberToAdd <= 0)
            {
                throw new ArgumentException(nameof(numberToAdd));
            }

            foreach (var i in Enumerable.Range(0, numberToAdd))
            {
                this.Products.Add(product);
            }
        }

        public int CalculateTotalPrice()
        {
            return this.Products.Sum(x => x.UnitPrice);
        }
    }
}
