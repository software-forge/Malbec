using System;
using System.Collections.Generic;
using System.Text;

namespace Malbec.Options
{
    public class Option
    {
        public char Symbol { get; private set; }

        public Option(char symbol) { Symbol = symbol; }

        public bool HasSymbol(char c) { return Symbol == c; }
    }
}
