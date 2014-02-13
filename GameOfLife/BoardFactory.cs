using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoardFactory
    {
        private IIterator<String> rowIterator;

        public BoardFactory(IIterator<String> rowIterator)
        {
            this.rowIterator = rowIterator;
        }

        public Board GetBoard(String dimensions, String initialLayout)
        {
            var rowsAndColumns = dimensions.Split(' ');

            try
            {
                var rows = Int32.Parse(rowsAndColumns[0]);
                var columns = Int32.Parse(rowsAndColumns[1]);

                var cells = BuildCells();
    
                return new Board(rows, columns, cells);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Dimensions were not given in an acceptable format 'rows columns'", exception);
            }
        }

        private IEnumerable<Cell> BuildCells()
        {
            throw new NotImplementedException();
        }
    }
}
