using System;

namespace ConsoleApp7
{
    public class ParseExceptions : Exception
    {
        public ParseExceptions(string message) : base(message)
        {
        }
    }

    public class EnteringExceptions : Exception
    {
        public EnteringExceptions(string message) : base(message)
        {
        }
    }
}