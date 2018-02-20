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
                { 'o', 'a', 'o' },
                { 'a', 'o', 'x' },
                { 'o', 'i', 'g' } };
            InitializeComponent();
            Metod();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "" || button1.Text == "O")
                button1.Text = "X";
            else if (button1.Text == "X")
                button1.Text = "O";
        }

        private bool isMatch(List<char> list)
        {
            if (list[0] == ' ') return false;
            var a = list.Where(x => x == list[0]);

            if (a.Count() == 3) { Console.WriteLine(a.First()); return true; }
            return false;
        }

        private char Metod()
        {
            List<char> horizontal = new List<char>(3);
            List<char> verticale = new List<char>(3);
            List<char> diagonale1 = new List<char>(3);
            List<char> diagonale2 = new List<char>(3);
            for (int i = 0; i < field.GetLength(0); i++)
            {
                horizontal.Clear();
                verticale.Clear();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    horizontal.Add(field[i, j]);
                    verticale.Add(field[j, i]);
                }
                if (isMatch(horizontal)) return horizontal[0];
                if (isMatch(verticale)) return verticale[0];
                diagonale1.Add(field[i, i]);
                diagonale2.Add(field[i, field.GetLength(0) - 1 - i]);
            }
            if (isMatch(diagonale1)) return diagonale1[0];
            if (isMatch(diagonale2)) return diagonale2[0];
            return ' ';
        }
    }
}
