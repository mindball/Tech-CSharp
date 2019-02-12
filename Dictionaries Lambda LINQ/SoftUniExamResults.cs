using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SoftUniExamResults
{
    static Dictionary<string, int> softUniExamResults = new Dictionary<string, int>();
    static Dictionary<string, int> users = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        string[] splitInput;
        

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("exam finished"))
                break;

            splitInput = input.Split(new char[] { '-' });
            string userName = splitInput[0]; 
            string langCourse = splitInput[1];

            if (langCourse.Equals("banned"))
            {
                if (users.ContainsKey(userName))
                    users.Remove(userName);
                continue;
            }

            int points = int.Parse(splitInput[2]);
            

            if (softUniExamResults.ContainsKey(langCourse))
            {
                softUniExamResults[langCourse]++;
                
                CheckUsersPoints(userName, points);
            }
            else
            {
                softUniExamResults.Add(langCourse, 1);
                if (!users.ContainsKey(userName))
                {
                    users.Add(userName, points);
                }
                else
                {
                    CheckUsersPoints(userName, points);
                }                
            }
        }

        Console.WriteLine("Results:");

        foreach (var user in users.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
        {
            Console.WriteLine($"{user.Key} | {user.Value}");
        }

        Console.WriteLine("Submissions:");

        foreach (var languageCourse in softUniExamResults.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
        {
            Console.WriteLine($"{languageCourse.Key} - {languageCourse.Value}");
        }
    }

    static void CheckUsersPoints(string userName, int points)
    {
        //check exist user
        // - return max point        
        int currentUserPoint;
        if (users.TryGetValue(userName, out currentUserPoint) && points > currentUserPoint)
        {
            users[userName] = points;
        }        
        else if(!users.ContainsKey(userName))
        {
            users.Add(userName, points);
        }       
    }
}

