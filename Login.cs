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
            MySqlConnection conectar = new MySqlConnection("server = localhost; database = assistencia; uid = root; pwd =''");
            conectar.Open();
            MySqlDataAdapter validar = new MySqlDataAdapter("select * from tecnico where login = '"+ txtLogin.Text+"' and senha = '" +txtSenha.Text+"')", conectar);
            DataTable dt = new DataTable();
            validar.Fill(dt);


           if (dt.Rows.Count == 1)
            {
                Operação principal = new Operação();
                principal.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
