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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();



        }
     

      

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void voltar_operacao_Click(object sender, EventArgs e)
        {
            Operação oper = new Operação();
            oper.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

      

            // Inicializar a conexão com o banco de dados
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            MySqlCommand comando = new MySqlCommand();

            // Correção na consulta SQL
            comando.CommandText = "SELECT id_operacao FROM operacao WHERE serial_number = @serial";
            comando.Parameters.AddWithValue("@serial", textBox1.Text);
            comando.Connection = conectar;

            try
            {
                // Abrir a conexão
                conectar.Open();

                // Executar o comando
                var resultado = comando.ExecuteScalar();

                // Verificar o resultado
                if (resultado != null)
                {
                    // Consulta SQL para buscar os detalhes do produto
                    string query = @"
            SELECT 
                nome_produto AS Modulo, 
                numero_grm AS GRM, 
                nome_defeito AS Defeito, 
                nome_comp AS Componente, 
                qtd_comp AS QTD, 
                nome_status AS State, 
                status_garantia AS Garantia,  
                data_operacao, 
                login AS Tecnico 
            FROM 
                operacao AS o 
                INNER JOIN usuario AS u ON o.fk_usuario = u.id_usuario 
                INNER JOIN produto AS p ON o.fk_prod = p.id_produto 
                INNER JOIN componente AS c ON o.componente = c.id_componente 
                INNER JOIN defeito AS d ON o.fk_def = d.id 
                INNER JOIN grm AS g ON o.fk_grm = g.id_grm 
                INNER JOIN garantia AS ga ON o.garantia = ga.id_garantia 
                INNER JOIN status_ AS s ON o.state = s.id_status 
            WHERE 
                serial_number = @serial_number;";

                    // Prepare o comando SQL
                    MySqlCommand comando2 = new MySqlCommand(query, conectar);
                    comando2.Parameters.AddWithValue("@serial_number", textBox1.Text);

                    // Crie um adaptador de dados e um DataTable para armazenar os resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando2);
                    DataTable dt = new DataTable();

                    // Preencha o DataTable com os resultados da consulta
                    adapter.Fill(dt);

                    // Atualize o DataSource do DataGridView com os resultados filtrados
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 70;
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[4].Width = 50;
                    dataGridView1.Columns[2].Width = 160;
                    dataGridView1.Columns[7].Width = 130;
                    dataGridView1.Columns[6].Width = 150;
                }
                else
                {
                    MessageBox.Show("Módulo não encontrado");
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, por exemplo, exibir uma mensagem de erro
                MessageBox.Show("Falha na pesquisa: " + ex.Message);
            }
            finally
            {
                // Fechar a conexão
                if (conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                }

            }

        }
    }
}
