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
    public partial class Cadastro2 : Form
    {
        public Cadastro2()
        {
            InitializeComponent();
        }

        private void Cad_produtos_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
            CarregarDadosBanco2();
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
            dataGridView1.DataSource = dt;
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
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into produto(nome_prod,cliente_id)values('" + textBox2.Text + "'," + textBox3.Text + ");", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados criados!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
                Refresh();
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
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("update produto set nome_prod='" + textBox2.Text + "', cliente_id=" + textBox3.Text + " where id_prod=" + textBox1.Text, conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados alterados!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
                Refresh();
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse produto?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("delete from produto where id_prod=" + textBox1.Text + ";", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados excluídos!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CarregarDadosBanco();
                Refresh();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos");
            }
            else if (int.TryParse(textBox5.Text, out _) == true || float.TryParse(textBox5.Text, out _) == true)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!");
            }
            else
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into cliente(nome_cliente)values('" + textBox5.Text + "');", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados criados!");
                textBox4.Text = "";
                textBox5.Text = "";
                CarregarDadosBanco2();
                Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos");
            }
            else if (int.TryParse(textBox3.Text, out _) == true || float.TryParse(textBox3.Text, out _) == true)
            {
                MessageBox.Show("Um ou mais campo estão incorretos!");
            }
            else
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("update cliente set nome_cliente='" + textBox2.Text + "' where id_cliente=" + textBox4.Text, conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados alterados!");
                textBox4.Text = "";
                textBox5.Text = "";
                CarregarDadosBanco2();
                Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja realmente exluir esse produto?", "Aviso", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("delete from cliente where id_cliente=" + textBox4.Text + ";", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados excluídos!");
                textBox4.Text = "";
                textBox5.Text = "";
                CarregarDadosBanco2();
                Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
