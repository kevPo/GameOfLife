using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellIterator : ICellIterator
    {
        private IEnumerable<Cell> cells;
        private Cell current;
        private Cell homeCell;

        public CellIterator(IEnumerable<Cell> cells)
        {
            this.cells = cells;
        }

        public void Initialize(IEnumerable<Cell> cells)
        {
            this.cells = cells;
        }

        public void First()
        {
            current = FirstCellFor(homeCell);
        }

        private Cell FirstCellFor(Cell homeCell)
        {
            return cells.FirstOrDefault(c => c.Y == homeCell.Y - 1 && c.X == homeCell.X - 1);
        }

        public void Next()
        {
            if (current == null)
                return;
            else if (HomeCellIsNext())
                current = cells.FirstOrDefault(c => c.Y == homeCell.Y && c.X == homeCell.X + 1);
            else if (CurrentlyAtEndColumn())
                current = cells.FirstOrDefault(c => c.Y == current.Y + 1 && c.X == homeCell.X - 1);
            else
                current = cells.FirstOrDefault(c => c.Y == current.Y && c.X == current.X + 1);
        }

        private bool CurrentlyAtEndColumn()
        {
            return current.X >= homeCell.X + 1;
        }

        private bool HomeCellIsNext()
        {
            return current.X == homeCell.X - 1 && current.Y == homeCell.Y;
        }

        public Boolean IsDone()
        {
            return current == null || (current.X == homeCell.X + 1 && current.Y == homeCell.Y + 1);
        }

        public Cell CurrentItem()
        {
            return current;
        }

        public void SetHomeCell(Cell homeCell)
        {
            this.homeCell = homeCell;
        }
    }
}
