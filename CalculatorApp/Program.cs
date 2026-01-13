// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Calculator");
//         Console.Write("Enter first number: ");
//         double num1 = Convert.ToDouble(Console.ReadLine());
//         Console.Write("Enter second number: ");
//         double num2 = Convert.ToDouble(Console.ReadLine());
//         Console.Write("Enter operation (+, -, *, /): ");
//          string operation = Console.ReadLine();
//         double result = 0;
//         if (operation == "+")
//         {
//             result = num1 + num2;
//         }
//         else if (operation == "-")
//         {
//             result = num1 - num2;
//         }
//         else if (operation == "*")
//         {
//             result = num1 * num2;
//         }
//         else if (operation == "/")
//         {
//             if (num2 == 0)
//             {
//                 Console.WriteLine("Error: Cannot divide by zero.");
//                 return;
//             }

//             result = num1 / num2;
//         }
//         else
//         {
//             Console.WriteLine("Invalid operation.");
//             return;
//         }
//         Console.WriteLine($"Result: {result}");
//     }
// }
using System;

class Program
{
    static void Main(string[] args)
    {
        RunCalculator();
    }

    static void RunCalculator()
    {
        Console.WriteLine("Calculator");
        double num1 = GetNumber("Enter first number: ");
        double num2 = GetNumber("Enter second number: ");
        Console.Write("Enter operation (+, -, *, /): ");
        string operation = Console.ReadLine();
        double result = Calculate(num1, num2, operation);
        Console.WriteLine($"Result: {result}");
    }

    static double GetNumber(string message)
    {
        Console.Write(message);
        return Convert.ToDouble(Console.ReadLine());
    }

    static double Calculate(double num1, double num2, string operation)
    {
        if (operation == "+") return num1 + num2;
        if (operation == "-") return num1 - num2;
        if (operation == "*") return num1 * num2;
        if (operation == "/")
        {
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
                return 0;
            }
            return num1 / num2;
        }

        Console.WriteLine("Invalid operation.");
        return 0;
    }
}
