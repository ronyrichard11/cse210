using System;
using System.Collections.Generic;

namespace GoalTracker
{
    abstract class Goal
    {
        protected string _title;
        protected int _points;
        protected bool _completed;

        public Goal(string title, int points)
        {
            _title = title;
            _points = points;
            _completed = false;
        }

        public string Title { get { return _title; } }
        public int Points { get { return _points; } }
        public bool Completed { get { return _completed; } }

        public virtual void RecordEvent()
        {
            _completed = true;
        }

        public virtual string GetStatus()
        {
            return _completed ? "[X]" : "[ ]";
        }
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string title, int points) : base(title, points)
        {
        }

        public override void RecordEvent()
        {
            base.RecordEvent();
        }
    }

    class EternalGoal : Goal
    {
        private int _count;

        public EternalGoal(string title, int points) : base(title, points)
        {
            _count = 0;
        }

        public override void RecordEvent()
        {
            _count++;
        }

        public override string GetStatus()
        {
            return $"Completed {_count} times";
        }
    }

    class ChecklistGoal : Goal
    {
        private int _count;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string title, int points, int target, int bonus) : base(title, points)
        {
            _count = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            _count++;
            if (_count == _target)
            {
                _completed = true;
                _points += _bonus;
            }
        }

        public override string GetStatus()
        {
            return $"Completed {_count}/{_target} times";
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();

        static void Main(string[] args)
        {
            while (true)
            {   Console.WriteLine("=======================");
                Console.WriteLine("\n");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Display Score");
                Console.WriteLine("5. Quit");
                Console.WriteLine("\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        DisplayScore();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        static void CreateNewGoal()
{
    Console.WriteLine("Enter goal type (SIMPLE, ETERNAL, CHECKLIST):");
    string type = Console.ReadLine();

    Console.WriteLine("Enter goal title:");
    string title = Console.ReadLine();

    Console.WriteLine("Enter goal points:");
    int points = int.Parse(Console.ReadLine());

    switch (type)
    {
        case "SIMPLE":
            goals.Add(new SimpleGoal(title, points));
            break;
        case "ETERNAL":
            goals.Add(new EternalGoal(title, points));
            break;
        case "CHECKLIST":
            Console.WriteLine("Enter goal target:");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter bonus points:");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(title, points, target, bonus));
            break;
        default:
            Console.WriteLine("Invalid goal type");
            break;
    }

    Console.WriteLine("New goal created");
}

static void ListGoals()
{
    Console.WriteLine("Goals:");

    for (int i = 0; i < goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Title} ({goals[i].Points} points)");
    }
}

static void RecordEvent()
{   
    Console.WriteLine("Goals:");

    for (int i = 0; i < goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Title} ({goals[i].Points} points)");
    }
    
    Console.WriteLine("Enter goal number:");
    int goalNumber = int.Parse(Console.ReadLine()) - 1;

    if (goalNumber < 0 || goalNumber >= goals.Count)
    {
        Console.WriteLine("Invalid goal number");
        return;
    }

    goals[goalNumber].RecordEvent();

    Console.WriteLine("Event recorded");
}

static void DisplayScore()
{
    int score = 0;

    for (int i = 0; i < goals.Count; i++)
    {
        if (goals[i].Completed)
        {
            score += goals[i].Points;
        }
    }

    Console.WriteLine($"Score: {score}");
}}}
