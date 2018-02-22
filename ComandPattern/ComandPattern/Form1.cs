using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComandPattern
{
    public partial class Form1 : Form
    {
        private TicTacToe Game;
        private TicTacToeCommand command;
        private Button[,] buttons;
        private NextMove CurrentMove;
        public Form1()
        {
            Game = new TicTacToe();
            command = new TicTacToeCommand(Game);
            CurrentMove = NextMove.X;
            InitializeComponent();

            buttons = new Button[3, 3]
            {
               { button1, button2, button3 },
               { button4, button5, button6 },
               { button7, button8, button9 }
            };

            Game.CellChanged += CellChanged;
        }
        private void MoveChanged()
        {
            CurrentMove = CurrentMove == NextMove.X ? NextMove.O : NextMove.X;
        }


        private void CellChanged(int x, int y)
        {
            string move;
            var cell = Game.GetCell(x, y);
            if (cell == NextMove.Empty) move = "";
            else
                move = cell.ToString();

            buttons[x, y].Text = move;
        }

        private void SetMove(int x, int y)
        {
            if (Game.GetCell(x, y) != NextMove.Empty) return;
            command.Execute(x, y, CurrentMove);
            MoveChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMove(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetMove(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetMove(0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetMove(1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetMove(1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetMove(1, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetMove(2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetMove(2, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SetMove(2, 2);
        }
    }
}
