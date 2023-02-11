using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptures = new List<Scripture>
            {
                new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture("Philippians 4:13", "I can do all things through Christ who gives me strength."),
                new Scripture("Daniel 9:3", "And I set my face unto the Lord God, to seek by prayer and supplications, with fasting, and sackcloth, and ashes:")
            };

            var usedScriptures = new List<Scripture>();
            var rnd = new Random();
            Scripture scripture;
            do
            {
                scripture = scriptures[rnd.Next(0, scriptures.Count)];
            }
            while (usedScriptures.Contains(scripture));

            usedScriptures.Add(scripture);

            scripture.Display();

            while (!scripture.IsFullyHidden)
            {
                Console.WriteLine("\nPress enter to hide a word or type 'quit' to end the game:");
                var input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                scripture.HideWord();
                Console.Clear();
                scripture.Display();
            }

            Console.WriteLine("\nThe game has ended.");
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private List<string> hiddenWords;

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.hiddenWords = new List<string>();
        }

        public bool IsFullyHidden
        {
            get
            {
                return hiddenWords.Count == text.Split(' ').Length;
            }
        }

        public void Display()
        {
            Console.WriteLine(reference);
            var words = text.Split(' ');
            foreach (var word in words)
            {
                Console.Write(hiddenWords.Contains(word) ? "___ " : $"{word} ");
            }
        }

        public void HideWord()
        {
            var words = text.Split(' ');
            var word = words[new Random().Next(0, words.Length)];
            hiddenWords.Add(word);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var scripture = (Scripture)obj;
            return reference == scripture.reference && text == scripture.text;
        }

        public override int GetHashCode()
        {
            return reference.GetHashCode() ^ text.GetHashCode();
        }
    }
}
