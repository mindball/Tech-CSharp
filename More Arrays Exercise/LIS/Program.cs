using System;
using System.Collections.Generic;
using System.Linq;

class LIS
{
    static void Main()
    {
        //int len = LengthOfLIS(new int[] { 0, 10, 20, 30, 30, 40, 1, 50, 2, 3, 4, 5, 6 });
        //int len = LengthOfLIS2(new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 });

        string[] input = Console.ReadLine().Split(' ');
        int[] array = input.Select(int.Parse).ToArray();
        PrintLIS(array);

        /* Look at closely how work binary search when number is not found, pay attention to the return value
         * insertion point:
         * //int[] list = {2, 4, 7, 10, 11, 45, 50, 59, 60, 66, 69, 70, 79};
           //               1^ 2^ 3^  4^  5^  
         int index = theList.BinarySearch(num);

        if (index >= 0)
        {
            //exists
            ...
        }
        else
        {
            // doesn't exist
        int indexOfBiggerNeighbour = ~index; //bitwise complement of the return value

        if (indexOfBiggerNeighbour == theList.Count)
        {
            // bigger than all elements
            ...
        }

        else if (indexOfBiggerNeighbour == 0)
        {
            // smaller than all elements
            ...
        }

        else
        {
            // Between 2 elements
            int indexOfSmallerNeighbour = indexOfBiggerNeighbour - 1;
            ...
        }

        **/
    }

    //complexity O(nlog(n))
    ////static public int LengthOfLIS2(int[] nums)
    //{
    //    if (nums == null || nums.Length == 0) return 0;

    //    List<int> lenOfLis = new List<int>();

    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        int index = lenOfLis.BinarySearch(nums[i]);
    //        if (index < 0) index = -(index + 1);

    //        if (index == lenOfLis.Count) lenOfLis.Add(nums[i]);
    //        else lenOfLis[index] = nums[i];

    //    }

    //    return lenOfLis.Count;
    //}

    //SoftUni explanation
    public static void PrintLIS(int[] array)
    {

        int[] len = new int[array.Length];
        int[] prev = new int[array.Length];
        int maxLen = 0;
        int lastIndex = -1;
        int[] lis;

        for (int i = 0; i < array.Length; i++)
        {
            prev[i] = -1;
            len[i] = 1;
            for (int x = 0; x < i; x++)
            {
                if (array[x] < array[i] && len[x] + 1 > len[i])
                //if(array[x] < array[i])
                {
                    len[i] = len[x] + 1;
                    prev[i] = x;
                }
            }

            if (len[i] > maxLen)
            {
                maxLen = len[i];
                lastIndex = i;
            }
        }

        lis = new int[maxLen];
        int previousIndex = lastIndex;

        for (int i = lis.Length - 1; i >= 0; i--)
        {
            lis[i] = array[previousIndex];
            previousIndex = prev[previousIndex];
        }

        foreach (var item in lis)
        {
            Console.Write("" + item + " ");
        }


    }


}

