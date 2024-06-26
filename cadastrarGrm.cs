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
    public partial class cadastrarGrm : Form
    {
        public cadastrarGrm()
        {
            InitializeComponent();
            carregDadosGrm();
            carregCombobox1();
            moduloText.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void Teste1()
            {
            MySqlConnection conexao1 = new MySqlConnection(Program.conexaoBD);

            // Construa a consulta SQL dinâmica com base no texto no TextBox
            string filtro = grmText.Text;
            //string query = "SELECT * FROM grm WHERE numero_grm LIKE @filtro";
            string query = "select grm.numero_grm, produto.nome_produto, grm_oper.qtd, grm_oper.reparado from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm where numero_grm LIKE @filtro";

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
            dataGridView1.DataSource = dt;
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
                        MySqlCommand comando = new MySqlCommand();
                        //Comando SQL
                        comando.CommandText = "select * from grm where numero_grm = '" + grmText.Text + "'";
                        //  comando.CommandText = "select * from grm ";

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
          
                MySqlConnection conexao1 = new MySqlConnection(Program.conexaoBD);

                // Construa a consulta SQL dinâmica com base no texto no TextBox
                string filtro = grmText.Text;
                //string query = "SELECT * FROM grm WHERE numero_grm LIKE @filtro";
                string query = "select grm.numero_grm, produto.nome_produto, grm_oper.qtd, grm_oper.reparado from grm_oper inner join produto on grm_oper.fk_prod = produto.id_produto inner join grm on grm_oper.fk_grm = grm.id_grm where numero_grm LIKE @filtro";

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
                dataGridView1.DataSource = dt;
            
        }

        private void moduloText_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void qtdText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
            {
            if (grmText.Text == ""|| moduloText.Text == ""|| qtdText.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else if (!int.TryParse(grmText.Text, out int result)|| !int.TryParse(qtdText.Text, out int resul))
            {
                MessageBox.Show("Os campos GRM e Quantidade devem conter apenas números");
            }
            else
            {
                // Verifica se todos os campos obrigatórios estão preenchidos
                if (grmText.Text == "" || moduloText.Text == "" || qtdText.Text == "")
                {
                    MessageBox.Show("Todos os campos precisam ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                // Cria uma nova conexão MySqlConnection utilizando a string de conexão definida em Program.conexaoBD
                MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);

                // Abre a conexão com o banco de dados
                conectar.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    //Comando SQL
                    /* comando.CommandText = "select * from grm where numero_grm = '" + grmText.Text + "'";

                     comando.Connection = conectar;
                     //Executar Comando
                     var resultado = comando.ExecuteScalar();

                     */




                    comando.CommandText = "SELECT COUNT(*) FROM grm WHERE numero_grm = @grmText";
                    comando.Parameters.AddWithValue("@grmText", grmText.Text);
                    comando.Connection = conectar;

                    // Executar o comando
                    object resultado = comando.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        int count = Convert.ToInt32(resultado);
                        if (count > 0)
                        {
                            // Cria um novo comando MySqlCommand para inserir os dados na tabela usuario
                            // MySqlCommand cadastrar = new MySqlCommand("insert INTO grm (numero_grm) values ('" + grmText.Text + "');", conectar);


                            string valorIdString = ""; // Declare a variável fora do loop com um valor padrão inicial

                            string query = "SELECT id_grm FROM grm ORDER BY id_grm DESC LIMIT 1;";
                            MySqlCommand comando2 = new MySqlCommand(query, conectar);
                            MySqlDataReader reader = comando2.ExecuteReader();

                            while (reader.Read())
                            {
                                valorIdString = reader["id_grm"].ToString(); // Atribua o valor dentro do loop
                            }

                            reader.Close();

                            // Agora você pode usar valorIdString fora do loop
                            int valorId = int.Parse(valorIdString);

                            MySqlCommand cadastrar = new MySqlCommand("UPDATE grm SET numero_grm = '" + grmText.Text + "' where id_grm = " + valorId, conectar);




                            string id_mod = "";
                            string query2 = "SELECT id_produto FROM produto WHERE nome_produto = @nome_produto";
                            MySqlCommand comando3 = new MySqlCommand(query2, conectar);
                            comando3.Parameters.AddWithValue("@nome_produto", moduloText.Text);

                            // Use comando2 para criar o MySqlDataReader
                            MySqlDataReader reader2 = comando3.ExecuteReader();
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



                            Teste1();
                        }
                        else
                        {  // Cria um novo comando MySqlCommand para inserir os dados na tabela usuario
                            MySqlCommand cadastrar = new MySqlCommand("INSERT INTO grm (numero_grm) values ('" + grmText.Text + "');", conectar);

                            string valorIdString = ""; // Declare a variável fora do loop com um valor padrão inicial

                            string query = "SELECT id_grm FROM grm ORDER BY id_grm DESC LIMIT 1;";
                            MySqlCommand comando2 = new MySqlCommand(query, conectar);
                            MySqlDataReader reader = comando2.ExecuteReader();

                            while (reader.Read())
                            {
                                valorIdString = reader["id_grm"].ToString(); // Atribua o valor dentro do loop
                            }

                            reader.Close();

                            // Agora você pode usar valorIdString fora do loop

                            int valorId = int.Parse(valorIdString) + 1;



                            string id_mod = "";
                            string query2 = "SELECT id_produto FROM produto WHERE nome_produto = @nome_produto";
                            MySqlCommand comando3 = new MySqlCommand(query2, conectar);
                            comando3.Parameters.AddWithValue("@nome_produto", moduloText.Text);

                            // Use comando2 para criar o MySqlDataReader
                            MySqlDataReader reader2 = comando3.ExecuteReader();
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



                            Teste1();
                        }

                    }


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
