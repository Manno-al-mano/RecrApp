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
        public Product GetItem(int i) { 
        return _items[i].Product;
        }
        public int getItemQuantity(int i)
        {
            return _items[i].Quantity;
        }
        public void DecreaseItemAt(int i) 
        {
            _items[i].Quantity--;
            if(_items[i].Quantity <= 0)
            {
                _items.RemoveAt(i);
                
            }
           
        }

        public void RemoveItemAt(int i) {
            _items.RemoveAt(i);
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
            decimal totalValue = 0;
            foreach (var item in _items)
            {
                totalValue += item.GetPrice();
            }
            return totalValue;
        }
        public decimal GetTotalDiscountedValue()
        {
            var products = _items
    .SelectMany(item => Enumerable.Repeat(item.Product.Price, item.Quantity))
    .OrderBy(p => p)
    .ToList();
            decimal total = products.Sum();
            if (products.Count > 2)
            {
                total -= products[0] * 0.2M;
            }
            else if (products.Count == 2)
            {
                total -= products[0] * 0.1M;
            }
            if (total > 5000)
            {
                return total * .95M;
            }
            return total;
        }
        public void PrintFullOrderInfo()
        {
            decimal total = GetTotalDiscountedValue();
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine(i + 1 + ".\t" + _items[i].Product.Name + "\tx" + _items[i].Quantity + "\t" + _items[i].GetPrice().ToString("0.00") + " PLN");
            }
            Console.WriteLine("Całkowita cena:\t" + total.ToString("0.00") + (total!=GetTotalValue()? " PLN(Zniżki uwzględnione)" : " PLN"));
        }

        public void ShowOrder()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine(i + 1 + ".\t" + _items[i].Product.Name + "\tx" + _items[i].Quantity + "\t");
            }
        }
        public int GetItemsCount()
        {
            return _items.Count;
        }
    }
}
