using System;

namespace GameOfLife
{
    public interface IGameRules
    {
        Boolean Life(Boolean cellIsAlive, Int32 aliveNeighbors);
    }
}
