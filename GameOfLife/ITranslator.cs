using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public interface ITranslator<T>
    {
        T Translate(String data);
    }
}
