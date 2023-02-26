using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // display menu and get user choice
        int choice = DisplayMenu();

        // perform activity based on user choice
        switch (choice)
        {
            case 1:
                PerformActivity(new BreathingActivity());
                break;
            case 2:
                PerformActivity(new ReflectionActivity());
                break;
            case 3:
                PerformActivity(new ListingActivity());
                break;
            case 4:
                // quit program
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.Write("Enter choice: ");
        return int.Parse(Console.ReadLine());
    }

    static void PerformActivity(Activity activity)
    {
        activity.Start();
        activity.DoActivity();
        activity.End();
    }
}

abstract class Activity
{
    protected int _duration;

    public void Start()
    {
        Console.WriteLine("Starting activity...");
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin in 3 seconds...");
        Pause(3);
    }

    public void End()
    {
        Console.WriteLine("Good job! You completed the activity within {0} seconds.", _duration);
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        // show animation to user
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write("{0}...", i);
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void DoActivity();
}

class BreathingActivity : Activity
{
    public override void DoActivity()
    {
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
        for (int i = 1; i <= _duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Pause(2);
            Console.WriteLine("Breathe out...");
            Pause(2);
        }
    }
}

class ReflectionActivity: Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void DoActivity()
    {
        Console.WriteLine("Reflect on the following prompt:");
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        string randomPrompt = _prompts[index];

        Console.WriteLine(randomPrompt);

        Console.WriteLine("\nAnswer the following questions:");
        foreach (string question in _questions)
        {
            Console.Write("- " + question + " ");
            Console.ReadLine();
        }
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void DoActivity()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
        
        // select a random prompt
        Random rnd = new Random();
        int _index = rnd.Next(_prompts.Count);
        string _prompt = _prompts[_index];

        Console.WriteLine(_prompt);
        Pause(3);

        Console.WriteLine("List as many items as you can until the timer runs out.");
        Console.WriteLine("Press Enter after each item to add it to your list.");
        Console.WriteLine("Your time starts now!");
        
        // initialize a list to hold the user's entries
        List<string> _entries = new List<string>();
        
        // loop until the duration runs out
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            string entry = Console.ReadLine();
            if (entry != "")
            {
                _entries.Add(entry);
                count++;
            }
        }

        Console.WriteLine("You listed {0} items.", count);
    }
}