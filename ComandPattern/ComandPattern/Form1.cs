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
            field = new char[3,3] {
                { 'o', 'a', 'o' },
                { 'a', 'o', 'x' },
                { 'o', 'i', 'o'} };
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

        private char isMatch(List<char> list)
        {
            var a = list.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();
            if(a != null && a.Count() == 3)
                Console.WriteLine(a.Key);
            return ' ';
        }

        private char Metod()
        {
            List<char> horizontal = new List<char>();
            List<char> verticale = new List<char>();
            List<char> diagonale1 = new List<char>();
            List<char> diagonale2 = new List<char>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                horizontal.Clear();
                verticale.Clear();
                char result;
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    horizontal.Add(field[i, j]);
                    if ((result = isMatch(horizontal)) != ' ') return result;

                    verticale.Add(field[j, i]);
                    if ((result = isMatch(verticale)) != ' ') return result;
                }
                diagonale1.Add(field[i, i]);
                if ((result = isMatch(diagonale1)) != ' ') return result;

                diagonale2.Add(field[i, field.GetLength(0) - 1 - i]);
                if ((result = isMatch(diagonale2)) != ' ') return result;
            }
            return ' ';
        }
    }
}
