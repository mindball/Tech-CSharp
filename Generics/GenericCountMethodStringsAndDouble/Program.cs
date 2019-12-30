using System;
using System.Collections.Generic;

namespace GenericCountMethodStringsAndDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(input);
            List<string> stringList = new List<string>();
            List<double> doubleList = new List<double>();
            while (count > 0)
            {
                input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value))
                {
                    doubleList.Add(value);
                }
                else
                {
                    stringList.Add(input);
                }

                count--;
            }

            string valueToCompare = Console.ReadLine();
           

            if (stringList.Count != 0)
            {
                CompareItems(stringList, valueToCompare);
            }
            else
            {
                double value = double.Parse(valueToCompare);
                CompareItems(doubleList, value);
            }
        }

        public static void CompareItems<T>(List<T> list, T strToCompare)
            where T: IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if(item.CompareTo(strToCompare) > 0)
                {
                    count++;
                }                
            }

            Console.WriteLine(count);
        }
    }
}
