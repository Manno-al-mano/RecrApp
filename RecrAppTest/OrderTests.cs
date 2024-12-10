using Xunit;
using RecrApp.Models;

namespace RecrAppTest
{
    public class OrderTests
    {
        
           [Theory]
          [InlineData(1, 100, 100)]
          [InlineData(2, 100, 190)]
          [InlineData(3, 100, 280)]
          [InlineData(1, 10000, 9500)]
          [InlineData(2, 5000, 9025)]
          [InlineData(4, 5000, 18050)]
          public void Test_OrderDiscount(int numberOfProducts, decimal price, decimal expectedPrice)
          {

                   Order order = new Order();
                   for (int i = 0; i < numberOfProducts; i++)
                   {
                       string name = "Product" + i;
                       Product product = new Product(name, price);
                       order.AddItem(product, 1);
                   }
                   var discountedValue = order.GetTotalDiscountedValue();
                   Assert.Equal(expectedPrice, discountedValue); 
                   }
    }
}