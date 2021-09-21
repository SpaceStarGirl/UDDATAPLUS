using System;
using UDDATA.Views;

namespace UDDATA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello There!");
            while (true)
                new MenuView().Menu();
        }
    }
}
