using System;

class Program
{
    static void Main(string[] args)
    {   
        int A = 90;
        int B = 80;
        int C = 70;
        int D = 60;
        int F = 60;
        ;

        Console.WriteLine("What Grade Percentage did you earn?");
        string string_percentage_grade = Console.ReadLine();
        int percentage_grade = int.Parse(string_percentage_grade);
        
        string letter = "";

        if (percentage_grade >= A){
            letter = "A";
        }
        else if (percentage_grade >= B){
            letter = "B";
        }
        else if (percentage_grade >= C){
            letter = "C";
        }
        else if (percentage_grade >= D){
            letter = "D";
        }
        else if (percentage_grade < F){
            letter = "F";
        }

        Console.WriteLine($"You Earned a {letter} Grade.");

        if (percentage_grade >= C){
            Console.WriteLine("Congratulations! You have passed the class!");
        }

    }
}