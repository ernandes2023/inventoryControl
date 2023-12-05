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
    public partial class Cad_produtos : Form
    {
        public Cad_produtos()
        {
            InitializeComponent();
        }

        private void Cad_produtos_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }

        private void CarregarDadosBanco()
        {
            string conexao = "server=localhost;database=assistencia;uid=root;pwd=";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select id_prod as id_do_produto,nome_prod as nome_do_produto,cliente_id as id_do_cliente,id_cliente as id_do_cliente from produto right join cliente on cliente_id = id_cliente", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvProdutos.DataSource = dt;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dgvProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dgvProdutos.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos");
            }
            else if (int.TryParse(textBox3.Text, out _) == false)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!");
            }
            else
            {
                string conexao = "server=localhost;database=assistencia;uid=root;pwd=";
                MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into produto(nome_prod,cliente_id)values('" + textBox2 + "'," + textBox3 + ");", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados criados!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos");
            }
            else if (int.TryParse(textBox3.Text, out _) == false)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!");
            }
            else
            {
                string conexao = "server=localhost;database=assistencia;uid=root;pwd=";
                MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("update produto set nome_prod='" + textBox2.Text + "', cliente_id=" + textBox3.Text + " where id_prod=" + textBox1.Text, conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados alterados!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse produto?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                string conexao = "server=localhost;database=assistencia;uid=root;pwd=";
                MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("delete from produto where id_prod=" + textBox1.Text + ";", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados excluídos!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
