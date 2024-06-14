using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Bcpg.OpenPgp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Text.RegularExpressions;

namespace inventoryControl
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;// referente ao codigo de formatação das colunas "senha e conf senha" no dgvUsers
            
            // Chama o método que carrega as informações dentro do dgvClientes e dgvProdutos
            LoadTableClient();
            LoadTableProd();
            LoadTableComp();
            LoadTableDefeito();
        }
        public static class CpfValidator
        {
            public static bool IsValid(string cpf)
            {
                // Remova quaisquer caracteres não numéricos
                cpf = Regex.Replace(cpf, @"[^0-9]", "");

                // Verifique se o comprimento tem 11 dígitos
                if (cpf.Length != 11)
                    return false;

                // Verifique se há padrões de CPF inválidos
                if (new string(cpf[0], 11) == cpf)
                    return false;

                // Calcular a verificação do primeiro dígito
                int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                string tempCpf = cpf.Substring(0, 9);
                int sum = 0;

                for (int i = 0; i < 9; i++)
                    sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

                int remainder = sum % 11;
                if (remainder < 2)
                    remainder = 0;
                else
                    remainder = 11 - remainder;

                string digit = remainder.ToString();
                tempCpf += digit;
                sum = 0;

                for (int i = 0; i < 10; i++)
                    sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

                remainder = sum % 11;
                if (remainder < 2)
                    remainder = 0;
                else
                    remainder = 11 - remainder;

                digit += remainder.ToString();

                return cpf.EndsWith(digit);
            }
        }
        private bool ValorJaInserido(string valor)
        {
            bool jaInserido = false;

            try
            {
                // Conexão com o banco de dados MySQL
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    // Abre a conexão
                    conexaoMYSQL.Open();

                    // Cria um comando SQL para verificar se o valor já existe na tabela
                    string query = "SELECT COUNT(*) FROM produto WHERE cod_produto = @Valor";
                    using (MySqlCommand comando = new MySqlCommand(query, conexaoMYSQL))
                    {
                        // Adiciona o parâmetro para o valor que queremos verificar
                        comando.Parameters.AddWithValue("@Valor", valor);

                        // Executa o comando SQL e obtém o resultado
                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        // Se count for maior que zero, significa que o valor já está na tabela
                        if (count > 0)
                        {
                            jaInserido = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trata exceções, se houver
                MessageBox.Show("Erro ao verificar valor: " + ex.Message);
            }

            return jaInserido;
        }
        private void LoadTableClient() // Metodo privado que carrega dados da tabela Cliente.
        {
            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM cliente", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Renomear as colunas conforme necessário
            dt.Columns["id_cliente"].ColumnName = "Id:";
            dt.Columns["nome_cliente"].ColumnName = "Nome:";
            dt.Columns["cnpj"].ColumnName = "CNPJ:";
            dt.Columns["telefone_cliente"].ColumnName = "Telefone:";
            dt.Columns["email_cliente"].ColumnName = "Email";

            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dgvClientes.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conexaoMYSQL.Close();

            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void LoadTableProd() // Metodo privado que carrega dados da tabela Produto.
        {
            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM produto", conexaoMYSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_produto,cod_produto,nome_produto FROM produto", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Renomear as colunas conforme necessário
            dt.Columns["id_produto"].ColumnName = "Id:";
            dt.Columns["cod_produto"].ColumnName = "Código:";
            dt.Columns["nome_produto"].ColumnName = "Descrição:";
            //dt.Columns["serial_produto"].ColumnName = "Nº Série:";

            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dgvProdutos.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conexaoMYSQL.Close();

            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void LoadTableComp() // Metodo privado que carrega dados da tabela Produto.
        {
            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM componente", conexaoMYSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_componente, nome_comp FROM componente", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Renomear as colunas conforme necessário
            dt.Columns["id_componente"].ColumnName = "Id:";
            dt.Columns["nome_comp"].ColumnName = "Nome:";
            
            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dgvComponentes.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conexaoMYSQL.Close();

            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dgvComponentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void LoadTableDefeito() // Metodo privado que carrega dados da tabela Produto.
        {
            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id,nome_defeito FROM defeito", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Renomear as colunas conforme necessário
            dt.Columns["id"].ColumnName = "Id:";
            dt.Columns["nome_defeito"].ColumnName = "Descrição:";

            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dgvDefeito.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conexaoMYSQL.Close();

            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dgvDefeito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void BtnBackLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void Cadastro_Load_1(object sender, EventArgs e)
        {
            /* Inicialização da tela de cadastro */

            TxtIdUser.Enabled = false;
            txtId1.Enabled = false;
            TxtIdProd.Enabled = false;
            TxtIdComp.Enabled = false;
            txtIdDefeito.Enabled = false;

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            /* Fim da inicialização tela Cadastro */
            try
            {
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    conexaoMYSQL.Open();
                    string query = "SELECT id_usuario, nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha FROM usuario";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMYSQL))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        //Renomear as colunas conforme necessário
                        dt.Columns["id_usuario"].ColumnName = "Id:";
                        dt.Columns["nome_usuario"].ColumnName = "Nome:";
                        dt.Columns["cpf_usuario"].ColumnName = "CPF:";
                        dt.Columns["cargo"].ColumnName = "Cargo";
                        dt.Columns["login"].ColumnName = "Usuário";
                        dt.Columns["senha"].ColumnName = "Senha:";
                        dt.Columns["confirm_senha"].ColumnName = "Conf. Senha:";
                        dgvUsers.DataSource = dt;
                        conexaoMYSQL.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Tratar exceção, registrar em log, etc.
                MessageBox.Show("Ocorreu um erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula atual pertence à coluna de senhas
            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Senha:" || dgvUsers.Columns[e.ColumnIndex].HeaderText == "Conf. Senha:")
            {
                // Obtém o valor atual da célula
                string senhaOriginal = e.Value as string;

                // Substitui todos os caracteres por asteriscos
                string senhaAsteriscos = new string('*', senhaOriginal.Length);

                // Define o valor formatado para exibição
                e.Value = senhaAsteriscos;
            }
        }
        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ao clicar duas vezes na info da lista irá subir as informações  para as textBox.
            TxtIdUser.Text          = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtNameUser.Text        = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtCpfUser.Text         = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtCargoUser.Text       = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtUser.Text            = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtPass.Text            = dgvUsers.Rows[e.RowIndex].Cells[5].Value.ToString();  //ESSES TRECHOS NÃO PODEM SUBIR PARA A TEXT BOX
            TxtConfPass.Text        = dgvUsers.Rows[e.RowIndex].Cells[6].Value.ToString();
            BtnSalvar.Enabled       = false;
            btnMostrar1.Enabled     = false;
            btnMostrar2.Enabled     = false;

            //MessageBox.Show("Digite a nova senha se necessário", "Altere o usuário", MessageBoxButtons.OK);
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (TxtNameUser.Text == "" || TxtCpfUser.Text == "" || TxtCargoUser.Text == "" || TxtUser.Text == "" || TxtPass.Text == "" || TxtConfPass.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNameUser.Select(); // Coloca o foco no campo de nome caso esteja vazio
            }
            // Verifica se as senhas digitadas são iguais
            else if (TxtPass.Text != TxtConfPass.Text)
            {
                MessageBox.Show("As Senhas digitadas São diferentes! \n Por Favor digite a senha novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtPass.Text = "";
                TxtConfPass.Text = "";
                TxtPass.Select(); // Coloca o foco no campo de senha caso as senhas sejam diferentes
            }
            // Verifica se o CPF é válido
            else if (!CpfValidator.IsValid(TxtCpfUser.Text))
            {
                MessageBox.Show("CPF inválido. Por favor, insira um CPF válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCpfUser.Select(); // Coloca o foco no campo de CPF caso seja inválido
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conectar.Open();
                try
                {   // Verifica se o usuário já existe
                    string checkUserQuery = "SELECT COUNT(*) FROM usuario WHERE login = @Login OR cpf_usuario = @CPF";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, conectar);
                    checkUserCmd.Parameters.AddWithValue("@Login", TxtUser.Text);
                    checkUserCmd.Parameters.AddWithValue("@CPF", TxtCpfUser.Text);

                    int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());
                    if (userExists > 0)
                    {
                        MessageBox.Show("Usuário ou CPF já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Definir a senha em uma variável
                    string senha = TxtPass.Text;

                    // Código que realiza a criptografia de senha
                    senha = senha.GerarHash();

                    // Definir a senha em uma variável
                    string senha1 = TxtConfPass.Text;

                    // Código que realiza a criptografia de senha
                    senha1 = senha.GerarHash();

                    // Cria um novo comando MySqlCommand para inserir os dados na tabela usuario
                    MySqlCommand cadastrar = new MySqlCommand("INSERT INTO usuario (nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha) values (@Nome, @CPF, @Cargo, @Login, @Senha, @ConfSenha);", conectar);

                    // Adiciona parâmetros ao comando
                    cadastrar.Parameters.AddWithValue("@Nome", TxtNameUser.Text);
                    cadastrar.Parameters.AddWithValue("@CPF", TxtCpfUser.Text);
                    cadastrar.Parameters.AddWithValue("@Cargo", TxtCargoUser.Text);
                    cadastrar.Parameters.AddWithValue("@Login", TxtUser.Text);
                    cadastrar.Parameters.AddWithValue("@Senha", senha);
                    cadastrar.Parameters.AddWithValue("@ConfSenha", senha1);

                    // Executa o comando de inserção
                    cadastrar.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    TxtNameUser.Text = "";
                    TxtCpfUser.Text = "";
                    TxtCargoUser.Text = "";
                    TxtUser.Text = "";
                    TxtPass.Text = "";
                    TxtConfPass.Text = "";
                    TxtNameUser.Select(); // Coloca o foco no campo de nome
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro não foi possível salvar as informações: " + ex.Message);
                }
                finally
                {
                    conectar.Close();
                }

                // Carrega os dados da tabela usuario no DataGridView dgvUsers
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    conexaoMYSQL.Open();

                    string query = "SELECT id_usuario, nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha FROM usuario";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMYSQL))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        // Renomear as colunas conforme necessário
                        dt.Columns["id_usuario"].ColumnName = "Id:";
                        dt.Columns["nome_usuario"].ColumnName = "Nome:";
                        dt.Columns["cpf_usuario"].ColumnName = "CPF:";
                        dt.Columns["cargo"].ColumnName = "Cargo";
                        dt.Columns["login"].ColumnName = "Usuário";
                        dt.Columns["senha"].ColumnName = "Senha:";
                        dt.Columns["confirm_senha"].ColumnName = "Conf. Senha:";
                        dgvUsers.DataSource = dt;
                    }
                }
            }
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            string senhaCriptografada = TxtPass.Text.GerarHash();
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);

            string senhaCriptografada1 = TxtConfPass.Text.GerarHash();
            MySqlConnection conecta1 = new MySqlConnection(Program.conexaoBD);

            try
            {
                conectar.Open();
                MySqlCommand cadastrar = new MySqlCommand(
                    "UPDATE usuario SET nome_usuario=@Nome, cpf_usuario=@CPF, cargo=@Cargo, login=@Login, senha=@Senha, confirm_senha=@ConfSenha WHERE id_usuario=@Id", conectar);
                
                //abaixo tem os parâmetros que protegem contra SQL injection
                cadastrar.Parameters.AddWithValue("@Nome", TxtNameUser.Text);
                cadastrar.Parameters.AddWithValue("@CPF", TxtCpfUser.Text);
                cadastrar.Parameters.AddWithValue("@Cargo", TxtCargoUser.Text);
                cadastrar.Parameters.AddWithValue("@Login", TxtUser.Text);
                cadastrar.Parameters.AddWithValue("@Senha", senhaCriptografada);
                cadastrar.Parameters.AddWithValue("@ConfSenha", senhaCriptografada1);
                cadastrar.Parameters.AddWithValue("@Id", TxtIdUser.Text);

                cadastrar.ExecuteNonQuery();

                MessageBox.Show("Dados alterados!!!");
                TxtIdUser.Text = "";
                TxtNameUser.Text = "";
                TxtCpfUser.Text = "";
                TxtCargoUser.Text = "";
                TxtUser.Text = "";
                TxtPass.Text = "";
                TxtConfPass.Text = "";
                BtnSalvar.Enabled = true;
                btnMostrar1.Enabled = true;
                btnMostrar2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar os dados: " + ex.Message);
            }
            finally
            {
                conectar.Close();
            }

            AtualizarDataGridView();
        }
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxtIdUser.Text = "";
            TxtNameUser.Text = "";
            TxtCpfUser.Text = "";
            TxtCargoUser.Text = "";
            TxtUser.Text = "";
            TxtPass.Text = "";
            TxtConfPass.Text = "";
            BtnSalvar.Enabled = true;
            btnMostrar1.Enabled = true;
            btnMostrar2.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (TxtIdUser.Text != "")
            {
                DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse usuário?", "Aviso", MessageBoxButtons.YesNo);

                if (caixaMensagem == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
                        conectar.Open();

                        MySqlCommand cadastrar = new MySqlCommand("DELETE FROM usuario WHERE id_usuario = " + TxtIdUser.Text, conectar);
                        cadastrar.ExecuteNonQuery();

                        MessageBox.Show("Dados excluidos com sucesso!");
                        TxtIdUser.Text = "";
                        TxtNameUser.Text = "";
                        TxtCpfUser.Text = "";
                        TxtCargoUser.Text = "";
                        TxtUser.Text = "";
                        TxtPass.Text = "";
                        TxtConfPass.Text = "";
                        BtnSalvar.Enabled = true;
                        btnMostrar1.Enabled = true;
                        btnMostrar2.Enabled = true;

                        conectar.Close();

                        using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                        {
                            conexaoMYSQL.Open();

                            string query = "SELECT id_usuario, nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha FROM usuario";

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMYSQL))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Renomear as colunas conforme necessário
                                dt.Columns["id_usuario"].ColumnName = "Id:";
                                dt.Columns["nome_usuario"].ColumnName = "Nome:";
                                dt.Columns["cpf_usuario"].ColumnName = "CPF:";
                                dt.Columns["cargo"].ColumnName = "Cargo";
                                dt.Columns["login"].ColumnName = "Usuário";
                                dt.Columns["senha"].ColumnName = "Senha:";
                                dt.Columns["confirm_senha"].ColumnName = "Conf. Senha:";

                                dgvUsers.DataSource = dt;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao Excluir os dados: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Você deve Selecionar um Usuário antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AtualizarDataGridView()
        {
            using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
            {
                conexaoMYSQL.Open();
                string query = "SELECT id_usuario, nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha FROM usuario";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMYSQL))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Renomear as colunas conforme necessário
                    dt.Columns["id_usuario"].ColumnName = "Id:";
                    dt.Columns["nome_usuario"].ColumnName = "Nome:";
                    dt.Columns["cpf_usuario"].ColumnName = "CPF:";
                    dt.Columns["cargo"].ColumnName = "Cargo";
                    dt.Columns["login"].ColumnName = "Usuário";
                    dt.Columns["senha"].ColumnName = "Senha:";
                    dt.Columns["confirm_senha"].ColumnName = "Conf. Senha:";
                    dgvUsers.DataSource = dt;
                }
            }
        }
        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId1.Text             = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtNomeCliente.Text     = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            MskCnpjClient.Text      = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTelefoneCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmailCliente.Text    = dgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            BtnSaveClient.Enabled   = false;
        }

        private void BtnSaveClient_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (TxtNomeCliente.Text == "" || MskCnpjClient.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Verifica se os campos nome do cliente e CNPJ são números
            else if (int.TryParse(TxtNomeCliente.Text, out _) == true || float.TryParse(TxtNomeCliente.Text, out _) == true)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conexaoMYSQL.Open();
                try
                {
                    // Remover os caracteres não numéricos do MaskedTextBox
                    string numeros = new string(MskCnpjClient.Text.Where(char.IsDigit).ToArray());

                    // Cria um novo comando MySqlCommand para inserir os dados na tabela cliente
                    MySqlCommand comando = new MySqlCommand("INSERT INTO cliente (nome_cliente, cnpj, telefone_cliente, email_cliente) VALUES ('" + TxtNomeCliente.Text + "','" + numeros + "','" + txtTelefoneCliente.Text + "','" + txtEmailCliente.Text + "');", conexaoMYSQL);

                    // Executa o comando de inserção
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    txtId1.Text = "";
                    TxtNomeCliente.Text = "";
                    MskCnpjClient.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";

                    // Chama o método que carrega as informações dentro do dgvClientes
                    LoadTableClient();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                    conexaoMYSQL.Close();
                }
            }
        }

        private void BtnEditClient_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (TxtNomeCliente.Text == "" || MskCnpjClient.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
            {
                MessageBox.Show("Selecione um cliente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conexaoMYSQL.Open();

                try
                {
                    // Remover os caracteres não numéricos do MaskedTextBox
                    string numeros = new string(MskCnpjClient.Text.Where(char.IsDigit).ToArray());

                    // Cria um novo comando MySqlCommand para alterar os dados na tabela cliente
                    MySqlCommand comando = new MySqlCommand("UPDATE cliente SET nome_cliente='" + TxtNomeCliente.Text + "',cnpj='" + numeros + "',telefone_cliente='" + txtTelefoneCliente.Text + "',email_cliente='" + txtEmailCliente.Text + "' where id_cliente=" + txtId1.Text, conexaoMYSQL);

                    // Executa o comando de alteração
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    txtId1.Text = "";
                    TxtNomeCliente.Text = "";
                    MskCnpjClient.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";
                    BtnSaveClient.Enabled = true;

                    // Chama o Método que irá carregar as informações dentro do dgvClientes
                    LoadTableClient();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                    conexaoMYSQL.Close(); 
                }
            }
        }

        private void BtnDelClient_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse cliente?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (TxtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
                {
                    MessageBox.Show("Selecione um cliente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                    // Abre a conexão com o banco de dados
                    conexaoMYSQL.Open();

                    try
                    {
                        // Cria um novo comando MySqlCommand para deletar os dados na tabela cliente
                        MySqlCommand comando = new MySqlCommand("DELETE FROM cliente  WHERE id_cliente=" + txtId1.Text + ";", conexaoMYSQL);

                        // Executa o comando de delete
                        comando.ExecuteNonQuery();

                        // Exibe uma mensagem de sucesso
                        MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);

                        // Limpa os campos de entrada de dados
                        txtId1.Text = "";
                        TxtNomeCliente.Text = "";
                        MskCnpjClient.Text = "";
                        txtTelefoneCliente.Text = "";
                        txtEmailCliente.Text = "";
                        BtnSaveClient.Enabled = true;

                        // Chama o Método que irá carregar as informações dentro do dgvClientes
                        LoadTableClient();
                    }
                    catch (Exception ex)
                    {
                        // Exibe uma mensagem de erro caso ocorra uma exceção
                        MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    }
                    finally
                    {
                        // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                        conexaoMYSQL.Close();
                    }
                }
            }
        }

        private void BtnClearClient_Click(object sender, EventArgs e)
        {
            txtId1.Text = "";
            TxtNomeCliente.Text = "";
            MskCnpjClient.Text = "";
            txtTelefoneCliente.Text = "";
            txtEmailCliente.Text = "";
            BtnSaveClient.Enabled = true;
        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtIdProd.Text          = dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtCodProd.Text         = dgvProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtNomeProd.Text        = dgvProdutos.Rows[e.RowIndex].Cells[2].Value.ToString();
            BtnSaveProd.Enabled = false;
        }

        // Função acionada quando o botão "BtnSaveProd" é clicado
        private void BtnSaveProd_Click(object sender, EventArgs e)
        {
            // Verifica se os campos de código e nome do produto estão vazios
            if (TxtCodProd.Text == "" || TxtNomeProd.Text == "")
            {
                // Se algum campo estiver vazio, exibe uma mensagem de aviso
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Verifica se o código do produto já está na tabela
                if (ValorJaInserido(TxtCodProd.Text))
                {
                    // Se o código já estiver na tabela, exibe uma mensagem de aviso
                    MessageBox.Show("Este código de produto já foi inserido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Sai da função para evitar a inserção duplicada
                }

                // Conexão com o banco de dados MySQL
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open(); // Abre a conexão

                try
                {
                    // Cria um comando SQL para inserir dados na tabela 'produto'
                    MySqlCommand comando = new MySqlCommand("INSERT INTO produto(cod_produto, nome_produto) VALUES('" + TxtCodProd.Text + "','" + TxtNomeProd.Text + "');", conexaoMYSQL);
                    comando.ExecuteNonQuery(); // Executa o comando SQL para inserção de dados

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados criados!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de texto
                    TxtIdProd.Text = "";
                    TxtCodProd.Text = "";
                    TxtNomeProd.Text = "";

                    // Atualiza a tabela de produtos na interface
                    LoadTableProd();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução do código
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    // Garante que a conexão com o banco de dados seja fechada, independentemente de ocorrerem exceções ou não
                    conexaoMYSQL.Close();
                }
            }
        }

        private void BtnEditProd_Click(object sender, EventArgs e)
        {
            if (TxtNomeProd.Text == "")
            {
                MessageBox.Show("Selecione um produto existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                try
                {
                    MySqlCommand comando = new MySqlCommand("UPDATE produto SET cod_produto='"+ TxtCodProd.Text + "',nome_produto='" + TxtNomeProd.Text + "' WHERE id_produto=" + TxtIdProd.Text, conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);
                    TxtIdProd.Text = "";
                    TxtCodProd.Text = "";
                    TxtNomeProd.Text = "";
                    LoadTableProd();
                    BtnSaveProd.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    conexaoMYSQL.Close();
                }
            }
        }

        private void BtnDelProd_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse produto?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (TxtNomeProd.Text == "")
                {
                    MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    try
                    {
                        MySqlCommand comando = new MySqlCommand("DELETE FROM produto WHERE id_produto=" + TxtIdProd.Text + ";", conexaoMYSQL);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Dados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK);
                        TxtIdProd.Text = "";
                        TxtCodProd.Text = "";
                        TxtNomeProd.Text = "";
                        LoadTableProd();
                        BtnSaveProd.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    }
                    finally
                    {
                        conexaoMYSQL.Close();
                    }
                }
            }
        }

        private void BtnClearProd_Click(object sender, EventArgs e)
        {
            TxtIdProd.Text = "";
            TxtCodProd.Text = "";
            TxtNomeProd.Text = "";
            BtnSaveProd.Enabled = true;
        }

        private void dgvComponentes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtIdComp.Text = dgvComponentes.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtNomeComp.Text = dgvComponentes.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSaveComp_Click(object sender, EventArgs e)
        {
            if (TxtNomeComp.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conexaoMYSQL.Open();
                try
                {
                    // Cria um novo comando MySqlCommand para inserir os dados na tabela componete
                    MySqlCommand comando = new MySqlCommand("INSERT INTO componente(nome_comp)VALUES('" + TxtNomeComp.Text + "');", conexaoMYSQL);

                    // Executa o comando de inserir os dados
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados criados!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    TxtIdComp.Text = "";
                    TxtNomeComp.Text = "";
                    TxtNomeComp.Select();

                    // Chama o Método que irá carregar as informações dentro do dgvComponentes
                    LoadTableComp();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                    conexaoMYSQL.Close();
                }
            }
        }

        private void BtnEditComp_Click(object sender, EventArgs e)
        {
            if (TxtNomeComp.Text == "")
            {
                MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conexaoMYSQL.Open();
                try
                {
                    // Cria um novo comando MySqlCommand para Editar os dados na tabela componete
                    MySqlCommand comando = new MySqlCommand("UPDATE componente SET nome_comp='" + TxtNomeComp.Text + "' WHERE id_componente=" + TxtIdComp.Text, conexaoMYSQL);
                    
                    // Executa o comando de inserir os dados
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    TxtIdComp.Text = "";
                    TxtNomeComp.Text = "";
                    TxtNomeComp.Select();

                    // Chama o Método que irá carregar as informações dentro do dgvComponentes
                    LoadTableComp();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                    conexaoMYSQL.Close();
                }
            }
        }

        private void BtnDelComp_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse componente?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (TxtNomeComp.Text == "")
                {
                    MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                    // Abre a conexão com o banco de dados
                    conexaoMYSQL.Open();
                    try
                    {
                        // Cria um novo comando MySqlCommand para deletar os dados na tabela componete
                        MySqlCommand comando = new MySqlCommand("DELETE FROM componente WHERE id_componente=" + TxtIdComp.Text + ";", conexaoMYSQL);

                        // Executa o comando de inserir os dados
                        comando.ExecuteNonQuery();

                        // Exibe uma mensagem de sucesso
                        MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);

                        // Limpa os campos de entrada de dados
                        TxtIdComp.Text = "";
                        TxtNomeComp.Text = "";
                        TxtNomeComp.Select();

                        // Chama o Método que irá carregar as informações dentro do dgvComponentes
                        LoadTableComp();
                    }
                    catch (Exception ex)
                    {
                        // Exibe uma mensagem de erro caso ocorra uma exceção
                        MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    }
                    finally
                    {
                        // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                        conexaoMYSQL.Close();
                    }
                }
            }
        }

        private void BtnClearComp_Click(object sender, EventArgs e)
        {
            TxtIdComp.Text = "";
            TxtNomeComp.Text = "";
            TxtNomeComp.Select(); 
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrar1_Click(object sender, EventArgs e)
        {
            if (TxtPass.PasswordChar == '*')
            {
                TxtPass.PasswordChar = default;
                btnMostrar1.Text = "Ocultar";
            }
            else
            {
                TxtPass.PasswordChar = '*';
                btnMostrar1.Text = "Mostrar";
            }
        }

        private void btnMostrar2_Click(object sender, EventArgs e)
        {
            if (TxtConfPass.PasswordChar == '*')
            {
                TxtConfPass.PasswordChar = default;
                btnMostrar2.Text = "Ocultar";
            }
            else
            {
                TxtConfPass.PasswordChar = '*';
                btnMostrar2.Text = "Mostrar";
            }
        }

        private void TxtPescCPF_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conexao1 = new MySqlConnection(Program.conexaoBD);

            // Construa a consulta SQL dinâmica com base no texto no TextBox
            string filtro = TxtPescCPF.Text;
            string query = "SELECT * FROM usuario WHERE cpf_usuario LIKE @filtro";

            // Abra a conexão com o banco de dados
            conexao1.Open();

            // Prepare o comando SQL
            MySqlCommand comando = new MySqlCommand(query, conexao1);
            comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

            // Crie um adaptador de dados e um DataTable para armazenar os resultados
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();

            // Preencha o DataTable com os resultados da consulta
            adapter.Fill(dt);

            // Feche a conexão com o banco de dados
            conexao1.Close();

            // Atualize o DataSource do DataGridView com os resultados filtrados
            dgvUsers.DataSource = dt;
        }

        private void TxtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            // Desabilita o evento TextChanged para evitar recursão infinita
            TxtNomeCliente.TextChanged -= TxtNomeCliente_TextChanged;

            // Converte o texto para maiúsculas
            TxtNomeCliente.Text = TxtNomeCliente.Text.ToUpper();

            // Reabilita o evento TextChanged
            TxtNomeCliente.TextChanged += TxtNomeCliente_TextChanged;

            // Define a posição do cursor no final do texto
            TxtNomeCliente.SelectionStart = TxtNomeCliente.Text.Length;
        }

        private void MskPesqCnpj_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection(Program.conexaoBD);

            // Remover os caracteres não numéricos do MaskedTextBox
            string numeros = new string(MskCnpjClient.Text.Where(char.IsDigit).ToArray());

            // Construa a consulta SQL dinâmica com base no texto no TextBox
            string filtro = MskPesqCnpj.Text;
            string query = "SELECT * FROM cliente WHERE cnpj LIKE @filtro";

            // Abra a conexão com o banco de dados
            conexao.Open();

            // Prepare o comando SQL
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

            // Crie um adaptador de dados e um DataTable para armazenar os resultados
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();

            // Preencha o DataTable com os resultados da consulta
            adapter.Fill(dt);

            // Feche a conexão com o banco de dados
            conexao.Close();

            // Renomear as colunas conforme necessário
            dt.Columns["id_cliente"].ColumnName = "Id:";
            dt.Columns["nome_cliente"].ColumnName = "Nome:";
            dt.Columns["cnpj"].ColumnName = "CNPJ:";
            dt.Columns["telefone_cliente"].ColumnName = "Telefone:";
            dt.Columns["email_cliente"].ColumnName = "Email";

            dgvClientes.DataSource = dt;
        }
        private void dgvDefeito_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdDefeito.Text       = dgvDefeito.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDefeito.Text         = dgvDefeito.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnSaveDefeito.Enabled  = false;
        }

        private void btnSaveDefeito_Click(object sender, EventArgs e)
        {
            // Verifica se os campos de código e nome do produto estão vazios
            if (txtDefeito.Text == "")
            {
                // Se algum campo estiver vazio, exibe uma mensagem de aviso
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Conexão com o banco de dados MySQL
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open(); // Abre a conexão

                try
                {
                    // Cria um comando SQL para inserir dados na tabela 'defeito'
                    MySqlCommand comando = new MySqlCommand("INSERT INTO defeito(nome_defeito)VALUES('" + txtDefeito.Text + "');", conexaoMYSQL);

                    // Executa o comando SQL para inserção de dados
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados criados com Sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de texto
                    txtIdDefeito.Text = "";
                    txtDefeito.Text = "";


                    // Atualiza a tabela de produtos na interface
                    LoadTableDefeito();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução do código
                    MessageBox.Show("Erro ao salvar dados dados: " + ex.Message);
                }
                finally
                {
                    // Garante que a conexão com o banco de dados seja fechada, independentemente de ocorrerem exceções ou não
                    conexaoMYSQL.Close();
                }
            }
        }
        private void btnEditDefeito_Click(object sender, EventArgs e)
        {
            if (txtDefeito.Text == "")
            {
                MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conexaoMYSQL.Open();
                try
                {
                    // Cria um novo comando MySqlCommand para Editar os dados na tabela defeito
                    MySqlCommand comando = new MySqlCommand("UPDATE defeito SET nome_defeito='" + txtDefeito.Text + "' WHERE id =" + txtIdDefeito.Text, conexaoMYSQL);

                    // Executa o comando de inserir os dados
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    txtIdDefeito.Text = "";
                    txtDefeito.Text = "";
                    txtDefeito.Select();
                    btnSaveDefeito.Enabled = true;

                    // Chama o Método que irá carregar as informações dentro do dgvComponentes
                    LoadTableDefeito();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show("Erro ao atualizar dados: " + ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                    conexaoMYSQL.Close();
                }
            }
        }
        private void btnDelDefeito_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse componente?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (txtDefeito.Text == "")
                {
                    MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

                    // Abre a conexão com o banco de dados
                    conexaoMYSQL.Open();
                    try
                    {
                        // Cria um novo comando MySqlCommand para deletar os dados na tabela componete
                        MySqlCommand comando = new MySqlCommand("DELETE FROM defeito WHERE id=" + txtIdDefeito.Text + ";", conexaoMYSQL);

                        // Executa o comando de inserir os dados
                        comando.ExecuteNonQuery();

                        // Exibe uma mensagem de sucesso
                        MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);

                        // Limpa os campos de entrada de dados
                        txtIdDefeito.Text = "";
                        txtDefeito.Text = "";
                        txtDefeito.Select();
                        btnSaveDefeito.Enabled = true;

                        // Chama o Método que irá carregar as informações dentro do dgvComponentes
                        LoadTableDefeito();
                    }
                    catch (Exception ex)
                    {
                        // Exibe uma mensagem de erro caso ocorra uma exceção
                        MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    }
                    finally
                    {
                        // Fecha a conexão com o banco de dados, independentemente de ocorrer uma exceção ou não
                        conexaoMYSQL.Close();
                    }
                }
            }
        }
        private void btnClearDefeito_Click(object sender, EventArgs e)
        {
            txtIdDefeito.Text = "";
            txtDefeito.Text = "";
            txtDefeito.Select();
            btnSaveDefeito.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}



