using RecrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecrApp.Managers
{
    public class ConsoleAppManager
    {
        private Order _order;
        private List<Product> _products= new List<Product>();

        public ConsoleAppManager()
        {
            _order = new Order();
          _products.Add(new Product("Laptop",2500));
          _products.Add(new Product("Klawiatura", 120));
          _products.Add(new Product("Mysz", 90));
          _products.Add(new Product("Monitor", 1000));
          _products.Add(new Product("Kaczka debuggująca", 66));
        }

        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                // Display menu
                Console.WriteLine("Witamy w naszym sklepie");
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Pokaż szczegóły zamówienia");
                Console.WriteLine("3. Pokaż wartość zamówienia");
                Console.WriteLine("4. Pokaż informacje o zniżkach");
                Console.WriteLine("5. Usuń lub zmniejsz liczbę produktu");
                Console.WriteLine("6. Wyjście");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        ShowOrderDetails();
                        break;

                    case "3":
                        ShowTotalValue();
                        break;

                    case "4":
                        ShowDiscountInfo();
                        break;

                    case "5":
                        RemoveProduct();
                        break;

                    case "6":
                        isRunning = false;
                        Console.WriteLine("Dziękujemy za zakupy!");
                        break;

                    default:
                        Console.WriteLine("Niepoprawna opcja.");
                        break;
                }
            }
        }

        private void RemoveProduct()
        {
            if (_order.GetItemsCount() == 0)
            {
                Console.WriteLine("Zamówienie puste");
                return;
            }
            _order.ShowOrder();
            bool productNotChosen = true;
            bool deletionInProgress = true;
            int selectedProductIndex = -1;
          
            while (productNotChosen)
            {
                Console.WriteLine("Wybierz numer produktu");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out selectedProductIndex) && selectedProductIndex >= 1 && selectedProductIndex <= _order.GetItemsCount())
                {
                    selectedProductIndex -= 1;
                    productNotChosen = false;
                }
                else
                {
                    Console.WriteLine("Wybór nieprawidłowy. Spróbuj ponownie.");
                }
            }
            while (deletionInProgress)
            {
                Console.WriteLine("Wybierz 0, żeby usunąć produkt w całości 1, żeby obniżyć liczbę o 1, 2 żeby wrócić do menu.");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Produkt usunięty");
                        _order.RemoveItemAt(selectedProductIndex);
                        deletionInProgress = false;
                        break;

                    case "1":
                        if (_order.getItemQuantity(selectedProductIndex) > 1)
                        {
                            _order.DecreaseItemAt(selectedProductIndex);
                            Console.WriteLine("Liczba produktu zmniejszona");
                            break;
                        }
                        goto case "0";
                        
                        case "2":
                        
                        deletionInProgress = false; 
                        break;


                        

                }

            }
            

        }

        private void ShowDiscountInfo()
        {
            Console.WriteLine("10% zniżki na tańszy produkt przy zakupie dwóch");
            Console.WriteLine("20% zniżki na najtańszy produkt przy zakupie trzech lub więcej");
            Console.WriteLine("5% zniżki przy zakupach powyżej 5000 PLN");
        }

        private void ShowTotalValue()
        {
            Console.WriteLine("Wybrano pokazanie wartości zamówienia.");
            Console.WriteLine("Całkowita Cena: "+_order.GetTotalDiscountedValue().ToString("0.00")+" PLN");
           
        }

        private void ShowOrderDetails()
        {
            Console.WriteLine("Wybrano pokazanie szczegółów zamówienia.");
            _order.PrintFullOrderInfo();
        }

        private void ShowProductList()
        {
            for(int i =0;i<_products.Count;i++) {
                Console.WriteLine(i + 1 + ".\t" + _products[i]);  
                }
        }

        private void AddProduct()
        {
            ShowProductList();
            bool productNotChosen = true;
            bool quantityNotChosen = true;
            int selectedProductIndex = -1;
            int selectedQuantity = 0;
            while (productNotChosen)
            {
                Console.WriteLine("Wybierz numer produktu");
                string choice = Console.ReadLine();
                if(int.TryParse(choice, out selectedProductIndex)&&selectedProductIndex>=1&&selectedProductIndex<=_products.Count)
                {
                    selectedProductIndex -= 1;
                    productNotChosen= false;
                }
                else
                {
                    Console.WriteLine("Wybór nieprawidłowy. Spróbuj ponownie.");
                }
            }
            while (quantityNotChosen)
            {
                Console.WriteLine("Wybierz liczbę wybranego produktu");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out selectedQuantity) && selectedQuantity > 0)
                {
                    quantityNotChosen = false;
                }
                else 
                {
                    Console.WriteLine("Podano nieprawidłową ilość. Spróbuj ponownie.");
                }
            }
            _order.AddItem(_products[selectedProductIndex],selectedQuantity);
            Console.WriteLine("Produkt dodany.");

          
        }
    }
}
