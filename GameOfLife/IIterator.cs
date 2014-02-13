using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public interface IIterator<T>
    {
        void Initialize(IEnumerable<T> list);
        void First();
        void Next();
        Boolean IsDone();
        T CurrentItem();
    }
}
