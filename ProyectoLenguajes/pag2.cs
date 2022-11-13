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
    public partial class pag2 : Form
    {
        public pag2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pPersonal", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //boton 2:adquisiciones
        private void button2_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pAdquisicion", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //boton 3: ventas
        private void button3_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("pVentas", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //boton 4: total de ventas (SUMA DE LAS VENTAS REALIZADAS)
        private void button4_Click(object sender, EventArgs e)
        {
            //HACER LA CONEXION CON LA BASE
            OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
            conexion.Open();
            //Buscar el proceso
            OracleCommand comando = new OracleCommand("totalVentas", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tablaDeDatos = new DataTable();
            adaptador.Fill(tablaDeDatos);
            dataGridView1.DataSource = tablaDeDatos;
        }

        //boton para devolver a la pag de home
        private void button5_Click(object sender, EventArgs e)
        {
           Home devolver = new Home();
            devolver.Show();
        }
    }
}
