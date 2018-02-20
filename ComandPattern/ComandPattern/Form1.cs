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
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "" || button1.Text == "O")
                button1.Text = "X";
            else if (button1.Text == "X")
                button1.Text = "O";
        }
    }
}
