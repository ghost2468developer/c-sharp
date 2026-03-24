using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        while (true)
        {
            Console.WriteLine("\n=== Student Grade Manager ===");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Show all students");
            Console.WriteLine("3. Show highest and lowest average");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Remove a student");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent(students);
                    break;
                case "2":
                    ShowAllStudents(students);
                    break;
                case "3":
                    ShowHighestLowest(students);
                    break;
                case "4":
                    return;
                case "5":
                    RemoveStudent(students);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    static void AddStudent(List<Student> students)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        int gradeCount;
        while (true)
        {
            Console.Write("Enter number of grades: ");
            if (int.TryParse(Console.ReadLine(), out gradeCount) && gradeCount > 0)
                break;
            Console.WriteLine("Invalid number! Must be a positive integer.");
        }
        List<double> grades = new List<double>();
        for (int i = 0; i < gradeCount; i++)
        {
            double grade;
            while (true)
            {
                Console.Write($"Enter grade #{i + 1} (0-100): ");
                if (double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                {
                    break;
                }
                Console.WriteLine("Invalid grade! Enter a number between 0 and 100.");
            }
            grades.Add(grade);
        }
        Student student = new Student(name, grades);
        students.Add(student);
        Console.WriteLine($"Student {name} added successfully!");
    }
    static void ShowAllStudents(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet.");
            return;
        }
        Console.WriteLine("\nStudents and their averages:");
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name} - Average: {student.GetAverage():F2}");
        }
    }
    static void ShowHighestLowest(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet.");
            return;
        }
        Student highest = students[0];
        Student lowest = students[0];
        foreach (Student student in students)
        {
            if (student.GetAverage() > highest.GetAverage())
                highest = student;

            if (student.GetAverage() < lowest.GetAverage())
                lowest = student;
        }
        Console.WriteLine($"\nHighest Average: {highest.Name} - {highest.GetAverage():F2}");
        Console.WriteLine($"Lowest Average: {lowest.Name} - {lowest.GetAverage():F2}");
    }
    static void RemoveStudent(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to remove.");
            return;
        }
        Console.Write("Enter student name to remove: ");
        string name = Console.ReadLine();
        Student studentToRemove = students.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine($"{name} has been removed.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
class Student
{
    public string Name { get; set; }
    public List<double> Grades { get; set; }
    public Student(string name, List<double> grades)
    {
        Name = name;
        Grades = grades;
    }
    public double GetAverage()
    {
        double sum = 0;
        foreach (double grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }
}