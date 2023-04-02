using System;
using System.Collections.Generic;

public class Activity
{
    private DateTime date;
    public int length; // in minutes

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({length} min)";
    }
}

public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (length / 60.0);
    }

    public override double GetPace()
    {
        return length / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {distance:F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (length / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} miles, Speed {speed:F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1609.34; // convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (length / 60.0);
    }

    public override double GetPace()
    {
        return length / laps / 50.0 * 60.0; // convert meters to minutes per mile
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();
        activities.Add(new Running(new DateTime(2003, 11, 1), 30, 3.0));
        activities.Add(new Running(new DateTime(1973, 10, 29), 30, 4.8));
        activities.Add(new Cycling(new DateTime(1999, 06, 11), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2023, 1, 4), 60, 10));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
