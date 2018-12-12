using System;
using System.Collections.Generic;
using System.Linq;

class TopIntegers
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        bool[] arrayOfTopInt = new bool[array.Length];
        int topIntegers = 0;
        
        

        for (int i = 0; i < array.Length - 1; i++)
        {
           if(array[i] > array[i + 1])
            {
                
                if(array[i] > topIntegers)
                {
                    topIntegers = array[i];
                    arrayOfTopInt = new bool[array.Length];
                    arrayOfTopInt[i] = true;
                }
                else
                {
                    arrayOfTopInt[i] = true;
                }
            } 
        }

        //if last element is bigga than all include first
        if (array[array.Length - 1] > array[0])
        {
            if (array[array.Length - 1] > topIntegers)
            {
                topIntegers = array[array.Length - 1];
                arrayOfTopInt = new bool[array.Length];
                arrayOfTopInt[arrayOfTopInt.Length - 1] = true;
            }
            else
            {
                arrayOfTopInt[arrayOfTopInt.Length - 1] = true;
            }
        }


        for (int i = 0; i < arrayOfTopInt.Length; i++)
        {
            if(arrayOfTopInt[i])
                Console.Write("" + array[i] + " ");
        }
    }
}

