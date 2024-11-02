public abstract class Activity
{
    protected DateTime date;
    protected int duration;

    public DateTime Date => date;
    public int Duration => duration;

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {GetType().Name} ({duration} min) - Distance: {GetDistance()} " +
               $"{(GetDistance() > 1 ? "miles" : "mile")}, Speed: {GetSpeed()} " +
               $"{(GetSpeed() > 1 ? "mph" : "mph")}, Pace: {GetPace()} " +
               $"{(GetPace() > 1 ? "min per mile" : "min per mile")}";
    }
}
