using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandPattern
{
    interface ICommand
    {
        void Restore();
        void Undo();
    }

    enum NextMove
    {
        Free,
        X,
        O
    }

    class GameField
    {
        static private GameField Game;
        public NextMove[,] field;
        private GameField()
        {
            field = new NextMove[3, 3] {
                { NextMove.Free, NextMove.Free, NextMove.Free },
                { NextMove.Free, NextMove.Free, NextMove.Free },
                { NextMove.Free, NextMove.Free, NextMove.Free } };
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
        private GameField Game;
        public TicTacToe()
        {

            Game = GameField.GetInstance();

        }
        private bool IsFound(HashSet<NextMove> list)
        {
            if (list.Count == 1 && list.First() != NextMove.Free) return true;
            return false;
        }

        public void SetMove(int x, int y, NextMove move)
        {
            if (x < 0 || x > 2 || y < 0 || y > 2) throw new ArgumentException("Given Parameters is Incorrect!");
            Game.field[x, y] = move;
        }

        private NextMove FindWinner()
        {
            var horizontal = new HashSet<NextMove>();
            var verticale = new HashSet<NextMove>();
            var diagonale1 = new HashSet<NextMove>();
            var diagonale2 = new HashSet<NextMove>();
            for (int i = 0; i < Game.field.GetLength(0); i++)
            {
                horizontal.Clear();
                verticale.Clear();
                for (int j = 0; j < Game.field.GetLength(1); j++)
                {
                    horizontal.Add(Game.field[i, j]);
                    verticale.Add(Game.field[j, i]);
                }
                if (IsFound(horizontal)) return horizontal.First();
                if (IsFound(verticale)) return verticale.First();
                diagonale1.Add(Game.field[i, i]);
                diagonale2.Add(Game.field[i, Game.field.GetLength(0) - 1 - i]);
            }
            if (IsFound(diagonale1)) return diagonale1.First();
            if (IsFound(diagonale2)) return diagonale2.First();
            return NextMove.Free;
        }
    }
}
