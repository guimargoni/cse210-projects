using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? "___" : Text;
        }
    }

    public class ScriptureReference
    {
        private string Reference { get; }

        public ScriptureReference(string reference)
        {
            Reference = reference;
        }

        public override string ToString() => Reference;
    }

    public class Scripture
    {
        private List<Word> Words { get; }
        public ScriptureReference Reference { get; private set; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWord()
        {
            Random random = new Random();
            var unhiddenWords = Words.Where(w => !w.IsHidden).ToList();

            if (unhiddenWords.Count > 0)
            {
                int index = random.Next(unhiddenWords.Count);
                unhiddenWords[index].Hide();
            }
        }

        public void Display()
        {
            Console.WriteLine(Reference);
            Console.WriteLine(string.Join(" ", Words));
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is the reference for the scripture you want to memorize? ");
            var reference = Console.ReadLine();
            Console.Write("Now, what does the scripture say? ");
            var scriptureSent = Console.ReadLine();
            var scriptureReference = new ScriptureReference(reference);
            var scripture = new Scripture(scriptureReference, scriptureSent);

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");

                var input = Console.ReadLine();
                if (input?.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWord();
            }

            Console.Clear();
            Console.WriteLine("All words are hidden. Program has ended.");
        }
    }
}
