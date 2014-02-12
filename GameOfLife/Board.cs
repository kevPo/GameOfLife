using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        public List<Cell> Cells { get; private set; }

        public Board(Int32 rows, Int32 columns)
        {
            Cells = new List<Cell>();

            if (rows < 0 || columns < 0)
                throw new InvalidOperationException("Negative values are not acceptable");

            InitializeBoard(rows, columns);
        }

        private void InitializeBoard(Int32 rows, Int32 columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                    Cells.Add(new Cell { IsAlive = false, X = column, Y = row });
            }
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

    }
}
