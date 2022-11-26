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
    public partial class tablas : Form
    {
        public tablas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rol rol = new rol();
            rol.Show();
        }

        //devolver a home
        private void button9_Click(object sender, EventArgs e)
        {
            principal devolver = new principal();
            devolver.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario usuario = new usuario();
            usuario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();
            cliente.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tipoart tipoart = new tipoart();
            tipoart.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            articulo articulo = new articulo();
            articulo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Adquisicion Adquisicion = new Adquisicion();
            Adquisicion.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            factura factura = new factura();
            factura.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            detalle detalle = new detalle();
            detalle.Show();
        }
    }
}
