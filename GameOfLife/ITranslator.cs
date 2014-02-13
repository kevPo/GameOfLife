using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public interface ITranslator
    {
        List<Cell> Translate(Int32 rowNumber, String rowData);
    }
}
