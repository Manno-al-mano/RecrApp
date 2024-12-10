// See https://aka.ms/new-console-template for more information
using RecrApp.Managers;

namespace RecrApp
{


    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleAppManager consoleAppManager = new ConsoleAppManager();
            consoleAppManager.Start();
        }
    }
}

