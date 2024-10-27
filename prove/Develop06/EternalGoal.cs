public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
    }

    public override string GetDetailsString()
    {
        return $"{Name} - Eternal Goal";
    }

    public override string ToFileString()
    {
        return $"{Name},Eternal,{Points}";
    }
}
