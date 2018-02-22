using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandPattern
{
    interface ICommand
    {
        void Execute(int x, int y);
        void Undo();
    }

    struct Commands
    {
        int x;
        int y;
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

    enum NextMove
    {
        Empty,
        X,
        O
    }

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




    class TicTacToe
    {
        public delegate void FieldCellStateHandler(int x, int y);
        public event FieldCellStateHandler CellChanged;

        public delegate void GameEndsHandler(string winner);
        public event GameEndsHandler Winner;
        public event GameEndsHandler RoundDraw;

        private GameField Game;
        public NextMove CurrentMove { get; set; }
        public TicTacToe(NextMove current)
        {
            Game = GameField.GetInstance();
            CurrentMove = current;
        }
        private bool IsFound(HashSet<NextMove> list)
        {
            if (list.Count == 1 && list.First() != NextMove.Empty) return true;
            return false;
        }

        public NextMove GetCell(int x, int y)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2) throw new ArgumentException("Given Parameters is Incorrect!");
            return Game.Field[x, y];
        }

        public void SetMove(int x, int y, NextMove? move = null)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2) throw new ArgumentException("Given Parameters is Incorrect!");
            var Move = move ?? CurrentMove;
            Game.Field[x, y] = Move;
            CellChanged?.Invoke(x, y);
            FindWinner();
            ScanForRoundDraw();
            MoveChanged();
        }

        private void MoveChanged()
        {
            CurrentMove = CurrentMove == NextMove.X ? NextMove.O : NextMove.X;
        }

        private void FindWinner()
        {
            var result = ScanFieldForWinner();
            if (result != NextMove.Empty)
                Winner?.Invoke(result.ToString());
        }

        private void ScanForRoundDraw()
        {
            bool isEmptyCellExist = false;
            for (int i = 0; i < Game.Field.GetLength(0); i++)
            {
                for (int j = 0; j < Game.Field.GetLength(1); j++)
                {
                    if (Game.Field[i, j] == NextMove.Empty)
                        isEmptyCellExist = true;
                }
            }
            if (!isEmptyCellExist) RoundDraw?.Invoke("Nobody Wins");
        }

        private NextMove ScanFieldForWinner()
        {
            var horizontal = new HashSet<NextMove>();
            var verticale = new HashSet<NextMove>();
            var diagonale1 = new HashSet<NextMove>();
            var diagonale2 = new HashSet<NextMove>();
            for (int i = 0; i < Game.Field.GetLength(0); i++)
            {
                horizontal.Clear();
                verticale.Clear();
                for (int j = 0; j < Game.Field.GetLength(1); j++)
                {
                    horizontal.Add(Game.Field[i, j]);
                    verticale.Add(Game.Field[j, i]);
                }
                if (IsFound(horizontal)) return horizontal.First();
                if (IsFound(verticale)) return verticale.First();
                diagonale1.Add(Game.Field[i, i]);
                diagonale2.Add(Game.Field[i, Game.Field.GetLength(0) - 1 - i]);
            }
            if (IsFound(diagonale1)) return diagonale1.First();
            if (IsFound(diagonale2)) return diagonale2.First();
            return NextMove.Empty;
        }
    }
}
