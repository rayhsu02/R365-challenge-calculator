using CalculatorService;
using System;

namespace R365_Calculator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculatorService = new Calculator();

            Console.WriteLine("Enter numbers to add (separate by delimiter : ");
            string input = Console.ReadLine();
            input = input.Replace("\\n", "\n");
            int result = calculatorService.Add(input);
            Console.WriteLine("Total is " + result);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
