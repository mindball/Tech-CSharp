using System;
using System.Linq;

class EqualSum
{
    static void Main()
    {
        
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        if(array.Length == 1)
            Console.WriteLine(0);
        else if(array.Length == 2)
            Console.WriteLine("no");
        else
        {
            if(CalculateSum(array) >= 0)
            {
                Console.WriteLine(CalculateSum(array));
            }
            else
                Console.WriteLine("no");
        }
        
    }

    //Time Complexity : O(n)
    public static int CalculateSum(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        int sumSoFar = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (sumSoFar * 2 + array[i] == sum)
            {
                return i;
            }
            else
                sumSoFar += array[i];

        }

        return -1;
    }
}

