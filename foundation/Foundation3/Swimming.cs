using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Swimming : Activity
{
    private int laps; 

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return (laps * 50.0 / 1000.0) * 0.621371;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / duration) * 60;
    }

    public override double GetPace()
    {
        return duration / GetDistance();
    }
}