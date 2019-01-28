using System;
using System.Collections.Generic;
using System.Linq;

class OrderByAge
{
    static void Main()
    {
        string input;
        List<Person> person = new List<Person>();
        string[] arr;

        while (true)
        {
           input = Console.ReadLine();
           if (input.Equals("End"))
                break;

           arr = input.Split(' ');
           person.Add(new Person(arr[0], arr[1], int.Parse(arr[2])));

        }

        person = person.OrderBy(x => x.Age).ToList();
        foreach (var item in person)
        {
            Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
        }
    }
}

class Person
{
    public Person(string name, string id, int age)
    {
        this.Name = name;
        this.Id = id;
        this.Age = age;
    }

    public string  Name { get; set; }

    public string Id { get; set; }

    public int Age { get; set; }
}

