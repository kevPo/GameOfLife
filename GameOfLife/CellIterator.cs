using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellIterator : IIterator<Cell>
    {
        private IEnumerable<Cell> cells;
        private Cell homeCell;

        public CellIterator(IEnumerable<Cell> cells, Cell homeCell)
        {
            this.cells = cells;
            this.homeCell = homeCell;
        }

        public void Initialize(IEnumerable<Cell> cells)
        {
            this.cells = cells;
        }

        public void First()
        {
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public Boolean IsDone()
        {
            throw new NotImplementedException();
        }

        public Cell CurrentItem()
        {
            throw new NotImplementedException();
        }
    }
}
