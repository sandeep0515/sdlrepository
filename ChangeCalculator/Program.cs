using ChangeCalculatorService;
using System;
using System.Collections.Generic;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello, Please enter a amount");
            CalculatorService service = new CalculatorService();
            List<string> change = service.CalculateChange(Console.ReadLine());
            Console.WriteLine("Below is the change: ");
            foreach (var item in change)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
