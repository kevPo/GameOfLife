using System;
namespace GameOfLife
{
    public class GameOfLife
    {
        private GameCriteria criteria;
        private Board board;

        public GameOfLife(String gameInput, GameCriteria criteria, 
                          ITranslator<GameData> translator, BoardFactory boardFactory)
        {
            this.criteria = criteria;
            var gameData = translator.Translate(gameInput);
            board = boardFactory.GetBoard(gameData);
        }

        public String ViewGameBoard()
        {
            return board.ToString();
        }

        public String NextGeneration()
        {
            board.Generate(criteria);

            return board.ToString();
        }
    }
}
