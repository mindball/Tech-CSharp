using System;
using System.Collections.Generic;
using System.Linq;

class MagicSum
{
    //Compl
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        int sum;

        int.TryParse(Console.ReadLine(), out sum);

        //Time Complexity: O(n)
        HashSet<int> pair = new HashSet<int>();

        int temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            temp = sum - array[i];

            if(temp >= 0 && pair.Contains(temp))
                Console.WriteLine("" + temp + " " + array[i]);

            pair.Add(array[i]);
        }


    }
}

