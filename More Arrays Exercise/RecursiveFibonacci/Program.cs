using System;

class RecursiveFibonacci
{
    static bool[] isCalculate;
    static int sum = 0;
    static void Main(string[] args)
    {
        int number = 21;
        //int.TryParse(Console.ReadLine(), out number);
        isCalculate = new bool[number];
        Console.WriteLine(FibRecursive(number));

    }

    public static int FibRecursive(int number)
    {
        if (number <= 2)
            return 1;
        if (isCalculate[number - 1])
            return 0;
        
        //if (isCalculate[number])
        //    return 0;
        return FibRecursive(number - 1) + FibRecursive(number - 2);
        isCalculate[number - 1] = true;
    }
}

