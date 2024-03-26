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
    public partial class Operação : Form
    {
        private Operacao operacao;
        private List<Operacao> operacoes;
        private List<Componente> componentes;

        public Operação()
        {
            operacoes = new List<Operacao>();
            componentes = new List<Componente>();

            InitializeComponent();
            carregDadoProd();
            carregDadosGrm();
            carregDadosGarantia();
            carregDadoComp();
            carregDadoDef();
            carregDadosStatus();
            carregDgv();

            operacao = new Operacao();
        }

        
        private void Operação_Load(object sender, EventArgs e)
        {
            DateTime Hoje = DateTime.Now;

            // Atribuir a data atual ao texto da TextBox
            dataAtual.Text = Hoje.ToString("yyyy-MM-dd");

          
        }
        private void carregDadosStatus()
        {
            string query = "Select * from status_";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    status.Items.Add(reader["nome_status"].ToString());
                }
                reader.Close();
            }
        }
        private void carregDadosGrm()
        {            
            string query = "Select * from grm";


            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    grmNumero.Items.Add(reader["numero_grm"].ToString());
                }
                reader.Close();
            }
        }
        private void carregDadosGarantia()
        {
            string query = "Select * from garantia";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    garantia.Items.Add(reader["status_garantia"].ToString());
                }
                reader.Close();
            }
        }
        private void carregDadoProd()
        {            
            string query = "Select * from produto";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    produto.Items.Add(reader["nome_produto"].ToString());
                }
                reader.Close();
            }
        }
        private void carregDadoComp()
        {
            string query = "Select * from componente";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Componente comp = new Componente(Convert.ToInt32(reader["id_componente"]), reader["nome_comp"].ToString());
                    componentes.Add(comp);

                    componente.Items.Add(comp.nome);
                }
                reader.Close();
            }
        }
        private void carregDadoDef()
        {
            string query = "Select * from defeito";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    defeito.Items.Add(reader["nome_defeito"].ToString());
                }
                reader.Close();
            }
        }
        private void carregDgv()
        {
            // Configurando as colunas manualmente
            dataGridView1.Columns.Add("Column1", "GRM");
            dataGridView1.Columns.Add("Column2", "Modulo");
            dataGridView1.Columns.Add("Column3", "Serial Number");
            dataGridView1.Columns.Add("Column4", "Status");
            dataGridView1.Columns.Add("Column5", "Garantia");
            dataGridView1.Columns.Add("Column6", "Defeito");
            dataGridView1.Columns.Add("Column7", "Componente");
            dataGridView1.Columns.Add("Column8", "QTD");            
            dataGridView1.Columns.Add("Column9", "Tecnico");
            dataGridView1.Columns.Add("Column10", "Data");
           
            
            // Populando a DataGridView com dados
            //dataGridView1.Rows.Add("João", 25, "São Paulo");
            //dataGridView1.Rows.Add("Maria", 30, "Rio de Janeiro");
            //dataGridView1.Rows.Add("Pedro", 28, "Belo Horizonte");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void GRM_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataAtual_TextChanged(object sender, EventArgs e)
        {
            // Captura o valor da TextBox
            
        }

        private void grmNumero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void produto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            // Captura o valor selecionado na ComboBox
            string produtoSelecionado = produto.SelectedItem.ToString();

            operacao.module = produtoSelecionado;
        }

        private void addList_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.Rows.Add();
            
            dataGridView1.Rows[rowIndex].Cells[1].Value = operacao.module;
            dataGridView1.Rows[rowIndex].Cells[6].Value = operacao.componente;
            dataGridView1.Rows[rowIndex].Cells[9].Value = DateTime.Now;

            operacoes.Add(operacao);
            operacao = new Operacao();
        }

        private void componente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string componenteSelecionado = componente.SelectedItem.ToString();
            //obj.componente = componenteSelecionado;

            operacao.componente = componente.SelectedItem.ToString();
        }

        private void finalizar_Click(object sender, EventArgs e)
        {

            /*foreach (Operacao op in operacoes) {

                
                
                MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("insert into tableta (modulo, componente, data) values(" + op.module.ToString() + op.componente + op.data + ")", conexaoMYSQL);
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("insert into tabela2 (modulo, componente, data) values(" + op.module.ToString() + op.componente + op.data + ")", conexaoMYSQL);
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("insert into tabela 3 (modulo, componente, data) values(" + op.module.ToString() + op.componente + op.data + ")", conexaoMYSQL);
                comando.ExecuteNonQuery();

            }*/
        }
    }
}
