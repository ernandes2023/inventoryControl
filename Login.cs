using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventoryControl
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Hide();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server = localhost; database = assistencia; uid = root; pwd =etec");
            conectar.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand();
                //Comando SQL
                comando.CommandText = "select * from tecnico where login = '" + txtLogin.Text + "' and senha = '" + txtSenha.Text + "'";

                comando.Connection = conectar;
                //Executar Comando
                var resultado = comando.ExecuteScalar();

                if (resultado != null)
                {
                     Cad_produtos cadprodutos = new Cad_produtos();
                     cadprodutos.Show();
                     this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException er)
            {
                MessageBox.Show("Erro do Banco de dados " + er, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
                conectar.ClearAllPoolsAsync();
            }
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
