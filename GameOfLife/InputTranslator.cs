using System;
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
            var rows = lines.ToList();
            rows.RemoveAt(0);

            return new GameData { Dimensions = dimensions, Rows = rows };
        }
    }
}
