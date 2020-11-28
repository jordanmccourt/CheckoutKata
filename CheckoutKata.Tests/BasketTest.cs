using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class BasketTest
    {
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
            Product product = new Product();

            basket.AddProductToBasket(product);

            Assert.IsTrue(basket.Products.Contains(product));
        }
    }
}
