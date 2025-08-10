using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private string[] _levelNames = {
        "Novice Seeker",           // Level 1 - 1000 points
        "Faithful Pilgrim",        // Level 2 - 2000 points
        "Devoted Disciple",        // Level 3 - 3000 points
        "Righteous Warrior",       // Level 4 - 4000 points
        "Spiritual Guardian",      // Level 5 - 5000 points
        "Divine Champion",         // Level 6 - 6000 points
        "Celestial Knight",        // Level 7 - 7000 points
        "Heavenly Sentinel",       // Level 8 - 8000 points
        "Eternal Master",          // Level 9 - 9000 points
        "Immortal Legend"          // Level 10 - 10000 points
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 0;
    }

    public void Start()
    {
        int choice = 0;
        
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string input = Console.ReadLine();
            choice = int.Parse(input);

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Thanks for using Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        string levelName = GetLevelName();
        int pointsToNextLevel = GetPointsToNextLevel();
        
        Console.WriteLine($"You have {_score} points.");
        
        if (_level > 0)
        {
            Console.WriteLine($"Level: {_level} - {levelName}");
            
            if (_level < 10)
            {
                Console.WriteLine($"Points to next level: {pointsToNextLevel}");
            }
            else
            {
                Console.WriteLine("Congratulations! You have reached the maximum level!");
            }
        }
        else
        {
            Console.WriteLine($"Current Level: 0 - Beginner");
            Console.WriteLine($"Points to Level 1 ({_levelNames[0]}): {1000 - _score}");
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        switch (choice)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                break;
            case 2:
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(checklistGoal);
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            
            if (selectedGoal.IsComplete() && !(selectedGoal is EternalGoal))
            {
                Console.WriteLine("This goal has already been completed!");
                return;
            }

            int oldLevel = _level;
            
            selectedGoal.RecordEvent();
            int pointsEarned = selectedGoal.GetPoints();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");


            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete() && checklistGoal.GetAmountCompleted() == checklistGoal.GetTarget())
                {
                    int bonus = checklistGoal.GetBonus();
                    _score += bonus;
                    Console.WriteLine($"Bonus! You have earned an extra {bonus} points for completing this goal!");
                }
            }

            Console.WriteLine($"You now have {_score} points.");
            
            UpdateLevel();
            if (_level > oldLevel)
            {
                Console.WriteLine();
                Console.WriteLine("🎉 LEVEL UP! 🎉");
                Console.WriteLine($"You have reached Level {_level}: {GetLevelName()}!");
                Console.WriteLine("Keep up the great work on your eternal quest!");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            _score = int.Parse(lines[0]);
            UpdateLevel(); 
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string goalType = parts[0];
                string[] details = parts[1].Split(",");

                switch (goalType)
                {
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new SimpleGoal(details[0], details[1], details[2]);
                        simpleGoal.SetComplete(bool.Parse(details[3]));
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        EternalGoal eternalGoal = new EternalGoal(details[0], details[1], details[2]);
                        _goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new ChecklistGoal(details[0], details[1], details[2], 
                                                                      int.Parse(details[3]), int.Parse(details[4]));
                        checklistGoal.SetAmountCompleted(int.Parse(details[5]));
                        _goals.Add(checklistGoal);
                        break;
                }
            }
            
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }

    private void UpdateLevel()
    {
        _level = CalculateLevel();
    }

    private int CalculateLevel()
    {
        if (_score >= 10000) return 10;
        if (_score >= 9000) return 9;
        if (_score >= 8000) return 8;
        if (_score >= 7000) return 7;
        if (_score >= 6000) return 6;
        if (_score >= 5000) return 5;
        if (_score >= 4000) return 4;
        if (_score >= 3000) return 3;
        if (_score >= 2000) return 2;
        if (_score >= 1000) return 1;
        return 0;
    }

    private string GetLevelName()
    {
        if (_level > 0 && _level <= 10)
        {
            return _levelNames[_level - 1];
        }
        return "Beginner";
    }

    private int GetPointsToNextLevel()
    {
        if (_level < 10)
        {
            int nextLevelPoints = (_level + 1) * 1000;
            return nextLevelPoints - _score;
        }
        return 0;
    }
}