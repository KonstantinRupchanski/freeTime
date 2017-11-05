using System;
using System.Collections.Generic;
using System.Linq;
namespace exe
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter some text: ");

            var text = Console.ReadLine();
            var chars = text.ToCharArray()
                .Where(x => Char.IsLetter(x))
                .Select(x => Char.ToUpper(x));
            Console.WriteLine();

            var characterCount = new Dictionary<char, int>();

            foreach (var c in chars)
            {
                if (characterCount.ContainsKey(c))
                {
                    characterCount[c] += 1;
                }
                else
                {
                    characterCount[c] = 1;
                }
            }
            Console.WriteLine("Most common letters: ");
            Console.WriteLine();

            int max = characterCount.Max(x => x.Value);

            foreach (var pair in characterCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(20))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value,2:D} {GetBar(pair.Value, max)}");
            }
            Console.ReadKey();
        }

 

        public static string GetBar(int value, int max, int width = 20, char barChar = '#')
        {
            if (value > max) throw new ArgumentException("Max must be greater than Value.");
            int barCount = (int)Math.Round(((double)width / max) * value);
            string bar = new String(barChar, barCount);
            return bar;
        }
    }
}