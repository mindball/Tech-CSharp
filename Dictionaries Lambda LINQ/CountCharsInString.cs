using System;
using System.Collections.Generic;
using System.Linq;

class CountCharsInString
{
    static void Main(string[] args)
    {
        Dictionary<char, int> countChar = new Dictionary<char, int>();

        string input = string.Concat(Console.ReadLine().Where(x => !char.IsWhiteSpace(x)));
       

        for (int i = 0; i < input.Length; i++)
        {
            if (countChar.ContainsKey(input[i]))
            {
                countChar[input[i]]++;
            }
            else
                countChar.Add(input[i], 1);
        }

        foreach (var item in countChar)
        {
            Console.WriteLine($"{item.Key} -> {item.Value}");
        }
    }
}

