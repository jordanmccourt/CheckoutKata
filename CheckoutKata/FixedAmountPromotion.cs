using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// Represents a promotion where prices are discounted to a fixed value if a total number of items are added.
    /// </summary>
    public class FixedAmountPromotion : IPromotion
    {
        public FixedAmountPromotion(string itemSKU, int numberOfItemsRequired, int finalCost)
        {
            if (string.IsNullOrEmpty(itemSKU))
            {
                throw new ArgumentNullException(nameof(itemSKU));
            }

            if (numberOfItemsRequired <= 0)
            {
                throw new ArgumentException(nameof(numberOfItemsRequired));
            }

            if (finalCost <= 0)
            {
                throw new ArgumentException(nameof(finalCost));
            }

            this.ItemSKU = itemSKU;
            this.NumberOfItemsRequired = numberOfItemsRequired;
            this.FinalCost = finalCost;
        }

        /// <summary>
        /// Gets or sets the product that this promotion applies to.
        /// </summary>
        public string ItemSKU { get; set; }

        /// <summary>
        /// Gets or sets the number of items required to meet the promotion.
        /// </summary>
        public int NumberOfItemsRequired { get; set; }

        /// <summary>
        /// Gets or sets the total cost if the <see cref="NumberOfItemsRequired"/> for the promotion is met.
        /// </summary>
        public int FinalCost { get; set; }

        public int ApplyPromotion(List<IProduct> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(this.ItemSKU));
            }

            List<IProduct> applicableProducts = products.Where(x => x.ItemSKU == this.ItemSKU).ToList();
            int numberOfAppliedPromotions = Math.DivRem(applicableProducts.Count, this.NumberOfItemsRequired, out int remainder);

            return numberOfAppliedPromotions * this.FinalCost;
        }
    }
}
