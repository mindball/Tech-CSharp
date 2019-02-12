using System;
using System.Collections.Generic;
using System.Linq;

class Courses
{
    static void Main()
    {
        string[] splitInput;
        Dictionary<string, CourseName> courses = new Dictionary<string, CourseName>();

        while(true)
        {
            splitInput = Console.ReadLine().Split(new char[] {':'});
            
            if (splitInput[0].Equals("end"))
                break;

            splitInput[0] = splitInput[0].TrimEnd(' ');
            splitInput[1] = splitInput[1].TrimStart(' ');

            if (courses.ContainsKey(splitInput[0]))
            {
                courses[splitInput[0]].StudentName.Add(new Student(splitInput[1]));
            }
            else
                courses.Add(splitInput[0], new CourseName(splitInput[0], splitInput[1]));
        }

        var sortCoursesByCountOfStudents = courses.OrderByDescending(x => x.Value.StudentName.Count);

        foreach (var item in sortCoursesByCountOfStudents)
        {
            Console.WriteLine($"{item.Value.Name}: {item.Value.StudentName.Count}");

            var sortByNameStudent = item.Value.StudentName.OrderBy(x => x.Name);
            foreach (var studentName in sortByNameStudent)
            {
                Console.WriteLine($"-- {studentName.Name}");


            }
        }
    }
}

class CourseName
{
    //List<Student> studentName = new List<Student>();
    public CourseName(string name, string studentName)
    {
        this.Name = name;
        this.StudentName = new List<Student>(){ new Student(studentName) };
    }

    public string Name { get; set; }

    public List<Student> StudentName { get; set; }
}

class Student
{
    public Student(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}

