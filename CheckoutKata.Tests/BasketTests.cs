using System;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddProduct_ProductNull()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProduct_NumberToAddNotPositive()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA, 0);
        }

        [TestMethod]
        public void AddProduct()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA, 1);

            Assert.IsTrue(basket.Products.Contains(productA));
        }

        [TestMethod]
        public void AddProduct_MultipleAdd()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA, 2);

            Assert.IsTrue(basket.Products.Contains(productA) && basket.Products.Count == 2);
        }

        [TestMethod]
        public void CalculateBasketTotal_Empty()
        {
            Basket basket = new Basket();
            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(0, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_OneItem()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA, 1);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(10, totalPrice);
        }

        [TestMethod]
        public void CalculateBasketTotal_MultipleItems()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA, 1);
            basket.AddProductToBasket(productB, 1);
            basket.AddProductToBasket(productC, 1);
            basket.AddProductToBasket(productD, 1);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(120, totalPrice);
        }
    }
}
