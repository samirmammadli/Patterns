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
        char[,] field;
        public Form1()
        {
            field = new char[3, 3] {
                { 'a', 'a', 'a' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' } };
            InitializeComponent();
            FindWinner();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "" || button1.Text == "O")
                button1.Text = "X";
            else if (button1.Text == "X")
                button1.Text = "O";
        }

        private bool IsFound(HashSet<char> list)
        {
            if (list.Count == 1 && list.First() != ' ') return true;
            return false;
        }

        private char FindWinner()
        {
            var horizontal = new HashSet<char>();
            var verticale = new HashSet<char>();
            var diagonale1 = new HashSet<char>();
            var diagonale2 = new HashSet<char>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                horizontal.Clear();
                verticale.Clear();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    horizontal.Add(field[i, j]);
                    verticale.Add(field[j, i]);
                }
                if (IsFound(horizontal)) return horizontal.First();
                if (IsFound(verticale)) return verticale.First();
                diagonale1.Add(field[i, i]);
                diagonale2.Add(field[i, field.GetLength(0) - 1 - i]);
            }
            if (IsFound(diagonale1)) return diagonale1.First();
            if (IsFound(diagonale2)) return diagonale2.First();
            return ' ';
        }
    }
}
