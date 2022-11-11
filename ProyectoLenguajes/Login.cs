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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //conexion de la base de datos
        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL; PASSWORD = Alison31; USER ID = HR;");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE NUSUARIO = :nusuario AND CONTRASENA = :contrasena", conexion);
            comando.Parameters.AddWithValue(":nusuario",txtUsuario.Text);
            comando.Parameters.AddWithValue(":contrasena",txtContrasena.Text);

            //enviar comando a la base de datos
            OracleDataReader lector = comando.ExecuteReader();

            //comprobar que la consulta deja resultados
            if (lector.Read())
            {
                Home pantalla = new Home();
                conexion.Close();
                pantalla.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
