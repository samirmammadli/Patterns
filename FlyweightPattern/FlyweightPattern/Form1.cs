using System;
using System.Windows.Forms;

namespace FlyweightPattern
{
    public partial class Form1 : Form
    {
        Flyweight images = new Flyweight();
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();

            pictureBox1.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label1.Text = $"HashCode: {pictureBox1.Image.GetHashCode()}";

            pictureBox2.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label2.Text = $"HashCode: {pictureBox2.Image.GetHashCode()}";

            pictureBox3.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label3.Text = $"HashCode: {pictureBox3.Image.GetHashCode()}";

            pictureBox4.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label4.Text = $"HashCode: {pictureBox4.Image.GetHashCode()}";

            pictureBox5.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label5.Text = $"HashCode: {pictureBox5.Image.GetHashCode()}";

            pictureBox6.Image = images.GetImage((Pictures)rnd.Next(0, 3));
            label6.Text = $"HashCode: {pictureBox6.Image.GetHashCode()}";
        }
    }
}
