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
    public partial class newAdmin : Form
    {
        public newAdmin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (txtName.Text == "" || txtPass.Text == "" || txtConfPass.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Select(); // Coloca o foco no campo de nome caso esteja vazio
                return;
            }

            // Verifica se as senhas digitadas são iguais
            if (txtPass.Text != txtConfPass.Text)
            {
                MessageBox.Show("As senhas digitadas são diferentes! \nPor favor, digite a senha novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Text = "";
                txtConfPass.Text = "";
                txtPass.Select(); // Coloca o foco no campo de senha caso as senhas sejam diferentes
                return;
            }

            // Definir a senha em uma variável e criptografá-la
            string senha = txtPass.Text.GerarHash();

            try
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                using (MySqlConnection conectar = new MySqlConnection(Program.conexaoBD))
                {
                    // Abre a conexão com o banco de dados
                    conectar.Open();

                    // Cria um novo comando MySqlCommand para inserir os dados na tabela usuario
                    using (MySqlCommand cadastrar = new MySqlCommand("INSERT INTO usuario (login, senha, confirm_senha) VALUES (@Login, @Senha, @ConfSenha);", conectar))
                    {
                        // Adiciona parâmetros ao comando
                        cadastrar.Parameters.AddWithValue("@Login", txtName.Text);
                        cadastrar.Parameters.AddWithValue("@Senha", senha);
                        cadastrar.Parameters.AddWithValue("@ConfSenha", senha);

                        // Executa o comando de inserção
                        cadastrar.ExecuteNonQuery();
                    }
                }

                // Exibe uma mensagem de sucesso
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                this.Hide();

               
            }
            catch (Exception ex)
            {
                // Trata exceções e exibe uma mensagem de erro
                MessageBox.Show("Erro: não foi possível salvar as informações. " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
