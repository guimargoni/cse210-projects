class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program");
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.ExecuteActivity();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.ExecuteActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.ExecuteActivity();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid activity.");
                    break;
            }
        }
    }
}
