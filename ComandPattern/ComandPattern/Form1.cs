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
        private NextMove CurrentMove;
        public Form1()
        {
            Game = new TicTacToe();
            command = new TicTacToeCommand(Game);
            CurrentMove = NextMove.X;
            InitializeComponent();
        }
        private void MoveChanged()
        {
            CurrentMove = CurrentMove == NextMove.X ? NextMove.O : NextMove.X;
        }

        private string SetMove(int x, int y)
        {
            var cell = Game.GetCell(x, y);
            if (cell != NextMove.Empty) return cell.ToString();
            command.Execute(x, y, CurrentMove);
            MoveChanged();
            return Game.GetCell(x, y).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = SetMove(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = SetMove(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = SetMove(0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = SetMove(1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = SetMove(1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = SetMove(1, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = SetMove(2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = SetMove(2, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = SetMove(2, 2);
        }
    }
}
