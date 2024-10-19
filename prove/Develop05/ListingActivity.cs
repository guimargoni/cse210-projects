public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "Who are your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on positive things in your life by listing them.")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        List<string> items = new List<string>();
        Console.WriteLine("Start listing things:");
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        };

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}
