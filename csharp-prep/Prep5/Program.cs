using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        string userName = collectUser();
        int userNumber = collectNumber();

        int squaredNumber = squareNumber(userNumber);

        Results(userName, squaredNumber);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string collectUser()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int collectNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int squareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void Results(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
    
}