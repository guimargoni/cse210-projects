public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times of strength and resilience.")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
    
        Random random = new Random();
        
        List<string> availablePrompts = prompts.ToList();
        if (availablePrompts.Count > 0)
        {
            int promptIndex = random.Next(availablePrompts.Count);
            Console.WriteLine(availablePrompts[promptIndex]);
            availablePrompts.RemoveAt(promptIndex);
        }
        PauseWithDots(10);
        
        List<string> availableQuestions = questions.ToList();
        for (int i = 0; i < GetDuration() / 5; i++)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = questions.ToList();
            }

            int questionIndex = random.Next(availableQuestions.Count);
            Console.WriteLine(availableQuestions[questionIndex]);
            availableQuestions.RemoveAt(questionIndex);

            PauseWithDots(7);
        }
        EndActivity();
    }
}
