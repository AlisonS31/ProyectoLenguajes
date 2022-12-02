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
    public partial class clientes2 : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public clientes2()
        {
            InitializeComponent();
        }

        //cargar datos
        private void button1_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarInfoClientes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registro", OracleType.Cursor).Direction = ParameterDirection.Output;

            //estructuras logicas para que vayan al data grid view
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;

            //cerrar conexion
            conexion.Close();
        }

        //boton atras
        private void button2_Click(object sender, EventArgs e)
        {
            pag3 pag3 = new pag3();
            pag3.Show();
            this.Hide();
        }
    }
}
