public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
        for (int i = 0; i < GetDuration() / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithDots(3);
            Console.WriteLine("Breathe out...");
            PauseWithDots(3);
        }
        EndActivity();
    }
}
