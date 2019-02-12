using System;
using System.Collections.Generic;
using System.Linq;

class StudentAcademy
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        Dictionary<string, double> students = new Dictionary<string, double>();
        string name;
        double grade;

        while(input > 0)
        {
            name = Console.ReadLine();
            grade = double.Parse(Console.ReadLine());

            if (students.ContainsKey(name))
            {
                //average grade
                students[name] = (students[name] + grade)/2;
            }
            else
                students.Add(name, grade);
            input--;
        }

        var sortStudentByGrade = students.Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value);

        foreach (var item in sortStudentByGrade)
        {
            Console.WriteLine($"{item.Key} -> {item.Value:f2}");
        }
    }
}

