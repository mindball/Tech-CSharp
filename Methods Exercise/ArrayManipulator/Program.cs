using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static int[] arrayToManipulate;
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        arrayToManipulate = input.Select(int.Parse).ToArray();
        string[] commandString;



        while (true)
        {
            commandString = Console.ReadLine().Split(' ');

            if (commandString[0].Equals("end"))
                break;
            else
            {

                switch (commandString[0])
                {
                    case "exchange":
                        if (int.Parse(commandString[1]) > input.Length || int.Parse(commandString[1]) < 0)
                            Console.WriteLine("Invalid index");
                        else
                            Exchange(int.Parse(commandString[1]));
                        break;
                    case "max":
                    case "min":
                        MaxOrMin(commandString[0], commandString[1]);
                        break;
                    case "first":
                        if (int.Parse(commandString[1]) > arrayToManipulate.Length)
                            Console.WriteLine("Invalid count");
                        else
                        {
                            Console.Write("[");
                            First(int.Parse(commandString[1]), commandString[2]);
                            Console.WriteLine("]");
                        }

                        break;
                    case "last":
                        if (int.Parse(commandString[1]) > arrayToManipulate.Length)
                            Console.WriteLine("Invalid count");
                        else
                        {
                            Console.Write("[");
                            Last(int.Parse(commandString[1]), commandString[2]);
                            Console.WriteLine("]");
                        }
                        break;
                }
            }

        }

        PrintArray();
    }

    private static void Last(int count, string oddOrEven)
    {
        //if count is one
        bool isOne = true;

        if (count <= 0)
        {
            return;
            Console.WriteLine("]");
        }
        else if (oddOrEven.Equals("odd"))
        {
            for (int i = arrayToManipulate.Length - 1; i >= 0; i--)
            {
                if (arrayToManipulate[i] % 2 != 0)
                {
                    if (isOne)
                    {
                        Console.Write(arrayToManipulate[i]);
                        isOne = false;
                    }
                    else
                    {
                        Console.Write(", " + arrayToManipulate[i]);
                    }

                    count--;
                }

                if (count <= 0)
                    break;


            }
        }
        else
        {
            for (int i = arrayToManipulate.Length - 1; i >= 0; i--)
            {
                if (arrayToManipulate[i] % 2 == 0)
                {
                    if (isOne)
                    {
                        Console.Write(arrayToManipulate[i]);
                        isOne = false;
                    }
                    else
                    {
                        Console.Write(", " + arrayToManipulate[i]);
                    }

                    count--;
                }

                if (count <= 0)
                    break;
            }
        }
    }

    private static void First(int count, string oddOrEven)
    {
        //if count is one
        bool isOne = true;

        if (count <= 0)
        {
            return;
            Console.WriteLine("]");
        }
        else if (oddOrEven.Equals("odd"))
        {
            for (int i = 0; i < arrayToManipulate.Length; i++)
            {
                if (arrayToManipulate[i] % 2 != 0)
                {
                    if (isOne)
                    {
                        Console.Write(arrayToManipulate[i]);
                        isOne = false;
                    }
                    else
                    {
                        Console.Write(", " + arrayToManipulate[i]);
                    }

                    count--;
                }

                if (count <= 0)
                    break;


            }
        }
        else
        {
            for (int i = 0; i < arrayToManipulate.Length; i++)
            {
                if (arrayToManipulate[i] % 2 == 0)
                {
                    if (isOne)
                    {
                        Console.Write(arrayToManipulate[i]);
                        isOne = false;
                    }
                    else
                    {
                        Console.Write(", " + arrayToManipulate[i]);
                    }

                    count--;
                }

                if (count <= 0)
                    break;
            }
        }

    }


    private static void MaxOrMin(string maxOrMin, string oddOrEven)
    {
        int maxValue = int.MinValue;
        int minValue = int.MaxValue;
        int maxIndex = -1;
        int minIndex = -1;


        for (int i = 0; i < arrayToManipulate.Length; i++)
        {
            if (oddOrEven.Equals("odd"))
            {
                if (arrayToManipulate[i] % 2 != 0)
                {
                    if (arrayToManipulate[i] >= maxValue)
                    {
                        maxValue = arrayToManipulate[i];
                        maxIndex = i;
                    }
                    if (arrayToManipulate[i] <= minValue)
                    {
                        minValue = arrayToManipulate[i];
                        minIndex = i;
                    }
                }
            }
            else
            {
                if (arrayToManipulate[i] % 2 == 0)
                {
                    if (arrayToManipulate[i] >= maxValue)
                    {
                        maxValue = arrayToManipulate[i];
                        maxIndex = i;
                    }
                    if (arrayToManipulate[i] <= minValue)
                    {
                        minValue = arrayToManipulate[i];
                        minIndex = i;
                    }
                }
            }

        }
        if (maxOrMin.Equals("max"))
            Console.WriteLine(maxIndex >= 0 ? maxIndex.ToString() : "No matches");
        else
            Console.WriteLine(maxIndex >= 0 ? minIndex.ToString() : "No matches");
    }



    private static void PrintArray()
    {
        Console.Write("[");

        for (int i = 0; i < arrayToManipulate.Length - 1; i++)
        {
            Console.Write("" + arrayToManipulate[i] + ", ");
        }


        Console.Write(arrayToManipulate[arrayToManipulate.Length - 1] +"]");
    }

    public static void Exchange(int index)
    {
        int[] arrayCopy = new int[arrayToManipulate.Length];

        Array.Copy(arrayToManipulate, index + 1, arrayCopy, 0, arrayToManipulate.Length - 1 - index);
        Array.Copy(arrayToManipulate, 0, arrayCopy, arrayToManipulate.Length - 1 - index, index + 1);

        arrayToManipulate = arrayCopy;
    }

}

