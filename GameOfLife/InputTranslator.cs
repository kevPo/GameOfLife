using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class InputTranslator : ITranslator<GameData>
    {
        public GameData Translate(String data)
        {
            if (String.IsNullOrEmpty(data))
                throw new TranslationException("Invalid game input");

            var lines = data.Split('\n');
            var dimensions = lines[0];
            var rows = new List<String>();

            for (var i = 1; i < lines.Count(); i++)
                rows.Add(lines[i]);

            return new GameData { Dimensions = dimensions, Rows = rows };
        }
    }
}
