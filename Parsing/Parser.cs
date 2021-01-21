using System;
using System.Collections.Generic;
using System.Text;

using Malbec.Options;

namespace Malbec.Parsing
{
    public class Parser
    {
        public string[] Argv { get; private set; }
        public int Argc
        {
            get
            {
                return Argv.Length;
            }
        }
        public string Optstring { get; private set; }

        public List<Option> Options { get; private set; }   // program options which may or may not take arguments

        public List<string> Arguments { get; private set; } // program arguments (elements of argv which are neither options nor option arguments)

        private void PrintOptions()
        {
            foreach (Option o in Options)
            {
                bool isArgumented = o is ArgumentedOption;

                Console.WriteLine("****** Option ******");
                Console.WriteLine("Symbol: " + o.Symbol);
                Console.WriteLine("Is argumented: " + isArgumented);

                if (isArgumented)
                {
                    ArgumentedOption a = o as ArgumentedOption;
                    Console.WriteLine("Argument required: " + a.RequiresArgument);
                }
            }
        }

        public Parser(string[] argv, string optstring)
        {
            Argv = argv;
            Optstring = optstring;

            Options = OptionStringParser.ParseOptionString(Optstring);

            PrintOptions(); // debug
        }

        public bool OptionExists(char symbol)
        {
            return Options.Find(e => (e.Symbol == symbol)) != null;
        }

        public string GetArgument(char symbol)
        {
            return "";
        }

        public Option GetOption(char symbol)
        {
            return Options.Find(e => (e.Symbol == symbol));
        }
    }
}
