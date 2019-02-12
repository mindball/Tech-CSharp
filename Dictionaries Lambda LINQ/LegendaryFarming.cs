using System;
using System.Collections.Generic;
using System.Linq;


class LegendaryFarming
{
    static Dictionary<string, Items> legendaryItem = new Dictionary<string, Items>();
    
    static void Main()
    {
        //First add key items
        legendaryItem.Add("shards", new Items("shards", 0));
        legendaryItem.Add("motes", new Items("motes", 0));
        legendaryItem.Add("fragments", new Items("fragments", 0));

        string[] splitInput;
        string firstReachtarget;

        while (true)
        {
            splitInput = Console.ReadLine().Split(new char[] { ' ' });
            firstReachtarget = CalculateItemsOfMaterials(splitInput);

            if (!(string.IsNullOrEmpty(firstReachtarget)) && legendaryItem.ContainsKey(firstReachtarget))                       
                break;           
                
        }

        //pint key items and they elements
       if(legendaryItem.ContainsKey(firstReachtarget))
        {
            PrintKeyElements(firstReachtarget);
        }
    }

    private static void PrintKeyElements(string firstReachtarget)
    {
        legendaryItem[firstReachtarget].CurrentNumberOfMarks -= 250;

        switch (firstReachtarget)
        {
            case "shards":
                Console.WriteLine("Shadowmourne obtained!");
                break;
            case "fragments":
                Console.WriteLine("Valanyr obtained!");
                break;
            case "motes":
                Console.WriteLine("Dragonwrath obtained!");
                break;
        }

        //sort key items 
        var listOfLegendaryItems = legendaryItem.Where(x => x.Key.Equals("shards")
                        || x.Key.Equals("fragments")
                        || x.Key.Equals("motes")).Select(p => p.Value)
                        .OrderBy(x => x.Name)
                        .OrderByDescending(x => x.CurrentNumberOfMarks);

        //sort junk by name
        var listOfJunks = legendaryItem.Where(x => !(x.Key.Equals("shards"))
                        && !(x.Key.Equals("fragments"))
                        && !(x.Key.Equals("motes"))).Select(p => p.Value)
                        .OrderBy(x => x.Name);

        //print elements of Legendary Items
        foreach (var item in listOfLegendaryItems)
        {
            Console.WriteLine($"{item.Name}: {item.CurrentNumberOfMarks}");
        }

        foreach (var item in listOfJunks)
        {
            Console.WriteLine($"{item.Name}: {item.CurrentNumberOfMarks}");
        }
    }

    public static string CalculateItemsOfMaterials(string[] splitInput)
    {
        string firstReachtarget = null;

        for (int i = 1; i < splitInput.Length; i += 2)
        {
            int mark;
            string nameOfMaterial = splitInput[i].ToLower();

            if (int.TryParse(splitInput[i - 1], out mark))
            {
                if (legendaryItem.ContainsKey(nameOfMaterial))
                {
                    legendaryItem[nameOfMaterial].CountOfMarks = mark;
                    if (legendaryItem[nameOfMaterial].ReachTarget)
                    {
                        firstReachtarget = nameOfMaterial;                       
                        break;
                    }
                }
                else
                {
                    legendaryItem.Add(nameOfMaterial, new Items(nameOfMaterial, mark));
                    if (legendaryItem[nameOfMaterial].ReachTarget)
                    {
                        firstReachtarget = nameOfMaterial;
                        break;
                    }
                }
            }
        }

        return firstReachtarget;
    }
   
    internal class Items
    {
        bool reachTarget = false;
        long sumOfmarks = 0;
        
       
        public Items(string name, int countOfMarks)
        {
            this.Name = name;
            this.CountOfMarks = countOfMarks;
        }

        public long CountOfMarks
        {
            get
            {
                return this.sumOfmarks;
            }
            set
            {
                this.sumOfmarks += value;
                this.CurrentNumberOfMarks = sumOfmarks;

                //check only key materials
                if ((this.Name.ToLower().Equals("shards")
                    || this.Name.ToLower().Equals("fragments")
                    || this.Name.ToLower().Equals("motes")) && this.sumOfmarks >= 250)
                {
                    this.reachTarget = true;
                }  
            }
        }

        public string Name { get; set; }

        public long CurrentNumberOfMarks { get; set; }

        public bool ReachTarget
        {
            get
            {
                return this.reachTarget;
            }
        }
    }
}

