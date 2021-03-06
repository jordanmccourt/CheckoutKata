﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class FixedAmountPromotionTests
    {
        FixedAmountPromotion promotion = new FixedAmountPromotion("B", 3, 5);

        [TestMethod]
        public void TestFixedAmountPromotion()
        {
            Basket basket = new Basket();
            Product product = new Product("B", 15);

            basket.AddProductToBasket(product, 3);

            int promotionAmount = promotion.GetDiscountAmount(basket.Products);

            Assert.AreEqual(5, promotionAmount);
        }

        [TestMethod]
        public void ApplyPromotion_PromotionNotMet()
        {
            Basket basket = new Basket();
            Product product = new Product("B", 15);

            basket.AddProductToBasket(product, 2);

            int promotionAmount = promotion.GetDiscountAmount(basket.Products);

            Assert.AreEqual(0, promotionAmount);
        }

        [TestMethod]
        public void ApplyPromotion_PromotionExceeded()
        {
            Basket basket = new Basket();
            Product product = new Product("B", 15);

            basket.AddProductToBasket(product, 4);

            int promotionAmount = promotion.GetDiscountAmount(basket.Products);

            Assert.AreEqual(5, promotionAmount);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ApplyPromotion_ProductListNull()
        {
            int promotionAmount = promotion.GetDiscountAmount(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ApplyPromotion_ItemSKUNull()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(new Product(), 1);
           
            FixedAmountPromotion promotion = new FixedAmountPromotion(null, 0, 40);
            promotion.GetDiscountAmount(basket.Products);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplyPromotion_NumberOfItemsZero()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(new Product(), 1);
          
            FixedAmountPromotion promotion = new FixedAmountPromotion("B", 0, 40);
            promotion.GetDiscountAmount(basket.Products);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplyPromotion_PromotionAmountZero()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(new Product(), 1);
            
            FixedAmountPromotion promotion = new FixedAmountPromotion("B", 0, 40);
            promotion.GetDiscountAmount(basket.Products);
        }
    }
}
