using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        
        return GetMinutes() / GetDistance();
    }

    protected override string GetActivityName()
    {
        return "Swimming";
    }

    public int GetLaps()
    {
        return _laps;
    }
}