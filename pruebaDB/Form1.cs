using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pruebaDB
{
    public partial class Form1 : Form
    {
        private SqlConnection CNX=null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CNX.Open();
                string mensaje = "version del servidor es= " + CNX.ServerVersion +
                    "\nla conexion esta= " + CNX.State.ToString() +
                    "\nse accedio ala base de datos";

                MessageBox.Show(mensaje, "alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exc)
            {
                string mensajerror = "error al conectarce a la base de datos: " + exc.Message;
                MessageBox.Show(mensajerror, "alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                CNX.Close();
                MessageBox.Show("se salio de base de datos ", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string CadenaDeconexion = @"Server=(LocalDB)\MSSQLLocalDB;Database= master;Trusted_Connection=True;";
            CNX = new SqlConnection(CadenaDeconexion);
        }
    }
}
