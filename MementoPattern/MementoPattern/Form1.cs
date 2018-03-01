using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MementoPattern
{
    public partial class Form1 : Form
    {
        private TextBoxHistory history { get; set; }
        public Form1()
        {
            InitializeComponent();
            history = new TextBoxHistory();
            history.Add(new Memento(richTextBox1.Text));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            history.Add(new Memento(richTextBox1.Text));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            richTextBox1.TextChanged -= richTextBox1_TextChanged;
            try
            {
                richTextBox1.Text = history.Undo().Buffer;
            }
            catch (Exception)
            {

            }
            finally { richTextBox1.TextChanged += richTextBox1_TextChanged; }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            richTextBox1.TextChanged -= richTextBox1_TextChanged;
            try
            {
                richTextBox1.Text = history.Redo().Buffer;
            }
            catch (Exception)
            {
            }
            finally { richTextBox1.TextChanged += richTextBox1_TextChanged; }
        }

    }
}
