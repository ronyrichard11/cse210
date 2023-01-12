using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> num_list = new List<int>();

        int number = -1;
        int sum = 0;
        

        Console.WriteLine("Enter a List of Numbers, type 0 when finished!");

        while (number != 0){
            Console.WriteLine("Enter Number:");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0){
                num_list.Add(number);
            }
        }

        foreach (int i in num_list)
        {
            sum += i;
        }

        Console.WriteLine($"The sum is {sum}");

        float average = ((float)sum) / num_list.Count;
        Console.WriteLine($"The average is {average}");

        int largest = num_list[0];

        foreach (int numbers in num_list)
        {
            if (numbers > largest)
            {

                largest = numbers;
            }
        }

        Console.WriteLine($"The max is {largest}");

    }
}