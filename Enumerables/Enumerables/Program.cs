using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Enumerables
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = "aSd2&5s@1";
            new WithoutRegex().Run(input);
            new WithRegex().Run(input);
        }


    }

    public class WithRegex
    {
        Regex r = new Regex(@"(?<str>.+?)(?<num>\d+)");

        public void Run(string input)
        {
            StringBuilder final = new StringBuilder();
            var matches = r.Matches(input);

            foreach (Match match in matches)
            {
                for (int i = 0; i < Int32.Parse(match.Groups["num"].Value); i++)
                {
                    final.Append(match.Groups["str"].Value.ToUpper());
                }
            }

            Console.WriteLine(final.ToString());
        }
    }

    public class WithoutRegex
    {
        StringBuilder final = new StringBuilder();
        StringBuilder stringBuilder = new StringBuilder();
        StringBuilder intBuilder = new StringBuilder();

        public void Run(string input)
        {

            bool lastWasInt = false;
            foreach (char c in input) //Enumerate string by each character
            {
                if (!Char.IsDigit(c)) // check if current character is not a digit
                {
                    if (lastWasInt) // reset temporary builders and put result in final
                    {
                        lastWasInt = false;

                        PopulateFinal();
                    }

                    stringBuilder.Append(Char.ToUpper(c));
                }
                else
                {
                    intBuilder.Append(c);
                    lastWasInt = true;
                }
            }
            PopulateFinal();
            Console.WriteLine(final.ToString());
        }

        void PopulateFinal()
        {
            if (stringBuilder.Length == 0 || intBuilder.Length == 0)
            {
                return;
            }

            int count = Int32.Parse(intBuilder.ToString());
            intBuilder.Clear();

            string stamp = stringBuilder.ToString();
            stringBuilder.Clear();
            for (int i = 0; i < count; i++)
            {
                final.Append(stamp);
            }
        }
    }
}
