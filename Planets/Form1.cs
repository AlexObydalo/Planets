using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planets
{
    public partial class Form1 : Form
    {
        MaterialPoint earth, moon;
        Graphics g;
        public Form1()
        {
            g = this.CreateGraphics();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = timer1.Interval / 1000.0 * 300000;

            Vector m_e = earth.R - moon.R;
            double r3 = Math.Pow(m_e.Abs, 3);
            Vector Fe = -6.67e-29 * moon.M * earth.M * m_e / r3;
            Vector Fm = -Fe;

            moon.Move(dt, Fm);
            earth.Move(dt, Fe);

            pictureBox1.Location = new Point((int)earth.R.X, (int)moon.R.Y);
            
            pictureBox2.Location = new Point((int)moon.R.X, (int)moon.R.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            earth = new MaterialPoint() { M = 6e+24, V = new Vector(), R = new Vector(pictureBox1.Left, pictureBox1.Top) };
            moon = new MaterialPoint() { M = 7e+22, V = new Vector(0.0018,0), R = new Vector(pictureBox2.Left, pictureBox2.Top) };

            timer1.Start();
        }
    }
}
