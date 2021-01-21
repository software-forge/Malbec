using System;
using System.Collections.Generic;
using System.Text;

namespace Malbec.Options
{
    /*
        Represents an option which takes an argument
    */
    public class ArgumentedOption : Option
    {
        public string Argument { get; set; }

        public bool RequiresArgument { get; private set; }

        public bool HasArgument
        {
            get
            {
                return Argument != null;
            }
        }

        public ArgumentedOption(char symbol, bool argumentRequired) : base(symbol)
        {
            RequiresArgument = argumentRequired;
        }
    }
}
