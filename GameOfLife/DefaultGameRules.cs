using System;

namespace GameOfLife
{
    public class DefaultGameRules : IGameRules
    {
        public Boolean Life(Boolean cellIsAlive, Int32 aliveNeighbors)
        {
            if (cellIsAlive)
            {
                if (Underpopulated(aliveNeighbors) || Overpopulated(aliveNeighbors))
                    return false;

                return true;
            }

            return CanBeRevived(aliveNeighbors);
        }

        private Boolean Underpopulated(Int32 aliveNeighbors)
        {
            return aliveNeighbors < 2;
        }

        private Boolean Overpopulated(Int32 aliveNeighbors)
        {
            return aliveNeighbors > 3;
        }

        private Boolean CanBeRevived(Int32 aliveNeighbors)
        {
            return aliveNeighbors == 3;
        }
    }
}
