using System;
using System.Collections.Generic;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(input);
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            while (count > 0)
            {
                input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {                    
                    intList.Add(value);
                }
                else
                {                    
                    stringList.Add(input);
                }

                count--;
            }

            string[] index = Console.ReadLine().Split(" ");
            int firstIndex = int.Parse(index[0]);
            int secondIndex = int.Parse(index[1]);

            if (stringList.Count != 0)
            {
                SwapIndexes(stringList, firstIndex, secondIndex);               
            }
            else
            {
                SwapIndexes(intList, firstIndex, secondIndex);
            }

        }

        public static void SwapIndexes<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

            var type = typeof(T);

            foreach (var item in list)
            {
                Console.WriteLine($"{type}: {item}");
            }
        }

        
    }
}
