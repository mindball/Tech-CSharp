using System;
using System.Collections.Generic;
using System.Linq;

class ArrayRotation
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

        LinkedList<int> rotation = new LinkedList<int>(array);

        int numberOfRotation = int.Parse(Console.ReadLine());
        int temp;


        for (int i = 0; i < numberOfRotation; i++)
        {
            temp = rotation.First();
            rotation.RemoveFirst();          
            rotation.AddLast(temp);
        }

        for (int i = 0; i < rotation.Count; i++)
        {
            Console.Write("" + rotation.ElementAt(i) + " ");
        }
    }
}

