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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = history.Back().Buffer;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = history.Forward().Buffer;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            history.Add(new Memento(richTextBox1.Text));
        }
    }
}
