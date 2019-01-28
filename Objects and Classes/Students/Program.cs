using System;
using System.Collections.Generic;
using System.Linq;

class Students
{
    private int countOfStudents = 0;
    public Students(string firstName, string secondName, double grade)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Grade = grade;
        countOfStudents++;
    }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public double Grade { get; set; }

    public int CountOfStudents
    {
        get
        {
            return countOfStudents;
        }
    }

    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        List<Students> listOfStudents = new List<Students>();
        string[] studentsDetails;                

        while(input > 0)
        {
            studentsDetails = Console.ReadLine().Split(' ');
            listOfStudents.Add(new Students(studentsDetails[0], studentsDetails[1], double.Parse(studentsDetails[2])));
            input--;
        }

        listOfStudents = listOfStudents.OrderByDescending(x => x.Grade).ToList();
        foreach (var item in listOfStudents)
        {
            Console.WriteLine($"{item.FirstName} {item.SecondName}: {item.Grade:f2}");
        }

    }
}

