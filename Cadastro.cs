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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtSenha2.Text == "" || txtLogin2.Text == "" || txtCargo.Text == "")
            {

                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtCargo.Text = "";
                txtLogin2.Text = "";
                txtSenha2.Text = "";

            }
            else
            {
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
                conectar.Open();
                MySqlCommand cadastrar = new MySqlCommand("INSERT INTO tecnico (nome_tec, cargo, login, senha) values ('" + txtNome.Text + "','" + txtCargo.Text + "','" + txtLogin2.Text + "','" + txtSenha2.Text + "');", conectar);
                cadastrar.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);
                txtNome.Text = "";
                txtCargo.Text = "";
                txtLogin2.Text = "";
                txtSenha2.Text = "";
            }

        }

        private void btnOlho2_Click(object sender, EventArgs e)
        {
            if (txtSenha2.PasswordChar == '*')
            {
                txtSenha2.PasswordChar = default;
                btnOlho2.Text = "Esconder senha";
            }
            else
            {
                txtSenha2.PasswordChar = '*';
                btnOlho2.Text = "Mostrar senha";
            }
        }
    }
}
