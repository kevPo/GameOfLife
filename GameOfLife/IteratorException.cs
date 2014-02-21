using System;

namespace GameOfLife
{
    public class IteratorException : Exception
    {
        public IteratorException(string message) : base(message)
        {}
    }
}
