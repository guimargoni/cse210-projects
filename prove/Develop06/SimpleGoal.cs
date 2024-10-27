public class SimpleGoal : Goal
{
    public bool IsComplete { get; private set; }

    public SimpleGoal(string name, int points) : base(name, points)
    {
        IsComplete = false;
    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetDetailsString()
    {
        return IsComplete ? $"{Name} - Completed!" : $"{Name} - Not Completed";
    }

    public override string ToFileString()
    {
        return $"{Name},Simple,{Points}";
    }
}
