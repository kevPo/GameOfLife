using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class BoardFactory
    {
        private ITranslator rowTranslator;

        public BoardFactory(ITranslator translator)
        {
            rowTranslator = translator;
        }

        public Board GetBoard(String dimensions, String initialLayout)
        {
            var rowsAndColumns = dimensions.Split(' ');

            try
            {
                var rows = Int32.Parse(rowsAndColumns[0]);
                var columns = Int32.Parse(rowsAndColumns[1]);

                var cells = BuildCells(initialLayout);

                return new Board(rows, columns, cells);
            }
            catch (InvalidOperationException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Dimensions were not given in an acceptable format 'rows columns'", exception);
            }
        }

        private IEnumerable<Cell> BuildCells(String initialLayout)
        {
            if (String.IsNullOrEmpty(initialLayout))
                throw new InvalidOperationException("Layout was undefined");

            var cells = new List<Cell>();
            var rows = initialLayout.Split('\n');
            
            for (var index = 0; index < rows.Count(); index++)
                cells.AddRange(rowTranslator.Translate(index, rows[index]));

            return cells;
        }
    }
}
