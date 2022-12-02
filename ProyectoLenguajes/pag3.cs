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
    public partial class pag3 : Form
    {
        public pag3()
        {
            InitializeComponent();
        }

        //boton para ir a la informacion del trigger de articulos
        private void button1_Click(object sender, EventArgs e)
        {
            articulo2 articulo2 = new articulo2();
            articulo2.Show();
            this.Hide();
        }
        //boton para ir a la informacion del trigger de clientes
        private void button2_Click(object sender, EventArgs e)
        {
            clientes2 clientes2 = new clientes2();
            clientes2.Show();
            this.Hide();
        }
        //boton para ir a la informacion del trigger de adquisiciones
        private void button3_Click(object sender, EventArgs e)
        {
            adquisicion2 adquisicion2 = new adquisicion2();
            adquisicion2.Show();
            this.Hide();
        }

        //Devolver a la pag principal
        private void button4_Click(object sender, EventArgs e)
        {
            principal principal = new principal();
            principal.Show();
            this.Hide();
        }
    }
}
