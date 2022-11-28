using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajes
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        //boton para pagina 1
        private void button1_Click(object sender, EventArgs e)
        {
            pag1 devolver = new pag1();
            devolver.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pag2 devolver = new pag2();
            devolver.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
            this.Hide();
        }
    }
}
