using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class BasketTest
    {
        Product productA = new Product("A", 10);
        Product productB = new Product("B", 15);
        Product productC = new Product("C", 40);
        Product productD = new Product("D", 55);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullProduct()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(null);
        }
        
        [TestMethod]
        public void AddProduct()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA);

            Assert.IsTrue(basket.Products.Contains(productA));
        }

        [TestMethod]
        public void CalculateBasketTotal_Empty()
        {
            Basket basket = new Basket();
            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(totalPrice, 0);
        }

        [TestMethod]
        public void CalculateBasketTotal_OneItem()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(totalPrice, 10);
        }

        [TestMethod]
        public void CalculateBasketTotal_MultipleItems()
        {
            Basket basket = new Basket();
            basket.AddProductToBasket(productA);
            basket.AddProductToBasket(productB);
            basket.AddProductToBasket(productC);
            basket.AddProductToBasket(productD);

            int totalPrice = basket.CalculateTotalPrice();

            Assert.AreEqual(totalPrice, 120);
        }
    }
}
