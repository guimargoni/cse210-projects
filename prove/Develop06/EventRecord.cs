using System;

public class EventRecord
{
    public string GoalName { get; set; }
    public DateTime Timestamp { get; set; }

    public EventRecord(string goalName)
    {
        GoalName = goalName;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{GoalName},{Timestamp}";
    }
}
