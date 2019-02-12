using System;
using System.Collections.Generic;
using System.Linq;

class CompanyUsers
{
    static void Main(string[] args)
    {
        Dictionary<string, HashSet<string>> company = new Dictionary<string, HashSet<string>>();

        string[] splitInput;

        while (true)
        {
            splitInput = Console.ReadLine().Split(new char[] {'-', '>'});
            if (splitInput[0].Equals("End"))
                break;

            //when company name has a space
            splitInput = splitInput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            splitInput[0] = splitInput[0].TrimEnd();
            splitInput[1] = splitInput[1].TrimStart();

            if(company.ContainsKey(splitInput[0]))
            {
                if (company[splitInput[0]].Contains(splitInput[1]))
                {
                    continue;
                }                    
                company[splitInput[0]].Add(splitInput[1]);
            }
            else
            {
                company.Add(splitInput[0], new HashSet<string>() { splitInput[1] });
            }
        }

        var sortCompany = company.OrderBy(x => x.Key);

        foreach (var item in sortCompany)
        {
            Console.WriteLine($"{item.Key}");
            foreach (var id in item.Value)
            {
                Console.WriteLine($"-- {id}");
            }
        }
    }
}

