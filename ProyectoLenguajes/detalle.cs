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
    public partial class detalle : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public detalle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //abrir conexion
            conexion.Open();
            OracleCommand comando = new OracleCommand("llamarDetalle", conexion);
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
                OracleCommand comando = new OracleCommand("insertarDetalle", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("idfactura", OracleType.Number).Value = Convert.ToInt32(txtIdFactura.Text);
                comando.Parameters.Add("detalle", OracleType.VarChar).Value = txtDetalle.Text;
                comando.Parameters.Add("cant", OracleType.VarChar).Value = Convert.ToInt32(txtCantidad.Text);
                comando.Parameters.Add("subt", OracleType.VarChar).Value = Convert.ToInt32(txtSubTotal.Text);
                comando.Parameters.Add("impuesto", OracleType.VarChar).Value = Convert.ToInt32(txtIVA.Text);
                comando.Parameters.Add("tot", OracleType.VarChar).Value = Convert.ToInt32(txtTotal.Text);

                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Detalle de Factura agregado correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("El detalle no pudo ser agregado");
            }
            //cerrar conexion
            conexion.Close();
        }

        //pantalla tablas
        private void button3_Click(object sender, EventArgs e)
        {
            tablas tablas = new tablas();
            tablas.Show();
            this.Hide();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("actualizarDetalle", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //agregar parametros
            comando.Parameters.Add("iddetalle", OracleType.Number).Value = Convert.ToInt32(txtIdDetalle.Text);//convertir a string porque es number
            comando.Parameters.Add("idfactura", OracleType.Number).Value = Convert.ToInt32(txtIdFactura.Text);
            comando.Parameters.Add("detalle", OracleType.VarChar).Value = txtDetalle.Text;
            comando.Parameters.Add("numero", OracleType.VarChar).Value = Convert.ToInt32(txtCantidad.Text);
            comando.Parameters.Add("subt", OracleType.VarChar).Value = Convert.ToInt32(txtSubTotal.Text);
            comando.Parameters.Add("impuesto", OracleType.VarChar).Value = Convert.ToInt32(txtIVA.Text);
            comando.Parameters.Add("tot", OracleType.VarChar).Value = Convert.ToInt32(txtTotal.Text);
            //ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery();
            //mensaje para validar lo que se hizo
            MessageBox.Show("Actualización realizada correctamente, cargue de nuevo la tabla.");
            //cerrar la base
            conexion.Close();
        }
    }
}
