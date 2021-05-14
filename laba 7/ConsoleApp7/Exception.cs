using System;

namespace ConsoleApp7
{
    public class EnteringExceptions : Exception
    {
        public EnteringExceptions(string message) : base(message)
        {
        }
    }
}