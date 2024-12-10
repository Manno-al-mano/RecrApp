using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecrApp.Managers;

namespace RecrAppTest
{
    public class ConsoleAppTests
    {
        [Fact]
        public void Test_MainMenu()
        {
            var consoleOutput= new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("6");
            Console.SetIn(simulatedInput);
            manager.Start();
            var output= consoleOutput.ToString();
            Assert.Contains("Witamy w naszym sklepie",output);
            Assert.Contains("Wybierz opcję:", output);
            Assert.Contains("1. Dodaj produkt", output);
            Assert.Contains("2. Pokaż szczegóły zamówienia", output);
            Assert.Contains("3. Pokaż wartość zamówienia", output);
            Assert.Contains("4. Pokaż informacje o zniżkach", output);
            Assert.Contains("5. Usuń lub zmniejsz liczbę produktu", output);
            Assert.Contains("6. Wyjście", output);

        }
        [Fact]
        public void Test_ShowDiscountInfo()
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("4\n6");
            Console.SetIn(simulatedInput);
            manager.Start();

          


            var output = consoleOutput.ToString();
            Assert.Contains("zniżki przy zakupach powyżej 5000 PLN",output);
        }
    
    [Fact]
    public void Test_AddProductCheckValue() {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);
        ConsoleAppManager manager = new ConsoleAppManager();
        var simulatedInput = new StringReader("1\n3\n2\n3\n6");
        Console.SetIn(simulatedInput);
        manager.Start();
        var output = consoleOutput.ToString();
            Assert.Contains("171", output);
            Assert.DoesNotContain("180", output);
    }

    [Fact]
    public void Test_CheckInfo() {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("1\n3\n2\n2\n6");
            Console.SetIn(simulatedInput);
            manager.Start();
            var output = consoleOutput.ToString();
            Assert.Contains("171", output);
            Assert.Contains("180", output);
        }

    [Fact]
    public void Test_DecreaseProductNumber()
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("1\n1\n3\n5\n1\n1\n2\n2\n6");
            Console.SetIn(simulatedInput);
            manager.Start();
            var output = consoleOutput.ToString();
            Assert.Contains("x2", output);
        }

    [Fact]
    public void Test_RemoveProduct()
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("1\n1\n3\n5\n1\n0\n2\n6");
            Console.SetIn(simulatedInput);
            manager.Start();
            var output = consoleOutput.ToString();
            Assert.Contains("0,0", output);
        }
    [Fact]
    public void Test_RemoveProductByDecreasing()
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            ConsoleAppManager manager = new ConsoleAppManager();
            var simulatedInput = new StringReader("1\n1\n3\n5\n1\n1\n1\n1\n2\n2\n6");
            Console.SetIn(simulatedInput);
            manager.Start();
            var output = consoleOutput.ToString();
            Assert.Contains("0,0", output);
            Assert.Contains("usunięt", output);
        }
}
}
