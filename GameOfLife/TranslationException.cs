using System;

namespace GameOfLife
{
    public class TranslationException : Exception
    {
        public TranslationException(String message) : base(message)
        {}
    }
}
