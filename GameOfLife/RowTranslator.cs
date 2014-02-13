﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class RowTranslator : ITranslator
    {
        private const Char ALIVE = '*';
        private const Char DEAD = '.';

        public List<Cell> Translate(Int32 rowNumber, String rowData)
        {
            var rawCells = rowData.ToCharArray();
            var cells = new List<Cell>();

            for (var i = 0; i < rawCells.Count(); i++)
                cells.Add(new Cell { Y = rowNumber, X = i, IsAlive = rawCells[i] == '*' });

            return cells;
        }
    }
}