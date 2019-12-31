using System;

namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public int Add(string inputStr)
        {
            string[] numbers = inputStr.Split(',');
            int total = 0;

           
            foreach (var num in numbers)
            {
                int i = 0;
                bool result = int.TryParse(num, out i);
                total += i;
            }

            return total;
        }
    }
}
