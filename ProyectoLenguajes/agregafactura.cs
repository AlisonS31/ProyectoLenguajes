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
    public partial class agregafactura : Form
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        public agregafactura()
        {
            InitializeComponent();
        }

        private void agregafactura_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                OracleCommand comando = new OracleCommand("insertarFactura", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                //agregar todos los parametros a recibir
                comando.Parameters.Add("idusuario", OracleType.Number).Value = Convert.ToInt32(txtIdUsuario.Text);
                comando.Parameters.Add("idcliente", OracleType.Number).Value = Convert.ToInt32(txtIdCliente.Text);
                comando.Parameters.Add("idarticulo", OracleType.Number).Value = Convert.ToInt32(txtIdArticulo.Text);
                comando.Parameters.Add("dia", OracleType.DateTime).Value = Convert.ToDateTime(txtFecha.Text);
                comando.Parameters.Add("precio", OracleType.VarChar).Value = Convert.ToInt32(txtMonto.Text);

                //ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();
                //mensaje para validar lo que se hizo
                MessageBox.Show("Factura agregada correctamente, cargue de nuevo la tabla.");
            }
            catch (Exception)
            {
                MessageBox.Show("La factura no pudo ser agregada");
            }
            //cerrar conexion
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            factura factura = new factura();
            factura.Show();
            this.Hide();
        }
    }
}
