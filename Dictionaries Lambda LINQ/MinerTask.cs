using System;
using System.Collections.Generic;
using System.Linq;

class MinerTask
{
    static void Main()
    {
        Dictionary<string, uint> miner = new Dictionary<string, uint>();

        while(true)
        {
            string resource = Console.ReadLine();

            if (resource.Equals("stop"))
            {
                break;
            }

            uint quantity = uint.Parse(Console.ReadLine());

            if (miner.ContainsKey(resource))
                miner[resource] += quantity;
            else
            {
                miner.Add(resource, quantity);
            }
        }

        foreach (var item in miner)
        {
            Console.WriteLine($"{item.Key} -> {item.Value}");
        }
    }
}

