using System;

namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public int Add(string inputStr)
        {
            string[] numbers = inputStr.Split(',');
            int total = 0;

            if (numbers.Length > 2) throw new Exception("Can not process more than two numbers.");

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
