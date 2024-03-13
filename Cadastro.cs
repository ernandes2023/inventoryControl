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
using Org.BouncyCastle.Bcpg.OpenPgp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace inventoryControl
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;// referente ao codigo na linha 513 formatação das colunas "senha e conf senha" no dgvUsers
        }

        private void Cad_produtos_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
            CarregarDadosBanco2();
            CarregarDadosBanco3();
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

        private void CarregarDadosBanco2()
        {
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
            conexaoMYSQL.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from cliente", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
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

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        /* Codigo abaixo realiza o Cadastro do Usuário */
        /*
         * 
         * 
         * 
         * 
         * 
         */

        private void button1_Click(object sender, EventArgs e)
        {
            /* Verifica se os campos estão vazios */
            if (txtName.Text == "" || txtCPF.Text == "" || txtCargo.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtConfPass.Text == "")
            {

                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Text = "";
                txtCPF.Text = "";
                txtCargo.Text = "";
                txtUser.Text = "";
                txtPass.Text = "";
                txtConfPass.Text = "";
                txtName.Select();

            }
            /* Valida se as Senhas digitadas são iguais na textbox */
            else if (txtPass.Text != txtConfPass.Text)
            {
                MessageBox.Show("As Senhas digitadas São diferente! \n Por Favor digite a senha novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Text = "";
                txtConfPass.Text = "";
                txtPass.Select();
            }
            else
            {
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
                conectar.Open();
                MySqlCommand cadastrar = new MySqlCommand("INSERT INTO users (name_user, cpf, office, login, pass, confirm_pass) values ('" + txtName.Text + "','" + txtCPF.Text + "','" + txtCargo.Text + "','" + txtUser.Text + "','" + txtPass.Text + "','" + txtConfPass.Text + "');", conectar);
                cadastrar.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);
                txtName.Text = "";
                txtCPF.Text = "";
                txtCargo.Text = "";
                txtUser.Text = "";
                txtPass.Text = "";
                txtConfPass.Text = "";
                txtName.Select();
            }

        }

        /* Fim do Código de cadastro de Usuario 
         *
         *
         *
         *
         *
         *
         *
         */


        private void btnOlho2_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId1.Text = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTelefoneCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmailCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPass.Text = dgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnSalvar1_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.TryParse(txtNomeCliente.Text, out _) == true || float.TryParse(txtNomeCliente.Text, out _) == true)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into cliente(nome_cliente,telefone_cliente,email_cliente,senha)values('" + txtNomeCliente.Text + "','" + txtTelefoneCliente.Text + "','" + txtEmailCliente.Text + "','" + txtPass.Text + "');", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados criados!", "Sucesso", MessageBoxButtons.OK);
                txtId1.Text = "";
                txtNomeCliente.Text = "";
                txtTelefoneCliente.Text = "";
                txtEmailCliente.Text = "";
                txtPass.Text = "";
                CarregarDadosBanco();
                CarregarDadosBanco2();
                CarregarDadosBanco3();
            }

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Selecione um cliente existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                    conexaoMYSQL.Open();
                    MySqlCommand comando = new MySqlCommand("update cliente set nome_cliente='" + txtNomeCliente.Text + "',telefone_cliente='" + txtTelefoneCliente.Text + "',email_cliente='" + txtEmailCliente.Text + "',senha='" + txtPass.Text + "' where id_cliente=" + txtId1.Text, conexaoMYSQL);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados alterados!", "Sucesso", MessageBoxButtons.OK);
                    txtId1.Text = "";
                    txtNomeCliente.Text = "";
                    txtTelefoneCliente.Text = "";
                    txtEmailCliente.Text = "";
                    txtPass.Text = "";
                    CarregarDadosBanco();
                    CarregarDadosBanco2();
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
                if (txtNomeCliente.Text == "" || txtTelefoneCliente.Text == "" || txtEmailCliente.Text == "" || txtPass.Text == "")
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
                    CarregarDadosBanco2();
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
                    CarregarDadosBanco2();
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
                    CarregarDadosBanco2();
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
                    CarregarDadosBanco2();
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
                CarregarDadosBanco2();
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
                    CarregarDadosBanco2();
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
                    CarregarDadosBanco2();
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

        private void Cadastro_Load_1(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD))
                {
                    conexaoMYSQL.Open();

                    string query = "SELECT * FROM users";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexaoMYSQL))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Renomear as colunas conforme necessário
                        dt.Columns["id_user"].ColumnName = "Id:";
                        dt.Columns["name_user"].ColumnName = "Nome:";
                        dt.Columns["cpf"].ColumnName = "CPF:";
                        dt.Columns["office"].ColumnName = "Cargo";
                        dt.Columns["login"].ColumnName = "Usuário";
                        dt.Columns["pass"].ColumnName = "Senha:";
                        dt.Columns["confirm_pass"].ColumnName = "Conf. Senha:";
                        dt.Columns["st_adm"].ColumnName = "Status Adm";

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
            // Verifica se a célula atual pertence à coluna de senhas (substitua "Senha:" pelo nome da sua coluna)
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




    }

}
