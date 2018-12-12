using System;

class LadyBugs
{
    static int[] array;
    static void Main()
    {
        int fieldSize;
        int.TryParse(Console.ReadLine(), out fieldSize);
        array = new int[fieldSize];

        string[] tokens = Console.ReadLine().Split(' ');
        int[] numbers = Array.ConvertAll(tokens, int.Parse);

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] >= 0 && numbers[i] < array.Length)
                array[numbers[i]] = 1;
        }

        int ladybugIndex;
        string direction;
        int flyLength;

        while (true)
        {
            string command = Console.ReadLine();
            if(command == "end")
            {
                break;
            }
            else
            {
                tokens = command.Split(' ');
                int.TryParse(tokens[0], out ladybugIndex);
                direction = tokens[1];
                int.TryParse(tokens[2], out flyLength);
                Calculate(ladybugIndex, direction, flyLength);
            }

        }

        foreach (var item in array)
        {
            Console.Write("" + item + " ");
        }
    }

    private static void Calculate(int ladybugIndex, string direction, int flyLength)
    {
        //тук може и да бъркам за посоката когато получим отрицателен дължина не е добре описано в условието
        bool inversionDirection = false;
        if (flyLength < 0)
            inversionDirection = true;       

        if (ladybugIndex < 0 || ladybugIndex >= array.Length  || array[ladybugIndex] != 1)
        {
            return;
        } 

        int currentIndex;
        if (direction == "right")
            currentIndex = ladybugIndex + flyLength;                   
        else
            currentIndex = ladybugIndex - flyLength;
            
        //outside
        if (currentIndex > (array.Length - 1) || currentIndex < 0)
        {
            array[ladybugIndex] = 0;
            return;
        }           
        else
        {
            if (array[ladybugIndex] == 1)
            {
                array[ladybugIndex] = 0;
               
                if (array[currentIndex] == 0)
                    array[currentIndex] = 1;
                else
                {
                    if(direction == "right" && !inversionDirection)
                        FindFreePositionWithRightPos(currentIndex);
                    //reverse from right to left
                    else if (direction == "right" && inversionDirection)
                        FindFreePositionWithLeftPos(currentIndex);
                    else if(direction == "left" && !inversionDirection)
                        FindFreePositionWithLeftPos(currentIndex);
                    //reverse from left to right
                    else
                        FindFreePositionWithRightPos(currentIndex);
                }

            }
        }

        if (ladybugIndex == 0 || ladybugIndex == array.Length - 1)
        {
            array[ladybugIndex] = 0;

        }
    }

    private static void FindFreePositionWithRightPos(int currentIndex)
    {
        
        for (int i = currentIndex + 1; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                array[i] = 1;
                return;
            }
        }       
        
    }

    private static void FindFreePositionWithLeftPos(int currentIndex)
    {
        for (int i = currentIndex; i >= 0; i--)
        {
            if (array[i] == 0)
            {
                array[i] = 1;
                return;
            }
        }
    }

}

