using System;
using System.Collections.Generic;
using System.Text;

using Malbec.Options;
using Malbec.Exceptions;

namespace Malbec.Parsing
{
    public static class OptionStringParser
    {
        public static List<Option> ParseOptionString(string optString)
        {
            List<Option> options = new List<Option>();

            int maxIndex = optString.Length - 1;

            for (int i = 0; i <= maxIndex; i++)
            {
                if (char.IsLetterOrDigit(optString[i]))
                {
                    // An alphanumeric character has been found - treat it as an option symbol

                    char symbol = optString[i];

                    // Check the next two indices of the string for colons to determine whether the option takes (optional) arguments
                    int firstColonIndex = i + 1, secondColonIndex = i + 2;

                    bool takesArguments = (firstColonIndex <= maxIndex) && (optString[firstColonIndex] == ':'),
                         argumentsOptional = (secondColonIndex <= maxIndex) && (optString[secondColonIndex] == ':');

                    Option option;

                    if (takesArguments)
                    {
                        if (argumentsOptional)
                            option = new ArgumentedOption(symbol, false); // option takes argument optionally
                        else
                            option = new ArgumentedOption(symbol, true); // option takes a mandatory argument
                    }
                    else
                    {
                        // the option does not take arguments
                        option = new Option(symbol);
                    }

                    // TODO:

                    if (options.Find(e => e.Symbol == optString[i]) == null)
                        options.Add(option);
                    else
                        throw new OptionStringFormatException(optString[i]);
                }
                else
                {
                    // TODO:

                    if (optString[i] == ':')
                    {
                        
                        if (options.Count == 0 || // a colon has been encountered at the beginning of the string (before any option symbols)
                                (optString[i - 1] == ':' &&
                                 optString[i - 2] == ':')) // a third, subsequent colon has been encountered
                                    throw new OptionStringFormatException(optString[i], i);
                    }
                    else
                    {
                        throw new OptionStringFormatException(optString[i], i);
                    }
                        
                }
            }

            return options;
        }
    }
}
