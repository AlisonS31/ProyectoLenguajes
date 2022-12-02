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
    public partial class cliente : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public cliente()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarCliente", conexion);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarCliente", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("nom", OracleType.VarChar).Value = txtNombre.Text;
                comando.Parameters.Add("priape", OracleType.VarChar).Value = txtApeUno.Text;
                comando.Parameters.Add("segape", OracleType.VarChar).Value = txtApeDos.Text;
                comando.Parameters.Add("mail", OracleType.VarChar).Value = txtCorreo.Text;
                comando.Parameters.Add("tel", OracleType.VarChar).Value = txtTelefono.Text;
                comando.Parameters.Add("rol", OracleType.Number).Value = Convert.ToInt32(txtIdRol.Text);
       
                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Cliente agregado correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("El cliente no pudo ser agregado");
            }
            //cerrar conexion
            conexion.Close();
        }

        //Pantalla tablas
        private void button4_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
            this.Hide();
        }

        //actualizar datos
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("actualizarCliente", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //agregar parametros
            comando.Parameters.Add("idcliente", OracleType.Number).Value = Convert.ToInt32(txtId.Text);//convertir a string porque es number
            comando.Parameters.Add("nombre", OracleType.VarChar).Value = txtNombre.Text;
            comando.Parameters.Add("priape", OracleType.VarChar).Value = txtApeUno.Text;
            comando.Parameters.Add("segape", OracleType.VarChar).Value = txtApeDos.Text;
            comando.Parameters.Add("mail", OracleType.VarChar).Value = txtCorreo.Text;
            comando.Parameters.Add("numero", OracleType.VarChar).Value = txtTelefono.Text;
            comando.Parameters.Add("idrol", OracleType.Number).Value = Convert.ToInt32(txtIdRol.Text);
            //ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery();
            //mensaje para validar lo que se hizo
            MessageBox.Show("Actualización realizada correctamente, cargue de nuevo la tabla.");
            //cerrar la base
            conexion.Close();
        }

        //eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("eliminarCliente", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //agregar parametros
            comando.Parameters.Add("idcliente", OracleType.Number).Value = Convert.ToInt32(txtId.Text);//convertir a string porque es number
            
            //ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery();
            //mensaje para validar lo que se hizo
            MessageBox.Show("Cliente eliminado correctamente, cargue de nuevo la tabla.");
            //cerrar la base
            conexion.Close();
        }
    }
}
