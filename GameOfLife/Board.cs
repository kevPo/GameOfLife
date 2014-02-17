using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        public List<Cell> Cells { get; private set; }
        private Int32 rows;
        private Int32 columns;

        public Board(Int32 rows, Int32 columns, IEnumerable<Cell> cells)
        {
            this.rows = rows;
            this.columns = columns;
            Cells = cells.ToList();

            if (rows < 0 || columns < 0)
                throw new InvalidOperationException("Negative values are not acceptable");

        }

        public Cell GetCellAt(Int32 x, Int32 y)
        {
            return Cells.FirstOrDefault(c => c.X == x && c.Y == y);
        }

        public void SetLifeFor(Int32 x, Int32 y, Boolean alive)
        {
            var cell = Cells.FirstOrDefault(c => c.X == x && c.Y == y);
            
            if (cell != null)
                cell.IsAlive = alive;
        }

        public override string ToString()
        {
            var result = String.Empty;
            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < columns; x++)
                    result += Cells.FirstOrDefault(c => c.Y == y && c.X == x).Value;

                result += '\n';
            }
            return result;
        }

        public void Generate(GameCriteria criteria)
        {
            var nextGeneration = new List<Cell>();

            foreach (var cell in Cells)
            {
                var nextGenerationCell = GetNextGenerationFor(cell, criteria);
                nextGeneration.Add(nextGenerationCell);
            }

            Cells = nextGeneration;
        }

        private Cell GetNextGenerationFor(Cell cell, GameCriteria criteria)
        {
            var nextGenerationCell = cell.Clone();
            nextGenerationCell.IsAlive = LiveOrDie(nextGenerationCell, criteria);
            nextGenerationCell.Value = nextGenerationCell.IsAlive ? criteria.AliveValue : criteria.DeadValue;
            
            return nextGenerationCell;
        }

        private Boolean LiveOrDie(Cell cell, GameCriteria criteria)
        {
            var iterator = criteria.CellIterator;
            var aliveNeighbors = 0;
            iterator.Initialize(Cells);
            iterator.SetHomeCell(cell);

            for (iterator.First(); !iterator.IsDone(); iterator.Next())
            {
                if (iterator.CurrentItem() != null && iterator.CurrentItem().IsAlive)
                    aliveNeighbors++;
            }

            return criteria.GameRules.Life(cell.IsAlive, aliveNeighbors);
        }
    }
}
