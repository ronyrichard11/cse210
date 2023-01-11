using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 11);

        Console.WriteLine($"The Magic Number is {magic_number}.");
        int guess = -1;

        while (guess != magic_number){
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (guess > magic_number){
                Console.WriteLine("Lower");
            }

            else if (guess < magic_number){
                Console.WriteLine("Higher");
            }
            
        }
        if (guess == magic_number){
            Console.WriteLine("You Guessed it!");
        }
    }
}