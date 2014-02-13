using System;

namespace GameOfLife
{
    public class BoardFactory
    {
        public Board GetBoard(String dimensions, String initialLayout)
        {
            var rowsAndColumns = dimensions.Split(' ');

            try
            {
                var rows = Int32.Parse(rowsAndColumns[0]);
                var columns = Int32.Parse(rowsAndColumns[1]);
                return new Board(rows, columns);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Dimensions were not given in an acceptable format 'rows columns'", exception);
            }
        }
    }
}
