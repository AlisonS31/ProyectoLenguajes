using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajes
{
    public partial class pag1 : Form
    {
        public pag1()
        {
            InitializeComponent();
        }

        //BUTTON 1: TABLA DE INVENTARIO
        private void button1_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pInventario", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //BUTTON 2: PROVEEDORES
        private void button2_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pProveedores", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //BOTON 3: CLIENTES FRECUENTES
        private void button3_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("cFrecuentes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //BUTTON 4: CLIENTES REGULARES
        private void button4_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pClientes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //Boton 5: pasar a la siguiente pagina
        private void button5_Click(object sender, EventArgs e)
        {
            pag2 Siguiente = new pag2();
            Siguiente.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //boton para la pag home
        private void button6_Click(object sender, EventArgs e)
        {
            principal devolver = new principal();
            devolver.Show();
            this.Hide();
        }
    }
}
