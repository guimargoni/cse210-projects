using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int magicNumber = random.Next(1, 101);
        int guess = -1;

        Console.WriteLine("Welcome to Guess My Number BYU-I Edition!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}