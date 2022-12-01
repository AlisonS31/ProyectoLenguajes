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
    public partial class usuario : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public usuario()
        {
            InitializeComponent();
        }

        //cargar datos
        private void button1_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarUsuario", conexion);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarUsuario", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("nom", OracleType.VarChar).Value = txtNombre.Text;
                comando.Parameters.Add("priape", OracleType.VarChar).Value = txtApeUno.Text;
                comando.Parameters.Add("segape", OracleType.VarChar).Value = txtApeDos.Text;
                comando.Parameters.Add("mail", OracleType.VarChar).Value = txtCorreo.Text;
                comando.Parameters.Add("tel", OracleType.VarChar).Value = txtTelefono.Text;
                comando.Parameters.Add("rol", OracleType.Number).Value = Convert.ToInt32(txtIdRol.Text);
                comando.Parameters.Add("salar", OracleType.VarChar).Value = Convert.ToInt32(txtSalario.Text);
                comando.Parameters.Add("comi", OracleType.VarChar).Value = Convert.ToInt32(txtComision.Text);
                comando.Parameters.Add("usuario", OracleType.VarChar).Value = txtUsuario.Text;
                comando.Parameters.Add("contra", OracleType.VarChar).Value = txtContra.Text;
                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Usuario agregado correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario no pudo ser agregado");
            }
            //cerrar conexion
            conexion.Close();
        }

        //pagina tablas
        private void button4_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
            this.Hide();
        }

        private void usuario_Load(object sender, EventArgs e)
        {

        }

        //boton de actualizar
        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("actualizarUsuario", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //agregar parametros
            comando.Parameters.Add("idusuario", OracleType.Number).Value = Convert.ToInt32(txtId.Text);//convertir a string porque es number
            comando.Parameters.Add("nombre", OracleType.VarChar).Value = txtNombre.Text;
            comando.Parameters.Add("priape", OracleType.VarChar).Value = txtApeUno.Text;
            comando.Parameters.Add("segape", OracleType.VarChar).Value = txtApeDos.Text;
            comando.Parameters.Add("mail", OracleType.VarChar).Value = txtCorreo.Text;
            comando.Parameters.Add("numero", OracleType.VarChar).Value = txtTelefono.Text;
            comando.Parameters.Add("idrol", OracleType.Number).Value = Convert.ToInt32(txtIdRol.Text);
            comando.Parameters.Add("salar", OracleType.VarChar).Value = Convert.ToInt32(txtSalario.Text);
            comando.Parameters.Add("comi", OracleType.VarChar).Value = Convert.ToInt32(txtComision.Text);
            comando.Parameters.Add("usuario", OracleType.VarChar).Value = txtUsuario.Text;
            comando.Parameters.Add("contra", OracleType.VarChar).Value = txtContra.Text;
            //ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery();
            //mensaje para validar lo que se hizo
            MessageBox.Show("Actualización realizada correctamente, cargue de nuevo la tabla.");
            //cerrar la base
            conexion.Close();
        }
    }
}
