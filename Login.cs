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
        private bool senhaVisivel = false;

        public static string UltimoValorTextBox { get; set; }
        public Login()
        {
            InitializeComponent();
            //usuario();
            AtualizarBotaoVisualizarSenha();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtLogin1.TextAlign = HorizontalAlignment.Center;
            txtSenha1.TextAlign = HorizontalAlignment.Center;
        }

        private void usuario()
        {

            // Define a string com a consulta SQL
            string query = "SELECT id_usuario FROM usuario WHERE login = 'admin'";

            // Cria uma conexão com o banco de dados
            using (MySqlConnection conectar = new MySqlConnection(Program.conexaoBD))
            {
                try
                {
                    // Abre a conexão com o banco de dados
                    conectar.Open();

                    // Cria um comando MySQL com a consulta SQL
                    using (MySqlCommand consulta = new MySqlCommand(query, conectar))
                    {
                        // Executa a consulta e obtém o resultado
                        using (MySqlDataReader reader = consulta.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Se houver linhas, significa que o usuário "admin" existe
                                //Console.WriteLine("O usuário 'admin' existe no banco de dados.");
                            }
                            else
                            {
                                // Se não houver linhas, significa que o usuário "admin" não existe
                                MessageBox.Show("É necessário cadastrar um usuário administrador");

                                newAdmin admin = new newAdmin(); // Passa o ID do usuário como argumento
                                admin.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trata exceções
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }


            }
        }
        private void btn_entrar_Click(object sender, EventArgs e)
        {

            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            conectar.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand();

                // Criptografa a senha fornecida pelo usuário
                string senhaCriptografada = txtSenha1.Text.GerarHash();// 1. para voltar ao que era antes comente o código ao lado

                // Comando SQL
                comando.CommandText = "SELECT id_usuario FROM usuario WHERE login = @login AND senha = @senha";
                comando.Parameters.AddWithValue("@login", txtLogin1.Text);
                comando.Parameters.AddWithValue("@senha", senhaCriptografada); // 2. para voltar ao que era antes troque o senhaCriptografada por txtSenha1.Text

                comando.Connection = conectar;

                // Executar Comando
                var resultado = comando.ExecuteScalar();

                if (resultado != null)
                {
                    int userId = Convert.ToInt32(resultado); // Obtém o ID do usuário como um número inteiro

                    if (txtLogin1.Text == "admin")
                    {
                        Cadastro cadproduto = new Cadastro();
                        cadproduto.Show();
                        this.Hide();
                    }
                    else
                    {
                        UltimoValorTextBox = txtLogin1.Text;

                        Operação cadprodutos = new Operação(userId); // Passa o ID do usuário como argumento
                        cadprodutos.Show();
                        this.Hide();
                    }
                }


                else if (txtLogin1.Text == "" || txtSenha1.Text == "")
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException er)
            {
                MessageBox.Show("Alguma coisa deu errado!" + er, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
                conectar.ClearAllPoolsAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
                conectar.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand();

                    // Criptografa a senha fornecida pelo usuário
                    string senhaCriptografada = txtSenha1.Text.GerarHash();// 1. para voltar ao que era antes comente o código ao lado

                    // Comando SQL
                    comando.CommandText = "SELECT id_usuario FROM usuario WHERE login = @login AND senha = @senha";
                    comando.Parameters.AddWithValue("@login", txtLogin1.Text);
                    comando.Parameters.AddWithValue("@senha", senhaCriptografada); // 2. para voltar ao que era antes troque o senhaCriptografada por txtSenha1.Text

                    comando.Connection = conectar;

                    // Executar Comando
                    var resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        int userId = Convert.ToInt32(resultado); // Obtém o ID do usuário como um número inteiro

                        if (txtLogin1.Text == "admin")
                        {
                            Cadastro cadproduto = new Cadastro();
                            cadproduto.Show();
                            this.Hide();
                        }
                        else
                        {
                            UltimoValorTextBox = txtLogin1.Text;

                            Operação cadprodutos = new Operação(userId); // Passa o ID do usuário como argumento
                            cadprodutos.Show();
                            this.Hide();
                        }
                    }


                    else if (txtLogin1.Text == "" || txtSenha1.Text == "")
                    {
                        MessageBox.Show("Todos os campos devem ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou Senha inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (MySqlException er)
                {
                    MessageBox.Show("Alguma coisa deu errado!" + er, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conectar.Close();
                    conectar.ClearAllPoolsAsync();
                }
            }

        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            // Alterna a visibilidade da senha
            senhaVisivel = !senhaVisivel;
            AtualizarBotaoVisualizarSenha();
        }
        private void AtualizarBotaoVisualizarSenha()
        {
            if (senhaVisivel)
            {
                // Se a senha estiver visível, mostra a imagem de olho fechado
                BtnShow.Image = Properties.Resources.olho1;
                txtSenha1.UseSystemPasswordChar = false;
            }
            else
            {
                // Se a senha estiver oculta, mostra a imagem de olho aberto
                BtnShow.Image = Properties.Resources.olho2;
                txtSenha1.UseSystemPasswordChar = true;
            }
        }

        private void Login_MouseLeave(object sender, EventArgs e)
        {
            usuario();
        }
    }
}