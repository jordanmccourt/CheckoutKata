using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Basket : IBasket
    {
        public Basket() : this(new List<IPromotion>())
        {            
        }

        public Basket(List<IPromotion> promotions)
        {
            this.Products = new List<IProduct>();
            this.Promotions = promotions;
        }

        public List<IProduct> Products { get; set; }
        public List<IPromotion> Promotions { get; set; }

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
            int totalDiscount = 0;
            this.Promotions.ForEach(x => totalDiscount += x.GetDiscountAmount(this.Products));
                
            return this.Products.Sum(x => x.UnitPrice) - totalDiscount;
        }
    }
}
