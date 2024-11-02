using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * duration) / 60; 
    }

    public override double GetSpeed()
    {
        return speed; 
    }

    public override double GetPace()
    {
        return 60 / speed; 
    }
}