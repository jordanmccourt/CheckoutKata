using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public interface IBasket
    {
        public List<IProduct> Products { get; set; }

        public void AddProductToBasket(IProduct product);
    }
}
