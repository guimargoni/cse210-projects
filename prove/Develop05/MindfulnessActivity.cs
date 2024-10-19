public abstract class MindfulnessActivity
{
    private string _activityName;
    private string _description;
    private int _duration;

    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to {_activityName}");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
        PauseAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Console.WriteLine($"You completed the {_activityName} for {_duration} seconds.");
        Thread.Sleep(3000);
        PauseAnimation(3);
    }

protected void PauseAnimation(int seconds)
{
    List<string> animations = new List<string> { "(o_o)", "(-_-)", "(0_0)", "(0_o)", "(o_0)" };

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(seconds);
    
    int i = 0;

    while (DateTime.Now < endTime)
    {
        Console.Clear();
        Console.Write(animations[i]);
        Thread.Sleep(250);

        i++;
        if (i >= animations.Count)
        {
            i = 0;
        }
    }

    Console.WriteLine();
}


    protected void PauseWithDots(int seconds)
    {
        List<string> animations = new List<string> { ".", "..", "...", "....", "....." };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animations[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\r" + new string(' ', s.Length) + "\r");

            i++;
            if (i >= animations.Count)
            {
                i = 0;
            }
        }
        Console.WriteLine();
    }

    protected void PauseWithBars(int seconds)
    {
        List<string> animations = new List<string> { "-", "\\", "|", "/" };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animations[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;
            if (i >= animations.Count)
            {
                i = 0;
            }
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }

    public abstract void ExecuteActivity();
}