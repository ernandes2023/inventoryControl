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
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace inventoryControl
{
    public partial class Cadastro : Form
    {
        MySqlConnection conexao1 = new MySqlConnection(Program.conexaoBD);
        DataTable tabela1 = new DataTable();

        public Cadastro()
        {
            InitializeComponent();
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;// referente ao codigo na linha 138 formatação das colunas "senha e conf senha" no dgvUsers
        }

        private void CarregarDadosBanco()
        {
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
            conexaoMYSQL.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select id_prod as id_do_produto,nome_prod as nome_do_produto,cliente_id as id_do_cliente,id_cliente as id_do_cliente,nome_cliente as nome_do_cliente from produto right join cliente on cliente_id = id_cliente", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvProdutos.DataSource = dt;
        }

        private void LoadTableClient() // Metodo privado que carrega dados da tabela Cliente.
        {

            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from cliente", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dgvClientes.DataSource = dt;
        }

        private void CarregarDadosBanco3()
        {
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
            conexaoMYSQL.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from componente", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvComponentes.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Cadastro_Load_1(object sender, EventArgs e)
        {
            /* Inicialização da tela de cadastro */

            txtId.Enabled = false;
            txtId1.Enabled = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            /* Fim da inicialização tela Cadastro */
            try
            {
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    conexaoMYSQL.Open();
                    string query = "SELECT * FROM usuario";
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
            txtId.Text = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCPF.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCargo.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUser.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPass.Text = dgvUsers.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtConfPass.Text = dgvUsers.Rows[e.RowIndex].Cells[6].Value.ToString();
            BtnSalvar.Enabled = false;
        }


        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCPF.Text = "";
            txtCargo.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtConfPass.Text = "";
            BtnSalvar.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse usuário?", "Aviso", MessageBoxButtons.YesNo);

                if (caixaMensagem == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
                        conectar.Open();

                        MySqlCommand cadastrar = new MySqlCommand("DELETE FROM usuario WHERE id_usuario = " + txtId.Text, conectar);
                        cadastrar.ExecuteNonQuery();

                        MessageBox.Show("Dados excluidos com sucesso!");
                        txtId.Text = "";
                        txtName.Text = "";
                        txtCPF.Text = "";
                        txtCargo.Text = "";
                        txtUser.Text = "";
                        txtPass.Text = "";
                        txtConfPass.Text = "";

                        conectar.Close();

                        using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                        {
                            conexaoMYSQL.Open();

                            string query = "SELECT * FROM usuario";

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

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            conectar.Open();

            MySqlCommand cadastrar = new MySqlCommand("update usuario set nome_usuario='" + txtName.Text + "', cpf_usuario='" + txtCPF.Text +
                "', cargo='" + txtCargo.Text + "', login='" + txtUser.Text + "', senha='" + txtPass.Text + "', confirm_senha='" + txtConfPass.Text +
                "' WHERE id_usuario=" + txtId.Text, conectar);
            cadastrar.ExecuteNonQuery();


            MessageBox.Show("Dados alterados!!!");
            txtId.Text = "";
            txtName.Text = "";
            txtCPF.Text = "";
            txtCargo.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtConfPass.Text = "";
            BtnSalvar.Enabled = true;

            using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
            {
                conexaoMYSQL.Open();

                string query = "SELECT * FROM usuario";

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


        /* Codigo abaixo realiza o Cadastro do Usuário */
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (txtName.Text == "" || txtCPF.Text == "" || txtCargo.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtConfPass.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Select(); // Coloca o foco no campo de nome caso esteja vazio
            }
            //Verifica se as senhas digitadas são iguais
            else if (txtPass.Text != txtConfPass.Text)
            {
                MessageBox.Show("As Senhas digitadas São diferentes! \n Por Favor digite a senha novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Text = "";
                txtConfPass.Text = "";
                txtPass.Select(); // Coloca o foco no campo de senha caso as senhas sejam diferentes
            }
            else
            {
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conectar.Open();
                try
                {
                    // Cria um novo comando MySqlCommand para inserir os dados na tabela usuario
                    MySqlCommand cadastrar = new MySqlCommand("INSERT INTO usuario (nome_usuario, cpf_usuario, cargo, login, senha, confirm_senha) values ('" + txtName.Text + "','" + txtCPF.Text + "','" + txtCargo.Text + "','" + txtUser.Text + "','" + txtPass.Text + "','" + txtConfPass.Text + "');", conectar);

                    // Executa o comando de inserção
                    cadastrar.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    txtName.Text = "";
                    txtCPF.Text = "";
                    txtCargo.Text = "";
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtConfPass.Text = "";
                    txtName.Select(); // Coloca o foco no campo de nome
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro não foi possivel Salvar informações: " + ex.Message);
                }
                finally
                {
                    conectar.Close();
                }

                // Carrega os dados da tabela usuario no DataGridView dgvUsers
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    conexaoMYSQL.Open();

                    string query = "SELECT * FROM usuario";

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

        /* Fim do Código de cadastro de Usuario */

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId1.Text = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTelefoneCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmailCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPass.Text = dgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnSaveClient_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (txtNomeCliente.Text == "" || TxtCnpjClient.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Verifica se os campos nome do cliente e CNPJ são números
            else if (int.TryParse(txtNomeCliente.Text, out _) == true || float.TryParse(txtNomeCliente.Text, out _) == true)
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
                    // Cria um novo comando MySqlCommand para inserir os dados na tabela cliente
                    MySqlCommand comando = new MySqlCommand("INSERT INTO cliente (nome_cliente, cnpj, telefone_cliente, email_cliente) VALUES ('" + txtNomeCliente.Text + "','" + TxtCnpjClient.Text + "','" + txtTelefoneCliente.Text + "','" + txtEmailCliente.Text + "');", conexaoMYSQL);

                    // Executa o comando de inserção
                    comando.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    txtId1.Text = "";
                    txtNomeCliente.Text = "";
                    TxtCnpjClient.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";
                    txtPass.Text = "";

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

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
            {
                MessageBox.Show("Selecione um cliente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("update cliente set nome_cliente='" + txtNomeCliente.Text + "',telefone_cliente='" + txtTelefoneCliente.Text + "',email_cliente='" + txtEmailCliente.Text + "' where id_cliente=" + txtId1.Text, conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);
                    txtId1.Text = "";
                    txtNomeCliente.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";
                    txtPass.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
                catch (Exception)
                {
                    MessageBox.Show("Você não pode criar um produto com o botão Editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnExcluir1_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse cliente?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (txtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "")
                {
                    MessageBox.Show("Selecione um cliente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("delete from cliente where id_cliente=" + txtId1.Text + ";", conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);
                    txtId1.Text = "";
                    txtNomeCliente.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";
                    txtPass.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
            }
        }

        private void btnSair1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId2.Text = dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeProduto.Text = dgvProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtIdCliente1.Text = dgvProdutos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtIdCliente2.Text = dgvProdutos.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSalvar2_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text == "" || txtIdCliente1.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtIdCliente1.Text, out _) == false)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("insert into produto(nome_prod,cliente_id)values('" + txtNomeProduto.Text + "'," + txtIdCliente1.Text + ");", conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados criados!", "Sucesso", MessageBoxButtons.OK);
                    txtId2.Text = "";
                    txtNomeProduto.Text = "";
                    txtIdCliente1.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
                catch (Exception)
                {
                    MessageBox.Show("Você não pode adicionar um produto sem antes adicionar o cliente a quem ele pertence! / O primeiro campo id do cliente deve ser igual ao segundo campo id do cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text == "" || txtIdCliente1.Text == "")
            {
                MessageBox.Show("Selecione um produto existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtIdCliente1.Text, out _) == false)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("update produto set nome_prod='" + txtNomeProduto.Text + "', cliente_id=" + txtIdCliente1.Text + " where id_prod=" + txtId2.Text, conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);
                    txtId2.Text = "";
                    txtNomeProduto.Text = "";
                    txtIdCliente1.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
                catch (Exception)
                {
                    MessageBox.Show("O primeiro campo id do cliente deve ser igual ao segundo campo id do cliente! / Você não pode criar um produto com o botão Editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExcluir2_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse produto?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (txtNomeProduto.Text == "" || txtIdCliente1.Text == "")
                {
                    MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("delete from produto where id_prod=" + txtId2.Text + ";", conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);
                    txtId2.Text = "";
                    txtNomeProduto.Text = "";
                    txtIdCliente1.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
            }
        }

        private void btnSair2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dgvComponentes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId3.Text = dgvComponentes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeComponente.Text = dgvComponentes.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSalvar3_Click(object sender, EventArgs e)
        {
            if (txtNomeComponente.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into componente(nome_comp)values('" + txtNomeComponente.Text + "');", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados criados!", "Sucesso", MessageBoxButtons.OK);
                txtId3.Text = "";
                txtNomeComponente.Text = "";
                CarregarDadosBanco();
                LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                CarregarDadosBanco3();
            }
        }

        private void btnEditar3_Click(object sender, EventArgs e)
        {
            if (txtNomeComponente.Text == "")
            {
                MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("update componente set nome_comp='" + txtNomeComponente.Text + "' where id_comp=" + txtId3.Text, conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);
                    txtId3.Text = "";
                    txtNomeComponente.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
                catch (Exception)
                {
                    MessageBox.Show("Você não pode criar um produto com o botão Editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExcluir3_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse componente?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                if (txtNomeComponente.Text == "")
                {
                    MessageBox.Show("Selecione um componente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("delete from componente where id_comp=" + txtId3.Text + ";", conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados excluídos!", "Sucesso", MessageBoxButtons.OK);
                    txtId3.Text = "";
                    txtNomeComponente.Text = "";
                    CarregarDadosBanco();
                    LoadTableClient(); // chama o Método que irá carregar as informações dentro do dgvClientes
                    CarregarDadosBanco3();
                }
            }
        }

        private void btnSair3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrar1_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                txtPass.PasswordChar = default;
                btnMostrar1.Text = "Ocultar";
            }
            else
            {
                txtPass.PasswordChar = '*';
                btnMostrar1.Text = "Mostrar";
            }
        }

        private void btnMostrar2_Click(object sender, EventArgs e)
        {
            if (txtConfPass.PasswordChar == '*')
            {
                txtConfPass.PasswordChar = default;
                btnMostrar2.Text = "Ocultar";
            }
            else
            {
                txtConfPass.PasswordChar = '*';
                btnMostrar2.Text = "Mostrar";
            }
        }

        private void txtPescCPF_TextChanged(object sender, EventArgs e)
        {
            // Construa a consulta SQL dinâmica com base no texto no TextBox
            string filtro = txtPescCPF.Text;
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
    }
}



