using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class TeamworkProjects
{
    static void Main()
    {
        Dictionary<string, Team> teams = new Dictionary<string, Team>();
        int count = int.Parse(Console.ReadLine());
        string[] array;
        string user;
        string team;
        List<string> members;

        while(count > 0)
        {
            array = Console.ReadLine().Split('-');
            user = array[0];
            team = array[1];
            if(teams.ContainsKey(team))
            {
                Console.WriteLine($"Team {team} was already created!");
            }
            else
            {
                //Creator of a team cannot create another team
                bool existingCreator = false;
                foreach (var creator in teams)
                {
                    if (user.Equals(creator.Value.Members[0]))
                        existingCreator = true;
                }

                if(!existingCreator)
                {
                    members = new List<string>();
                    members.Add(user);
                    teams[team] = new Team() { TeamName = team, Members = members };
                    Console.WriteLine($"Team {team} has been created by {user}!");
                }
                else
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                
            }
            count--;
        }

        while (true)
        {            
            array = Regex.Split(Console.ReadLine(), @"->");
            if (array[0].Equals("end of assignment"))
                break;

            bool userIsMember = false;
            user = array[0];
            team = array[1];
            if(teams.ContainsKey(team))
            {
                //	Member of a team cannot join another team
                foreach (var item in teams)
                {
                    if (item.Value.Members.Contains(user))
                        userIsMember = true;
                }

                if(!userIsMember)
                    teams[team].Members.Add(user);
                else
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
            }
            else
            {
                Console.WriteLine($"Team {team} does not exist!");
            }
        }

        PrintTeamDetails(teams.ToList());
    }

    private static void PrintTeamDetails(List<KeyValuePair<string, Team>> list)
    {
        //sort Team by name
        list.Sort((x, y) => x.Key.CompareTo(y.Key));

        //sort Team by count of members
        list.Sort((x, y) => y.Value.Members.Count.CompareTo(x.Value.Members.Count));

        List<string> teamDisband = new List<string>();

        //Additionaly store a team with zero member only authors
        foreach (var team in list)
        {
            if (team.Value.Members.Count == 1)
                teamDisband.Add(team.Value.TeamName);
            else
            {
                Console.WriteLine(team.Key);
                string authorName = team.Value.Members[0];
                Console.WriteLine($"- {authorName}");
                //sort by name
                var sortedUsersByName = team.Value.Members.OrderBy(x => x);

                foreach (var users in sortedUsersByName)
                {
                    if (!users.Equals(authorName))
                        Console.WriteLine($"-- {users}");
                }
            }            
        }

        Console.WriteLine("Teams to disband:");
        if (teamDisband.Count > 0)
        {
            teamDisband = teamDisband.OrderBy(x => x).ToList();
            foreach (var item in teamDisband)
            {
                Console.WriteLine(item);
            }
        }
       
    }
}

class Team
{
    public string TeamName { get; set; }
    //public string Creator{get; set;}
    //always first index is Creator !!!
    public List<string> Members { get; set; }
}

