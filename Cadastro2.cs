using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            // Adqueirir o nome completo do TextBox
            string nomeCompleto = txtName.Text.Trim();

            // Divide o nome completo em partes
            string[] partesNome = nomeCompleto.Split(' ');

            if (partesNome.Length > 1 )
            {
                // Obter o primerio nome
                string primeiroNome = partesNome[0];

                // Obter o útimo Sobrenome
                string ultimoSobrenome = partesNome[partesNome.Length - 1];

                //return $"{primeiroNome}{utimoSobrenome}";
                txtUser.Text = primeiroNome +"."+ ultimoSobrenome;
            }
            else
            {
                MessageBox.Show("Favor Digite o nome completo.",
                    "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            string textOriginal = txtUser.Text;

            string textProcessado = RemoveAcentos(textOriginal.ToLower());

            if(txtUser.Text != textProcessado)
            {
                txtUser.Text = textProcessado;
                txtUser.SelectionStart = textProcessado.Length;
            }
        }

        private string RemoveAcentos(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in textoNormalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
