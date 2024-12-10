using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrApp.Models
{
    internal class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity {  get; set; }

        public OrderItem(Product product, int quantity) {
            this.Product = product;
            this.Quantity = quantity;
        }

        public decimal GetPrice()
        {
            return Quantity*Product.Price;
        }
    }
}
