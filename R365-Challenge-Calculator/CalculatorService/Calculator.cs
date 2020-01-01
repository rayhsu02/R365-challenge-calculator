using System;
using System.Collections;

namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public int Add(string inputStr)
        {
            inputStr = inputStr.Replace('\n', ',');
            string[] numbers = inputStr.Split(',');
            int total = 0;
            ArrayList NegtiveList = new ArrayList();

            foreach (var num in numbers)
            {
                int i = 0;
                bool result = int.TryParse(num, out i);
                if (i < 0)
                {
                    NegtiveList.Add(num);
                }

                if (i > 1000) i = 0;

                total += i;
            }

            if (NegtiveList.Count > 0)
            {
                throw new Exception("negative number exception: " + String.Join(",", NegtiveList.ToArray()));
            }

            return total;
        }
    }
}
