using System;

namespace GameOfLife
{
    public interface IGameRules
    {
        Boolean IsLifeGrantedFor(Boolean cellIsAlive, Int32 aliveNeighbors);
    }
}
