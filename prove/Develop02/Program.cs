using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string userInput;
        
        do
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                string prompt = journal.ChoosePrompt();
                    Console.Write(prompt);
                    string response = Console.ReadLine();                    
                    journal.AddEntry(prompt, response);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveJournalJson(saveFile);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadJournalJson(loadFile);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("There is no such option, please choose again.");
                    break;
            }

        } while (userInput != "5");
    }
}