class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.LoadGoals();
        goalManager.ShowMenu();
    }
}
