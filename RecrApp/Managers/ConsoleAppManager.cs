using RecrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrApp.Managers
{
    internal class ConsoleAppManager
    {
        private Order _order;
        private Product _laptop;
        private Product _keyboard;
        private Product _mouse;
        private Product _monitor;
        private Product _duck;

        public ConsoleAppManager()
        {
            _order = new Order();
            _laptop= new Product("Laptop",2500);
            _keyboard = new Product("Klawiatura", 120);
            _mouse = new Product("Mysz", 90);
            _monitor = new Product("Monitor", 1000);
            _duck = new Product("Kaczka debuggująca", 66);
        }

        public void Start()
        {

        }

    }
}
