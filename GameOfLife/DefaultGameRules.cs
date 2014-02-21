using System;

namespace GameOfLife
{
    public class DefaultGameRules : IGameRules
    {
        public Boolean IsLifeGrantedFor(Boolean cellIsAlive, Int32 aliveNeighbors)
        {
            if (cellIsAlive)
                return !(Underpopulated(aliveNeighbors) || Overpopulated(aliveNeighbors));

            return CanCellBeRevived(aliveNeighbors);
        }

        private Boolean Underpopulated(Int32 aliveNeighbors)
        {
            return aliveNeighbors < 2;
        }

        private Boolean Overpopulated(Int32 aliveNeighbors)
        {
            return aliveNeighbors > 3;
        }

        private Boolean CanCellBeRevived(Int32 aliveNeighbors)
        {
            return aliveNeighbors == 3;
        }
    }
}
