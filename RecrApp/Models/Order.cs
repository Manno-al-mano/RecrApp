using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrApp.Models
{
    internal class Order
    {
        private List<OrderItem> _items = new List<OrderItem>();
        public void AddItem(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(item => item.Product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new OrderItem(product, quantity));
            }
        }

        public void RemoveItem(Product product)
        {
            var existingItem = _items.FirstOrDefault(item => item.Product.Name == product.Name);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
            }
        }

        public decimal GetTotalValue()
        {
            var products = _items
    .SelectMany(item => Enumerable.Repeat(item.Product.Price, item.Quantity))
    .OrderBy(p => p)
    .ToList();
            decimal total = products.Sum();
            if (products.Count > 3)
            {
                total -= products[0] * 0.1M;
            }
            else if (products.Count == 2)
            {
                total -= products[0] * 0.2M;
            }
            if (total > 5000)
            {
                return total * .95M;
            }
            return total;
        }
    }


}
