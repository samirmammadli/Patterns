namespace ComandPattern
{
    class GameField
    {
        static private GameField Game;
        public NextMove[,] Field;
        private GameField()
        {
            Field = new NextMove[3, 3] {
                { NextMove.Empty, NextMove.Empty, NextMove.Empty },
                { NextMove.Empty, NextMove.Empty, NextMove.Empty },
                { NextMove.Empty, NextMove.Empty, NextMove.Empty } };
        }
        static public GameField GetInstance()
        {
            Game = Game ?? new GameField();
            return Game;
        }
        public void ResetField()
        {
            Game = new GameField();
        }
    }
}
