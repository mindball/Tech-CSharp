using System;
using System.Collections.Generic;
using System.Linq;

class PokemonDontGo
{
    static void Main()
    {
        
        string[] input = Console.ReadLine().Split(' ');
        int[] arr = input.Select(int.Parse).ToArray();

        List<int> ls = new List<int>(arr);
        int index;
        int valueFromIndex = 0;
        int cutValueFromList = 0;

        while(ls.Count > 0)
        {
            int.TryParse(Console.ReadLine(), out index);
            cutValueFromList = 0;

            //replace first index with last and remove last
            if (index < 0)
            {
                valueFromIndex += ls[0];
                cutValueFromList = ls[0];
                ls[0] = ls[ls.Count - 1];                        
            }
            //replace last index with first
            else if(index > ls.Count - 1)
            {
                valueFromIndex += ls[ls.Count - 1];
                cutValueFromList = ls[ls.Count - 1];
                ls[ls.Count - 1] = ls[0];
                
            }
            else
            {
                valueFromIndex += ls[index];
                cutValueFromList = ls[index];
                ls.RemoveAt(index);
            }

            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i] <= cutValueFromList)
                    ls[i] += cutValueFromList;
                else
                    ls[i] -= cutValueFromList;
            }
        }

        Console.WriteLine(valueFromIndex);



    }
}

