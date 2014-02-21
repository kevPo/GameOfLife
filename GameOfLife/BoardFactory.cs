using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class BoardFactory
    {
        private ITranslator<IEnumerable<Cell>> rowTranslator;

        public BoardFactory(ITranslator<IEnumerable<Cell>> translator)
        {
            rowTranslator = translator;
        }

        public Board GetBoard(GameData data)
        {
            var dimensions = data.Dimensions;
            var rowsAndColumns = dimensions.Split(' ');

            try
            {
                var rows = Int32.Parse(rowsAndColumns[0]);
                var columns = Int32.Parse(rowsAndColumns[1]);

                var cells = BuildCells(data.Rows);

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

        private IEnumerable<Cell> BuildCells(IEnumerable<String> dataInRows)
        {
            if (dataInRows == null || !dataInRows.Any())
                throw new InvalidOperationException("Layout was undefined");

            var rows = dataInRows.ToList();
            var cells = new List<Cell>();

            for (var index = 0; index < rows.Count(); index++)
            {
                var cellsToAdd = rowTranslator.Translate(rows[index]);

                foreach (var cell in cellsToAdd)
                    cell.Y = index;

                cells.AddRange(cellsToAdd);
            }

            return cells;
        }
    }
}
