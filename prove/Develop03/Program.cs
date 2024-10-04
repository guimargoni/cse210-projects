using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Word
    {
        public string _Text;
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            _Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? "___" : _Text;
        }
    }

    public class ScriptureReference
    {
        private string _Reference;

        public void SetReference(string reference)
        {
            _Reference = reference;
        }

        public string GetReference()
        {
            return _Reference;
        }
    }

    public class Scripture
    {
        private List<Word> _Words;
        private string _Reference;

        public Scripture(ScriptureReference reference, string text)
        {
            _Reference = reference.GetReference();
            _Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWord()
        {
            Random random = new Random();
            var unhiddenWords = _Words.Where(w => !w.IsHidden).ToList();

            if (unhiddenWords.Count > 0)
            {
                int index = random.Next(unhiddenWords.Count);
                unhiddenWords[index].Hide();
            }
        }

        public void Display()
        {
            Console.WriteLine(_Reference);
            Console.WriteLine(string.Join(" ", _Words));
        }

        public bool AllWordsHidden()
        {
            return _Words.All(w => w.IsHidden);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is the reference for the scripture you want to memorize? ");
            ScriptureReference reference = new ScriptureReference();
            reference.SetReference(Console.ReadLine());
            Console.Write("Now, what does the scripture say? ");
            var scriptureSent = Console.ReadLine();
            Scripture scripture = new Scripture(reference, scriptureSent);

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
