using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class AnonymousThreat
{
    static List<string> result = new List<string>();
    static List<string> input = new List<string>();
    static List<string> temp;
    static List<string> devideString = new List<string>();
    static StringBuilder appendIndexes;
    //Give me 90 points at judge soft uni
    //Use List<T> when you don’t expect frequent insertion and deletion of elements, 
    //but you expect to add new elements at the end of the list or to access the elements by index,
    //so so my concept is create a list and add at end it to it. Inserting and removing elements is a slow operation
    static void Main()
    {
        input = new List<string>(Console.ReadLine().Split(' '));
        
        string[] command;
        string end = "3:1";
        int index;
        int argument2;

        do
        {
            command = Console.ReadLine().Split(' ');
            
           
            if (command[0].Equals("3"))
                break;
            else if (command[0].Equals("merge"))                
            {
                index = int.Parse(command[1]);
                argument2 = int.Parse(command[2]);
                Merge(index, argument2);
            }
            else if (command[0].Equals("divide"))
            {
                index = int.Parse(command[1]);
                argument2 = int.Parse(command[2]);
                result.Clear();
                if (index == 0)
                {
                    //balance partition
                    if ((input[index].Length % argument2) == 0)
                    {
                        result = EqualPartition(input[index].ToString(), (input[index].Length / argument2));
                        result.AddRange(input.GetRange(1, input.Count - 1));
                    }
                    //unbalanced                      
                    else
                    {
                        result = UnbalancedPartition(input[index].ToString(), index);
                        result.AddRange(input.GetRange(1, input.Count - 1));
                    }


                }
                else if (index == input.Count - 1)
                {
                    if ((input[index].Length % argument2) == 0)
                    {
                        result.AddRange(input.GetRange(0, index));
                        result.AddRange(EqualPartition(input[index].ToString(), (input[index].Length / argument2)));                        
                    }
                    //unbalanced   
                    else
                    {
                        result.AddRange(input.GetRange(0, index));
                        result.AddRange(UnbalancedPartition(input[index].ToString(), index));                        
                    }
                }
                else
                {
                    //balance partition
                    if ((input[index].Length % argument2) == 0)
                    {
                        result.AddRange(input.GetRange(0, index));
                        result.AddRange(EqualPartition(input[index].ToString(), (input[index].Length / argument2)));
                        //before last
                        if (index + 1 == input.Count - 1)
                            result.Add(input[index + 1]);
                        else
                            result.AddRange(input.GetRange(index + 1, input.Count - index));
                    }
                    //unbalanced   
                    else
                    {
                        result.AddRange(input.GetRange(0, index));
                        result.AddRange(UnbalancedPartition(input[index].ToString(), index));
                        //before last
                        if (index + 1 == input.Count - 1)
                            result.Add(input[index + 1]);
                        else
                            result.AddRange(input.GetRange(index + 1, input.Count - index));
                    }
                }
            }

            input = new List<string>(result);
            

        } while (!string.Join("", command).Equals(end));

        foreach (var item in input)
        {
            Console.Write(item + " ");
        }
        

    }

    private static List<string> UnbalancedPartition(string v, int index)
    {
        temp = new List<string>();
        if (v.Length < 2)
        {
            temp.Add(v);
            return temp;
        }
        else
        {
            for (int i = 0; i < v.Length - 2; i++)
            {
                temp.Add(v[i].ToString());
            }

            //LAST one – the LONGEST. 
            appendIndexes = new StringBuilder();
            appendIndexes.Append(v[v.Length - 2]);
            appendIndexes.Append(v[v.Length - 1]);

            temp.Add(appendIndexes.ToString());
            return temp;
        }
           
    }

    static void Merge(int startIndex, int endIndex)
    {
        temp = new List<string>();

        //invalid indexes
        if (startIndex < 0 && endIndex > 0)
        {
            startIndex = 0;
            if (endIndex >= input.Count - 1)                
                temp.Add(AppendListElement(startIndex, input.Count - 1));
            else
            {
                temp.Add(AppendListElement(startIndex, endIndex));
                temp.AddRange(input.GetRange(endIndex + 1, input.Count - (endIndex + 1)));
            }            
        }              
        else if((startIndex >= 0 && startIndex < input.Count - 1) && endIndex > input.Count - 1)
        {
            if(startIndex == 0)
            {
                temp.Add(AppendListElement(startIndex, input.Count - 1));
            }
            else
            {
                temp.AddRange(input.GetRange(0, startIndex));
                temp.Add(AppendListElement(startIndex, input.Count - 1));
            }
        }
            
        //valid indexes from begging 
        else if (startIndex == 0 && endIndex <= input.Count - 1 )
        {
            temp.Add(AppendListElement(startIndex, endIndex));           
            temp.AddRange(input.GetRange(endIndex + 1, input.Count - (endIndex + 1)));            
        }
        //random startIndex to end including
        else if(startIndex > 0 && endIndex <= input.Count - 1)
        {
            temp.AddRange(input.GetRange(0, startIndex));
            temp.Add(AppendListElement(startIndex, endIndex));
            if (endIndex + 1 == input.Count - 1)
                temp.Add(input[endIndex + 1]);
            else
                temp.AddRange(input.GetRange(endIndex + 1, input.Count - (endIndex + 1)));
        }             
        //when the condition start index == end index, and start index is big from length
        else
        {
            result = input;
            return;
        }

        result = temp;
        
    }

    static List<string> EqualPartition(string array, int partitionsSize)
    {
        temp = new List<string>();
        appendIndexes = new StringBuilder();
        int step = partitionsSize;

        for (int i = 0; i < array.Length; i++)
        {
            if (i == partitionsSize - 1)
            {
                appendIndexes.Append(array[i]);
                temp.Add(appendIndexes.ToString());
                appendIndexes.Clear();
                partitionsSize += step;
            }
            else
                appendIndexes.Append(array[i]);
        } 
        
        return temp;
    }

    static string AppendListElement(int startIndex, int endIndex)
    {
        appendIndexes = new StringBuilder();

        for (int i = startIndex; i <= endIndex; i++)
        {           
            appendIndexes.Append(input[i]);
        }
                
        return appendIndexes.ToString();
    }
}

