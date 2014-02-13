using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class RowIterator : IIterator<String>
    {
        private List<String> rows;
        private Int32 current;

        public void Initialize(IEnumerable<String> rowsToTranslate)
        {
            if (rowsToTranslate == null || !rowsToTranslate.Any())
                throw new IteratorException("Input list cannot be empty or null");
            rows = rowsToTranslate.ToList();
            current = 0;
        }

        public void First()
        {
            current = 0;
        }

        public void Next()
        {
            if (!IsDone())
                current++;
        }

        public Boolean IsDone()
        {
            return current + 1 >= rows.Count();
        }

        public String CurrentItem()
        {
            return rows[current];
        }
    }
}
