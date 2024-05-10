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
    public partial class cadastrarGrm : Form
    {
        public cadastrarGrm()
        {
            InitializeComponent();
            carregDadosGrm();
            carregCombobox1();
        }

        private void carregDadosGrm()
        {
            // Definindo a consulta SQL
            string query = "Select * from produto";

            // Usando uma declaração 'using' para garantir que a conexão seja fechada corretamente
            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                // Criando um comando MySQL com a consulta e a conexão
                MySqlCommand comando = new MySqlCommand(query, connection);

                // Abrindo a conexão com o banco de dados
                connection.Open();

                // Executando a consulta e obtendo um leitor de dados
                MySqlDataReader reader = comando.ExecuteReader();

                // Looping através de cada linha retornada pela consulta
                while (reader.Read())
                {
                    // Adicionando o nome do produto ao componente 'moduloText'
                    moduloText.Items.Add(reader["nome_produto"].ToString());

                    // Definindo o 'ValueMember' do componente 'moduloText' com o ID do produto
                    moduloText.ValueMember = reader["id_produto"].ToString();
                }

                // Fechando o leitor de dados após o término do loop
                reader.Close();
            }
        }


        private void carregCombobox1()
        {

            // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
            MySqlConnection conexaoMYSQL = new MySqlConnection(Program.conexaoBD);

            // Abre a conexão com o banco de dados
            conexaoMYSQL.Open();

            // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter("select grm.numero_grm, produto.nome_produto, grm_oper.qtd, grm_oper.reparado from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm ORDER BY grm.numero_grm  DESC; ", conexaoMYSQL);

            // Cria um novo DataTable para armazenar os dados retornados pela consulta
            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            // Renomear as colunas conforme necessário
            dt.Columns["numero_grm"].ColumnName = "GRM:";
            dt.Columns["nome_produto"].ColumnName = "Módulo:";
            dt.Columns["qtd"].ColumnName = "QTD:";


            // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
            dataGridView1.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conexaoMYSQL.Close();

            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void cadastrarGrm_Load(object sender, EventArgs e)
        {

        }

        private void grmText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void moduloText_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void qtdText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios estão preenchidos
            if (grmText.Text == "" || moduloText.Text == "" || qtdText.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
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
                    MySqlCommand cadastrar = new MySqlCommand("INSERT INTO grm (numero_grm) values ('" + grmText.Text + "');", conectar);

                      
                        string valorIdString = ""; // Declare a variável fora do loop com um valor padrão inicial

                        string query = "SELECT id_grm FROM grm ORDER BY id_grm DESC LIMIT 1;";                
                        MySqlCommand comando = new MySqlCommand(query, conectar);
                        MySqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {                            
                            valorIdString = reader["id_grm"].ToString(); // Atribua o valor dentro do loop
                        }

                        reader.Close();

                        // Agora você pode usar valorIdString fora do loop
                        int valorId = int.Parse(valorIdString) + 1;

                        string id_mod = "";
                        string query2 = "SELECT id_produto FROM produto WHERE nome_produto = @nome_produto";
                        MySqlCommand comando2 = new MySqlCommand(query2, conectar);
                        comando2.Parameters.AddWithValue("@nome_produto", moduloText.Text);

                        // Use comando2 para criar o MySqlDataReader
                        MySqlDataReader reader2 = comando2.ExecuteReader();
                        while (reader2.Read())
                        {
                            id_mod = reader2["id_produto"].ToString(); // Atribua o valor dentro do loop
                        }
                        reader2.Close(); // Feche o reader após utilizá-lo

                        // Agora você pode fazer o parse de id_mod fora do loop
                        int mod_id = int.Parse(id_mod);





                    MySqlCommand cadastrar2 = new MySqlCommand("INSERT INTO grm_oper (fk_grm, fk_prod, qtd, reparado) values ('" + valorId + "','" + mod_id + "','" + qtdText.Text + "', '0');", conectar);
                                                               // INSERT INTO `inventory`.`grm_oper` (`fk_grm`, `fk_prod`, `qtd`, `reparado`) VALUES('37', '4', '54', '0');
                    // Executa o comando de inserção
                    cadastrar.ExecuteNonQuery();

                    cadastrar2.ExecuteNonQuery();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);

                    // Limpa os campos de entrada de dados
                    //grmText.Text = "";
                    moduloText.Text = "";
                    qtdText.Text = "";
                    ; // Coloca o foco no campo de nome

                    // Cria um objeto MySqlDataAdapter para executar a consulta SQL e preencher o DataTable
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select grm.numero_grm, produto.nome_produto, grm_oper.qtd from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm ORDER BY grm.numero_grm  DESC; ", Program.conexaoBD);

                    DataTable dt = new DataTable();

                    // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
                    adapter.Fill(dt);

                    // Renomear as colunas conforme necessário
                    dt.Columns["numero_grm"].ColumnName = "GRM:";
                    dt.Columns["nome_produto"].ColumnName = "Módulo:";
                    dt.Columns["qtd"].ColumnName = "QTD:";


                    // Define o DataGridView dgvClientes como a fonte de dados para exibir os dados do DataTable
                    dataGridView1.DataSource = dt;

          
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro não foi possivel Salvar informações: " + ex.Message);
                }
                finally
                {
                    conectar.Close();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Operação op = new Operação();
            op.Show();
            this.Hide();
        }
    }
}
