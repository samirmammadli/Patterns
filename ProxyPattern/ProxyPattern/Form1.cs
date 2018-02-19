using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyPattern
{
    public partial class Form1 : Form
    {
        private TranslatorProxy translator;
        public Form1()
        {
            InitializeComponent();
            translator = new TranslatorProxy();
        }

        private void btnTranslate_Click(object sender, System.EventArgs e)
        {
            if (tbFrom.Text == string.Empty)
                return;
            try
            {
                tbTo.Text = translator.Translate(tbFrom.Text);
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tbFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnTranslate_Click(this, e);
            }      
        }
    }
}
