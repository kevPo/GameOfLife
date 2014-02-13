using System;

namespace GameOfLife
{
    public interface IIterator<T>
    {
        void First();
        void Next();
        Boolean IsDone();
        T CurrentItem();
    }
}
