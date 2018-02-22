using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComandPattern
{
    public partial class Form1 : Form
    {
        private TicTacToe Game;
        private TicTacToeCommand command;
        private Button[,] buttons;
        public Form1()
        {
            Game = new TicTacToe(NextMove.X);
            command = new TicTacToeCommand(Game);
            InitializeComponent();

            buttons = new Button[3, 3]
            {
               { button1, button2, button3 },
               { button4, button5, button6 },
               { button7, button8, button9 }
            };

            Game.CellChanged += CellChanged;
            Game.Winner += Winner;
            Game.RoundDraw += RoundDraw;
        }
        

        private void Winner(string winner)
        {
            MessageBox.Show($"Player {winner} Wins!");
            Application.Exit();
        }

        private void RoundDraw(string message)
        {
            MessageBox.Show($"Round draw: {message}");
            Application.Exit();
        }

        private void CellChanged(int x, int y)
        {
            string move = "";
            Color fg = Color.Black;
            var cell = Game.GetCell(x, y);
            if(cell == NextMove.X)
            {
                move = cell.ToString();
                fg = Color.Green;
            }
            else if(cell == NextMove.O)
            {
                move = cell.ToString();
                fg = Color.Red;
            }

            buttons[x, y].Text = move;
            buttons[x, y].ForeColor = fg;
        }

        private void SetMove(int x, int y)
        {
            if (Game.GetCell(x, y) != NextMove.Empty) return;
            command.Execute(x, y);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            command.Undo();
        }
    }
}
