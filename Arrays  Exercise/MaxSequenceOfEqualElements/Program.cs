using System;
using System.Collections.Generic;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        //Time Complexity : O(n)
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        int currentCoun = 1;
        int count = 0;
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if(i < array.Length - 1 && array[i] == array[i + 1])
            {
                currentCoun++;
            }
            else
            {
                // > - guarantee that it will print leftmost 
                if(currentCoun > count)
                {
                    count = currentCoun;
                    index = i;
                }
                currentCoun = 1;
            }
        }
        

        for (int i = (index - count) + 1; i <= index; i++)
        {
            Console.Write("" + array[i] + " ");
        }

       
    }
}

