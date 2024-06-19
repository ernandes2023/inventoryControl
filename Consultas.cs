using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace inventoryControl
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
            carregar_manutencao();
            InitializeComboBox();
            carregDadosGrm();

        }
        private void InitializeComboBox()
        {
            TxtFiltroGrm.TextChanged += TxtFiltroGrm_SelectedIndexChanged;
        }

        private void carregDadosGrm()
        {



            string query = "Select * from grm";


            using (MySqlConnection connection = new MySqlConnection(Program.conexaoBD))
            {
                MySqlCommand comando = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    GrmProdutos grm = new GrmProdutos();
                    grm.nome = reader["numero_grm"].ToString();
                    //grm.id = Int32.Parse(reader["id_grm"].ToString());

                    TxtFiltroGrm.Items.Add(grm.nome);



                }

                reader.Close();
            }
        }


        private void carregar_manutencao()
        {

            //string query = "Select * from operacao";

            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            //MySqlCommand comando = new MySqlCommand(query, conectar);

            conectar.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(@"SELECT 
                    numero_grm as GRM,
                    nome_produto as Modulo,
                    serial_number as Série,
                    state as Lacre,
                    status_garantia Garantia,
                    nome_defeito as Defeito,
                    nome_comp as Componente,
                    qtd_comp as QTD,
                    login as Tecnico,
                    data_operacao as Data
                FROM
                    operacao AS o
                INNER JOIN
                    grm AS g ON o.fk_grm = g.id_grm
                INNER JOIN
                    produto AS p ON o.fk_prod = p.id_produto
                INNER JOIN
                    defeito AS d ON o.fk_def = d.id
                INNER JOIN
                    usuario AS u ON o.fk_usuario = u.id_usuario
                INNER JOIN
                    garantia AS ga ON o.garantia = ga.id_garantia
                INNER JOIN
                    componente AS c ON o.componente = c.id_componente
                ORDER BY
                    data_operacao DESC;", conectar);

            DataTable dt = new DataTable();

            // Preenche o DataTable com os dados retornados pela consulta SQL usando o MySqlDataAdapter
            adapter.Fill(dt);

            dataGridView3.DataSource = dt;

            // Fecha a conexão com o banco de dados
            conectar.Close();
         
            // Formata as colunas do DataGridView para o tanho auto ajustavel
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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

            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o campo serial number");
            }
            else if (!int.TryParse(textBox1.Text, out int result))
            {
                MessageBox.Show("Neste campo deve conter apenas números");
            }
            else
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

                        // Formata as colunas do DataGridView para o tanho auto ajustavel
                        dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Inicializar a conexão com o banco de dados
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            MySqlCommand comando = new MySqlCommand();

            // Correção na consulta SQL
            comando.CommandText = "SELECT id_grm FROM grm WHERE numero_grm = @grm";
            comando.Parameters.AddWithValue("@grm", textBox2.Text);
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
                        numero_grm as GRM, 
                        nome_produto as Modulo, 
                        qtd as QTD, 
                        reparado as Reparado
                    FROM 
                        grm_oper as go
                        inner join grm as g on go.fk_grm = g.id_grm
                        inner join produto as p on go.fk_prod = p.id_produto
                    where 
                        numero_grm = @numero_grm;";

                    // Prepare o comando SQL
                    MySqlCommand comando2 = new MySqlCommand(query, conectar);
                    comando2.Parameters.AddWithValue("@numero_grm", textBox2.Text);

                    // Crie um adaptador de dados e um DataTable para armazenar os resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando2);
                    DataTable dt = new DataTable();

                    // Preencha o DataTable com os resultados da consulta
                    adapter.Fill(dt);

                    // Atualize o DataSource do DataGridView com os resultados filtrados
                    dataGridView2.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("GRM não encontrada");
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

        private void exportXML_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridView3);
        }
        private void ExportDataGridViewToExcel(DataGridView dgv)
        {
            // Cria um novo pacote Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Adiciona uma nova planilha
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Adiciona os cabeçalhos
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgv.Columns[i - 1].HeaderText;
                }

                // Adiciona as linhas
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Salva o arquivo Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fi);
                    MessageBox.Show("Arquivo Excel gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exportPdf_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToPdf(dataGridView3);
        }
        private void ExportDataGridViewToPdf(DataGridView dgv)
        {
            // Configura o diálogo para salvar o arquivo PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save a PDF File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Cria um documento PDF em modo paisagem
                    Document pdfDoc = new Document(PageSize.A4.Rotate());
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // Adiciona um título ao documento
                    Paragraph title = new Paragraph("Exportação de DataGridView para PDF")
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    pdfDoc.Add(title);

                    // Cria uma tabela PDF
                    PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    // Adiciona os cabeçalhos da tabela
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Adiciona as linhas da tabela
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue; // Ignora a linha de novo registro

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString());
                        }
                    }

                    // Adiciona a tabela ao documento PDF
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("Arquivo PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtFiltroGrm_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }

        private void BtnPesquisarGrm_Click(object sender, EventArgs e)
        {
            // Inicializar a conexão com o banco de dados
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            MySqlCommand comando = new MySqlCommand();

            // Correção na consulta SQL
            comando.CommandText = "SELECT id_grm FROM grm WHERE numero_grm = @grm";
            comando.Parameters.AddWithValue("@grm", TxtFiltroGrm.Text);
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
                        numero_grm as GRM, 
                        nome_produto as Modulo, 
                        serial_number as Série,
                        state as Lacre, 
                        status_garantia as Garantia,
                        nome_defeito as Defeito,
                        nome_comp as Componente, 
                        qtd_comp as QTD, 
                        login as Técnico, 
                        data_operacao as Data
                    FROM 
                        operacao AS o
                    INNER JOIN 
                        grm AS g ON o.fk_grm = g.id_grm
                    INNER JOIN 
                        produto AS p ON o.fk_prod = p.id_produto
                    INNER JOIN 
                        defeito AS d ON o.fk_def = d.id
                    INNER JOIN 
                        usuario AS u ON o.fk_usuario = u.id_usuario
                    INNER JOIN 
                        garantia AS ga ON o.garantia = ga.id_garantia
                    INNER JOIN 
                        componente AS c ON o.componente = c.id_componente
                         where numero_grm = @numero_grm
                         ORDER BY 
                        data_operacao DESC;";

                    // Prepare o comando SQL
                    MySqlCommand comando2 = new MySqlCommand(query, conectar);
                    comando2.Parameters.AddWithValue("@numero_grm", TxtFiltroGrm.Text);

                    // Crie um adaptador de dados e um DataTable para armazenar os resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando2);
                    DataTable dt = new DataTable();

                    // Preencha o DataTable com os resultados da consulta
                    adapter.Fill(dt);

                    // Atualize o DataSource do DataGridView com os resultados filtrados
                    dataGridView3.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("GRM não encontrada");
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Inicializar a conexão com o banco de dados
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            MySqlCommand comando = new MySqlCommand();

            // Correção na consulta SQL
            comando.CommandText = "SELECT * FROM grm";
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
                        numero_grm as GRM, 
                        nome_produto as Modulo, 
                        serial_number as Série,
                        state as Lacre, 
                        status_garantia as Garantia,
                        nome_defeito as Defeito,
                        nome_comp as Componente, 
                        qtd_comp as QTD, 
                        login as Técnico, 
                        data_operacao as Data
                    FROM 
                        operacao AS o
                    INNER JOIN 
                        grm AS g ON o.fk_grm = g.id_grm
                    INNER JOIN 
                        produto AS p ON o.fk_prod = p.id_produto
                    INNER JOIN 
                        defeito AS d ON o.fk_def = d.id
                    INNER JOIN 
                        usuario AS u ON o.fk_usuario = u.id_usuario
                    INNER JOIN 
                        garantia AS ga ON o.garantia = ga.id_garantia
                    INNER JOIN 
                        componente AS c ON o.componente = c.id_componente
                    WHERE 
                        data_operacao >= @StartDate
                        AND data_operacao <= @EndDate
                    ORDER BY
                        data_operacao DESC;";

                    // Prepare o comando SQL
                    MySqlCommand comando2 = new MySqlCommand(query, conectar);
                    comando2.Parameters.AddWithValue("@numero_grm", TxtFiltroGrm.Text);
                    comando2.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value);
                    comando2.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value);
                    // Crie um adaptador de dados e um DataTable para armazenar os resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando2);
                    DataTable dt = new DataTable();

                    // Preencha o DataTable com os resultados da consulta
                    adapter.Fill(dt);

                    // Atualize o DataSource do DataGridView com os resultados filtrados
                    dataGridView3.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("GRM não encontrada");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            TxtFiltroGrm.Text = "";
            carregar_manutencao();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}



