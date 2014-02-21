using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class RowTranslator : ITranslator<IEnumerable<Cell>>
    {
        private Char alive;
        private Char dead; 

        public RowTranslator(Char alive, Char dead)
        {
            this.alive = alive;
            this.dead = dead;
        }

        public IEnumerable<Cell> Translate(String rowData)
        {
            var rawCells = rowData.ToCharArray();
            var cells = new List<Cell>();

            for (var i = 0; i < rawCells.Count(); i++)
                cells.Add(new Cell { X = i, Value = rawCells[i], IsAlive = rawCells[i] == alive });

            return cells;
        }
    }
}
