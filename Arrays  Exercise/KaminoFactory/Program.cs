using System;
using System.Collections.Generic;
using System.Linq;

class KaminoFactory
{
    static List<int[]> LenIndexAndSumOfDna = new List<int[]>();
    static int maxOfOnesInStr = 0;
    static int index = 0;
    static int sum = 0;
    static int[] bestMap = new int[4];
    static int[] map = new int[4];

    static void Main(string[] args)
    {
        int dnaLen;
        int.TryParse(Console.ReadLine(), out dnaLen);
        string dna = Console.ReadLine();

        List<string> allDna = new List<string>();

        while(!dna.Equals("Clone them!"))
        {
            dna = new string(dna.Where(n => !char.IsPunctuation(n)).ToArray());

            if (dnaLen == dna.Length)
            {
                //allDna.Add(dna.Except("!"));
                allDna.Add(dna);
            }

            dna = Console.ReadLine();
        }



        CalculateCountOnesAndSumAndSetIndex(allDna[0]);
        bestMap = new int[] {0, maxOfOnesInStr, index, sum };


        for (int i = 1; i < allDna.Count; i++)
        {
            CalculateCountOnesAndSumAndSetIndex(allDna[i]);
            map = new int[] { i, maxOfOnesInStr, index, sum };

            //best len
            if(map[1] > bestMap[1])
            {
                bestMap = map;
            }            
            else if(map[1] == bestMap[1])
            {
                //leftmost index
                if(map[2] < bestMap[2])
                {
                    bestMap = map;
                }
                else if(map[2] == bestMap[2])
                {
                    //best sum
                    if(map[3] > bestMap[3])
                    {
                        bestMap = map;
                    }
                }
            }

        }

        Console.WriteLine($"Best DNA sample {bestMap[0] + 1} with sum: {bestMap[3]}.");
        foreach (var item in allDna[bestMap[0]])
        {
            Console.Write(item + " ");
        }
       
    }

    private static void CalculateCountOnesAndSumAndSetIndex(string v)
    {
        maxOfOnesInStr = 0;
        index = 0;
        sum = 0;
        int currentOnes = 0;             

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == '1')
            {
                currentOnes++;
                sum++;
                if (currentOnes > maxOfOnesInStr)
                {
                    maxOfOnesInStr = currentOnes;
                    index = (i - maxOfOnesInStr) + 1;
                }
                    
            }
            else
                currentOnes = 0;
        }
    }

 
    
}