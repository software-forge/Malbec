using System;

namespace Malbec.Exceptions
{
    public class OptionStringFormatException : Exception
    {
        public char UnexpectedChar { get; private set; }
        public int UnexpectedCharIndex { get; private set; }

        public char RepeatedOption { get; private set; }

        // TODO - two separate exception classes?

        // option redeclaration exception:
        public OptionStringFormatException(char repeatedOption) : base(string.Format("Repeated declaration of '-{0}' option", repeatedOption))
        {
            RepeatedOption = repeatedOption;
        }

        // invalid or unexpected character exception:
        public OptionStringFormatException(char unexpectedChar, int unexpectedCharIndex)
            : base(string.Format("Unexpected character '{0}' at index {1}'",
                                    unexpectedChar,
                                    unexpectedCharIndex)
                  )
        {
            UnexpectedChar = unexpectedChar;
            UnexpectedCharIndex = unexpectedCharIndex;
        }
    }
}
