using System;
using System.Collections.Generic;
using System.Linq;

class ForceBook
{
    static void Main()
    {
        //key=forceSide, value=forceUser
        Dictionary<string, Dictionary<string, string>> forceSide = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, string> forceUser = new Dictionary<string, string>();
        
        string[] splitInput;

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Lumpawaroo"))
                break;

            if (input.IndexOf('|') != -1)
            {
                splitInput = input.Split(new char[] { '|' });
                splitInput[0] = splitInput[0].TrimEnd(' ');
                splitInput[1] = splitInput[1].TrimStart(' ');

                string user = splitInput[1];
                string side = splitInput[0];

                if (forceUser.ContainsKey(user))
                    continue;

                if (forceSide.ContainsKey(splitInput[0]))
                {
                    forceSide[side].Add(user, side);
                    forceUser.Add(user, side);
                }
                else
                {
                    forceSide.Add(side, new Dictionary<string, string>());
                    forceSide[side].Add(user, side);
                    forceUser.Add(user, side);
                }

            }
            else if(input.IndexOf("->") != -1)
            {
                splitInput = input.Split(new char[] { '-', '>' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                splitInput[0] = splitInput[0].TrimEnd(' ');
                splitInput[1] = splitInput[1].TrimStart(' ');

                string userToChangeSide = splitInput[0];
                string changeSide = splitInput[1];

                if(forceUser.ContainsKey(userToChangeSide))
                {
                    //Side does not exist
                    if(!forceSide.ContainsKey(changeSide))
                    {
                        forceSide.Add(changeSide, new Dictionary<string, string>());
                    }

                    string oldSide = forceUser[userToChangeSide];
                    
                    ////change side with same side недвусмислица в задачата никъде не е упоменато
                    //if (changeSide == oldSide)
                    //    continue;

                    //clear side 
                    if (forceSide[oldSide].Count == 1)
                    {
                        forceSide[oldSide].Clear();
                        forceSide[changeSide].Add(userToChangeSide, changeSide);
                        forceUser[userToChangeSide] = changeSide;
                    }
                    else
                    {
                        forceSide[oldSide].Remove(userToChangeSide);
                        forceSide[changeSide].Add(userToChangeSide, changeSide);
                        forceUser[userToChangeSide] = changeSide;
                    }
                }
                //treating the command as new registered forceUser.
                else
                {
                    if (forceSide.ContainsKey(changeSide))
                    {
                        forceSide[changeSide].Add(userToChangeSide, changeSide);
                        forceUser.Add(userToChangeSide, changeSide);
                    }
                    else
                    {
                        forceSide.Add(changeSide, new Dictionary<string, string>());
                        forceSide[changeSide].Add(userToChangeSide, changeSide);
                        forceUser.Add(userToChangeSide, changeSide);
                    }
                }
                Console.WriteLine($"{userToChangeSide} joins the {changeSide} side!");

            }
            

        }

        var result = forceSide.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

        foreach (var item in result)
        {
            Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count()}");

            var printUsers = item.Value.OrderBy(x => x.Key);
            foreach (var user in printUsers)
                Console.WriteLine($"! {user.Key}");

        }

    }
}

