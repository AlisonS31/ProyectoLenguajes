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
    public partial class Adquisicion : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public Adquisicion()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarAdquisicion", conexion);
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
                OracleCommand comando = new OracleCommand("insertarAdquisicion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("usuario", OracleType.Number).Value = Convert.ToInt32(txtIdUsuario.Text);
                comando.Parameters.Add("articulo", OracleType.Number).Value = Convert.ToInt32(txtIdArticulo.Text);
                comando.Parameters.Add("dia", OracleType.DateTime).Value = Convert.ToDateTime (txtFecha.Text);
                comando.Parameters.Add("cant", OracleType.VarChar).Value = Convert.ToInt32(txtCantidad.Text);

                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Adquisición agregado correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("La adquisición no pudo ser agregada");
            }
            //cerrar conexion
            conexion.Close();
        }

        //PANTALLA TABLAS
        private void button3_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
        }
    }
}
