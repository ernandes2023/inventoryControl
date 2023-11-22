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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {

                MessageBox.Show("Todos os campos precisam ser preenchidos!");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";

            }
            else
            {
                MySqlConnection conectar = new MySqlConnection("server = localhost; database = assistencia; uid = root; pwd = 'etec'");
                conectar.Open();
                MySqlCommand cadastrar = new MySqlCommand("INSERT INTO tecnico (nome_tec, cargo, login, senha) values ('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "');", conectar);
                cadastrar.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso !!!");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }

        }
    }
}
