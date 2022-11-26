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
    public partial class tipoart : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public tipoart()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarTipoArt", conexion);
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarTipoArt", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("descripcion", OracleType.VarChar).Value = txtDescripcion.Text;
                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Tipo de Artículo agregado correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("El tipo de artículo no pudo ser agregado");
            }
            //cerrar conexion
            conexion.Close();
        }
        
        //pantalla tablas
        private void button3_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
        }
    }
}
