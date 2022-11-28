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
    public partial class rol : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");

        public rol()
        {
            InitializeComponent();
        }

        //boton de cargar los datos
        private void btnCargar_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarRol", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registro",OracleType.Cursor).Direction=ParameterDirection.Output;

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
                OracleCommand comando = new OracleCommand("insertarRol", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("rol", OracleType.VarChar).Value = txtRol.Text;
                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Rol agregado correctamente, cargue de nuevo la tabla.");
            }
            catch(Exception)
            {
                MessageBox.Show("El rol no pudo ser agregado");
            }
            //cerrar conexion
            conexion.Close();
        }

        //da error, ver si hay que arreglar codigo o procedimiento!
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("actualizarRol",conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //agregar parametros
            comando.Parameters.Add("idrol",OracleType.Number).Value= Convert.ToInt32(txtId.Text);//convertir a string porque es number
            comando.Parameters.Add("rol", OracleType.VarChar).Value = txtRol.Text;
            //ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery();
            //mensaje para validar lo que se hizo
            MessageBox.Show("Actualización realizada correctamente, cargue de nuevo la tabla.");
            //cerrar la base
            conexion.Close();
        }

        //boton para accede a la pag tablas
        private void button1_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
            this.Hide();
        }
    }
}
