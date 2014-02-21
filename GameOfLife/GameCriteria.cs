using System;
namespace GameOfLife
{
    public class GameCriteria
    {
        public Char AliveValue { get; set; }
        public Char DeadValue { get; set; }
        public ICellIterator CellIterator { get; set; }
        public IGameRules GameRules { get; set; }
    }
}
