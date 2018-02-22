using System.Collections.Generic;

namespace ComandPattern
{
    interface ICommand
    {
        void Execute(int x, int y);
        void Undo();
    }

    class TicTacToeCommand : ICommand
    {
        private TicTacToe Game;
        private Stack<int> X;
        private Stack<int> Y;
        public TicTacToeCommand(TicTacToe game)
        {
            Game = game;
            X = new Stack<int>();
            Y = new Stack<int>();
        }
        public void Execute(int x, int y)
        {
            X.Push(x);
            Y.Push(y);
            Game.SetMove(x, y);
        }

        public void Undo()
        {
            if (X.Count == 0) return;
            Game.SetMove(X.Pop(), Y.Pop(), NextMove.Empty);
        }
    }
}
