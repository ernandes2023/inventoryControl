﻿using System;
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
        private UserTecnico userTecnico;
        private Timer timer;

        public Operação()
        {
            operacoes = new List<Operacao>();
            componentes = new List<Componente>();
            userTecnico = new UserTecnico();

            InitializeComponent();
            carregDadoProd();
            carregDadosGrm();
            carregDadosGarantia();
            carregDadoComp();
            carregDadoDef();
            carregDadosStatus();
            carregDgv();

            
            tecnico.Text = Login.UltimoValorTextBox;
            operacao = new Operacao();

            timer = new Timer();
            timer.Interval = 1000; // Intervalo de 1 segundo (1000 milissegundos)
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Atualiza o texto da TextBox com a data e hora atual
            dataAtual.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }




        private void Operação_Load(object sender, EventArgs e)
        {
            DateTime Hoje = DateTime.Now;

            // Atribuir a data atual ao texto da TextBox
            dataAtual.Text = Hoje.ToString("yyyy-MM-dd HH:mm:ss");

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

                    grmNumero.ValueMember = reader["id_grm"].ToString();
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
           
        }
        private void carregDadoComp()
        {
            string query = "Select * from componente";

            componente.AutoCompleteMode = AutoCompleteMode.Suggest;
            componente.AutoCompleteSource = AutoCompleteSource.ListItems;


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
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[9].Width = 150;


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
            DateTime Hoje = DateTime.Now;

            // Atribuir a data atual ao texto da TextBox
            dataAtual.Text = Hoje.ToString("yyyy-MM-dd HH:mm:ss");

            operacao.dataAtual = Hoje;


        }

        private void grmNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string grmSelecionado = grmNumero.SelectedItem.ToString();

            operacao.grm = grmSelecionado;

            try
            {

                string query = "select produto.nome_produto from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm where id_grm in(select id_grm from grm where numero_grm = {0,10});";
                query = String.Format(query, operacao.grm);

                //string query = "select produto.nome_produto from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm where id_grm = " + operacao.grm + ";" ;

                using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
                {

                    MySqlCommand comando = new MySqlCommand(query, connection);
                    connection.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    produto.Items.Clear();

                    while (reader.Read())
                    {
                        produto.Items.Add(reader["nome_produto"].ToString()); // Est6á me ouvindo?

                    }
                    reader.Close();
                }
            }
            catch
            {
                // Lidar com exceções, por exemplo, exibir uma mensagem de erro
                MessageBox.Show("Falha ao executar a consulta no banco");
            }
        }

        private void produto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            // Captura o valor selecionado na ComboBox
            string produtoSelecionado = produto.SelectedItem.ToString();

            operacao.module = produtoSelecionado;

            string query = "select produto.nome_produto from  grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto  inner join grm  on grm_oper.fk_grm = grm.id_grm where  id_grm = '" + grmNumero.ValueMember + "';";

            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    // Adicionando o nome do produto ao componente 'moduloText'
                    produto.Items.Add(reader["nome_produto"].ToString());

                }
                reader.Close();
            }
        }

        private void addList_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.Rows.Add();

            dataGridView1.Rows[rowIndex].Cells[0].Value = operacao.grm;
            dataGridView1.Rows[rowIndex].Cells[1].Value = operacao.module;
            dataGridView1.Rows[rowIndex].Cells[2].Value = operacao.serialNumber;
            dataGridView1.Rows[rowIndex].Cells[3].Value = operacao.status;
            dataGridView1.Rows[rowIndex].Cells[4].Value = operacao.garantia;
            dataGridView1.Rows[rowIndex].Cells[5].Value = operacao.defeito;
            dataGridView1.Rows[rowIndex].Cells[6].Value = operacao.componente;
            dataGridView1.Rows[rowIndex].Cells[7].Value = operacao.gtdComp;
            dataGridView1.Rows[rowIndex].Cells[8].Value = userTecnico.tecnico;
            dataGridView1.Rows[rowIndex].Cells[9].Value = operacao.dataAtual;

            operacoes.Add(operacao);
            operacao = new Operacao();

            DateTime Hoje = DateTime.Now;

            // Atribuir a data atual ao texto da TextBox
            dataAtual.Text = Hoje.ToString("yyyy-MM-dd HH:mm:ss");

            operacao.dataAtual = Hoje;
        }

        private void componente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string componenteSelecionado = componente.SelectedItem.ToString();
            //obj.componente = componenteSelecionado;

            operacao.componente = componente.SelectedItem.ToString();
        }

        private void finalizar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar se a linha não é a linha de cabeçalho e está completa
                if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string query = "INSERT INTO `operacao` (fk_grm, fk_prod, serial_number, garantia, state, fk_def, fk_usuario, data_operacao, componente, qtd_comp) " +
                                   "VALUES (@grm, @module, @serialNumber, @garantia, @status, @defeito, @tecnico, @dataAtual, @componente, @gtdComp)";
                    
                    using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))

                    {
                        // Parâmetros
                        command.Parameters.AddWithValue("@grm", row.Cells[0].Value);
                        command.Parameters.AddWithValue("@module", row.Cells[1].Value);
                        command.Parameters.AddWithValue("@serialNumber", row.Cells[2].Value);
                        command.Parameters.AddWithValue("@status", row.Cells[3].Value);
                        command.Parameters.AddWithValue("@garantia", row.Cells[4].Value);
                        command.Parameters.AddWithValue("@defeito", row.Cells[5].Value);
                        command.Parameters.AddWithValue("@componente", row.Cells[6].Value);
                        command.Parameters.AddWithValue("@gtdComp", row.Cells[7].Value);
                        command.Parameters.AddWithValue("@tecnico", row.Cells[8].Value);
                        command.Parameters.AddWithValue("@dataAtual", row.Cells[9].Value);
                        connection.Open();
                        // Executar a query
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void serialNumber_TextChanged(object sender, EventArgs e)
        {
            string serial = serialNumber.Text.ToString();

            operacao.serialNumber = serial;
        }

        private void garantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gar = garantia.SelectedItem.ToString();

            operacao.garantia = gar;
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = status.SelectedItem.ToString();

            operacao.status = state;
        }

        private void defeito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string def = defeito.SelectedItem.ToString();

            operacao.defeito = def;
        }

        private void gtdComp_TextChanged(object sender, EventArgs e)
        {
            string qtd = gtdComp.Text.ToString();

            operacao.gtdComp = qtd;
        }

        private void tecnico_TextChanged(object sender, EventArgs e)
        {
            string tec = tecnico.Text.ToString();

            userTecnico.tecnico = tec;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cadastrarGrm grm = new cadastrarGrm();
            grm.Show();
            this.Hide();
        }
    }
}
