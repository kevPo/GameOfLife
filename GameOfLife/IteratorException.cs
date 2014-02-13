using System;

namespace GameOfLife
{
    public class IteratorException : Exception
    {
        private string p;

        public IteratorException(string message) : base(message)
        {
        }

    }
}
