using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class BasketTests
    {
        Product productA = new Product("A", 10);
        Product productB = new Product("B", 15);
        Product productC = new Product("C", 40);
        Product productD = new Product("D", 55);

        List<IPromotion> promotions = new List<IPromotion>() { new FixedAmountPromotion("B", 3, 5) };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddProduct_ProductNull()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProduct_NumberToAddNotPositive()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 0);
        }

        [TestMethod]
        public void AddProduct()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 1);

            Assert.IsTrue(basket.Products.Contains(productA));
        }

        [TestMethod]
        public void AddProduct_MultipleAdd()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 2);

            Assert.IsTrue(basket.Products.Contains(productA) && basket.Products.Count == 2);
        }

        [TestMethod]
        public void CalculateBasketTotal_Empty()
        {
            Basket basket = new Basket(promotions);
            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(0, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_OneItem()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 1);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(10, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_MultipleItems()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 1);
            basket.AddProductToBasket(productB, 1);
            basket.AddProductToBasket(productC, 1);
            basket.AddProductToBasket(productD, 1);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(120, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_FixedAmountPromotionsMetButNotProvided()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productB, 3);

            int totalPrice = basket.CalculateTotalPrice();
            Assert.AreEqual(45, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_FixedAmountPromotionsMet()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productB, 3);

            int totalPrice = basket.CalculateTotalPrice();
            Assert.AreEqual(40, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_FixedAmountPromotionsExceeded()
        {
            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productB, 5);

            int totalPrice = basket.CalculateTotalPrice();
            Assert.AreEqual(70, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_MultipleFixedAmountPromotions()
        {
            List<IPromotion> promotions = new List<IPromotion>() { new FixedAmountPromotion("A", 2, 5), new FixedAmountPromotion("C", 3, 15) };

            Basket basket = new Basket(promotions);
            basket.AddProductToBasket(productA, 5); // Total 50, discount 10 = 40
            basket.AddProductToBasket(productB, 1); // Total 15, discount 0 = 15
            basket.AddProductToBasket(productC, 4); // Total 160, discount 15 = 145

            int totalPrice = basket.CalculateTotalPrice();
            Assert.AreEqual(200, totalPrice);
        }
    }
}
