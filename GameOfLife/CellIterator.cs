using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class CellIterator : ICellIterator
    {
        private IEnumerable<Cell> cells;
        private Cell current;
        private Int32 currentIndex;
        private Cell home;

        public void Initialize(IEnumerable<Cell> cells)
        {
            this.cells = cells;
        }

        public void First()
        {
            current = FirstCellFor(home);
            currentIndex = 0;
        }

        private Cell FirstCellFor(Cell homeCell)
        {
            return cells.FirstOrDefault(c => c.Y == homeCell.Y - 1 && c.X == homeCell.X - 1);
        }

        public void Next()
        {
            if (currentIndex == 0)
                current = cells.FirstOrDefault(c => c.Y == home.Y - 1 && c.X == home.X);
            else if (currentIndex == 1)
                current = cells.FirstOrDefault(c => c.Y == home.Y - 1 && c.X == home.X + 1);
            else if (currentIndex == 2)
                current = cells.FirstOrDefault(c => c.Y == home.Y && c.X == home.X - 1);
            else if (currentIndex == 3)
                current = cells.FirstOrDefault(c => c.Y == home.Y && c.X == home.X + 1);
            else if (currentIndex == 4)
                current = cells.FirstOrDefault(c => c.Y == home.Y + 1 && c.X == home.X - 1);
            else if (currentIndex == 5)
                current = cells.FirstOrDefault(c => c.Y == home.Y + 1 && c.X == home.X);
            else if (currentIndex == 6)
                current = cells.FirstOrDefault(c => c.Y == home.Y + 1 && c.X == home.X + 1);

            currentIndex++;
        }

        public Boolean IsDone()
        {
            return currentIndex > 7;
        }

        public Cell CurrentItem()
        {
            return current;
        }

        public void SetHomeCell(Cell homeCell)
        {
            home = homeCell;
        }
    }
}
