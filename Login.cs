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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Hide();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection(Program.conexaoBD);
            conectar.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand();
                //Comando SQL
                comando.CommandText = "select * from tecnico where login = '" + txtLogin1.Text + "' and senha = '" + txtSenha1.Text + "'";

                comando.Connection = conectar;
                //Executar Comando
                var resultado = comando.ExecuteScalar();

                if (resultado != null)
                {
                     Cadastro2 cadprodutos = new Cadastro2();
                     cadprodutos.Show();
                     this.Hide();
                }
                else if (txtLogin1.Text == "" || txtSenha1.Text == "")
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException er)
            {
                MessageBox.Show("Alguma coisa deu errado!" + er, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conectar.Close();
                conectar.ClearAllPoolsAsync();
            }
      
        }

        private void btnOlho_Click(object sender, EventArgs e)
        {
            if (txtSenha1.PasswordChar =='*')
            {
                txtSenha1.PasswordChar = default;
                btnOlho1.Text = "Esconder senha";
            }
            else
            {
                txtSenha1.PasswordChar = '*';
                btnOlho1.Text = "Mostrar senha";
            }
        }
    }
}
