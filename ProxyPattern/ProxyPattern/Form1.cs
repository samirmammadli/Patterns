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
        private EnRuApiTranslator translator;
        public Form1()
        {
            InitializeComponent();
            translator = EnRuApiTranslator.GetInstance();
        }

        private void btnTranslate_Click(object sender, System.EventArgs e)
        {
            if (tbFrom.Text == string.Empty)
                return;
            try
            {
                tbTo.Text = translator.Translate(tbFrom.Text);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
