
using System;
namespace GameOfLife
{
    public class GameOfLife
    {
        private Board board;

        public GameOfLife(String gameInput, 
            ITranslator<GameData> translator, BoardFactory boardFactory)
        {
            var gameData = translator.Translate(gameInput);
            board = boardFactory.GetBoard(gameData);
        }

        public String ViewGameBoard()
        {
            return board.ToString();
        }

    }
}
