using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public interface IProduct
    {
        public string ItemSKU { get; set; }
        public int UnitPrice { get; set; }
    }
}
