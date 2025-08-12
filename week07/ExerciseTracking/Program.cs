using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<Activity> activities = new List<Activity>();

        
        Running runningActivity = new Running(new DateTime(2025, 01, 3), 30, 3.0);
        Cycling cyclingActivity = new Cycling(new DateTime(2025, 01, 4), 45, 15.0);
        Swimming swimmingActivity = new Swimming(new DateTime(2025, 10, 25), 25, 20);

        
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        
        Running runningActivity2 = new Running(new DateTime(2024, 11, 6), 20, 2.5);
        Cycling cyclingActivity2 = new Cycling(new DateTime(2024, 12, 7), 60, 12.5);
        Swimming swimmingActivity2 = new Swimming(new DateTime(2024, 08, 8), 35, 30);

        activities.Add(runningActivity2);
        activities.Add(cyclingActivity2);
        activities.Add(swimmingActivity2);

        
        Console.WriteLine("Exercise Tracker Summary");
        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        Console.WriteLine("Activity Information:");
        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
        Console.WriteLine();

        
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"Activity: {activity.GetType().Name}");
            Console.WriteLine($"Date: {activity.GetDate():dd MMM yyyy}");
            Console.WriteLine($"Duration: {activity.GetMinutes()} minutes");
            Console.WriteLine($"Distance: {activity.GetDistance():F2} miles");
            Console.WriteLine($"Speed: {activity.GetSpeed():F2} mph");
            Console.WriteLine($"Pace: {activity.GetPace():F2} min per mile");
            Console.WriteLine();
        }
    }
}