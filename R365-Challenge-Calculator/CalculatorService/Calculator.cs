using System;
using System.Collections;
using System.Text;

namespace CalculatorService
{
    public class Calculator : ICalculator
    {
        public int Add(string inputStr)
        {
            bool HasCustomDelimiter = inputStr.Contains("//");
            bool HasMultiCustDelimiter = inputStr.Contains("[");
            bool IsSingleCharDelimiter = HasCustomDelimiter == true && HasMultiCustDelimiter == false;


            if (HasCustomDelimiter)
            {
                inputStr = inputStr.Replace("//", "");

                if (IsSingleCharDelimiter)
                    inputStr = ReplaceSingleDelimiter(inputStr);
                else
                    inputStr = ReplaceMultiCustDelimiters(inputStr);
            }

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

        private static string ReplaceSingleDelimiter(string inputStr)
        {
            char delimiter = inputStr[0];
            inputStr = inputStr.Replace(delimiter, ',');
            return inputStr;
        }

        private string ReplaceMultiCustDelimiters(string inputStr)
        {
            string[] delimiters = GetDeliomiters(inputStr);
            foreach (string s in delimiters)
            {
                inputStr = inputStr.Replace(s, ",");
            }

            return inputStr;
        }

        private string[] GetDeliomiters(string inputStr)
        {
            ArrayList list = new ArrayList();
            Stack stack = new Stack();
            StringBuilder sb = new StringBuilder();

            foreach (char c in inputStr)
            {
                if (c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ']')
                {
                    stack.Pop();
                    list.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    if (stack.Count != 0) sb.Append(c);
                }
            }

            return (string[])list.ToArray(typeof(string));
        }
    }
}
