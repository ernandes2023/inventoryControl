namespace inventoryControl
{
    partial class Cadastro2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCadastro2 = new System.Windows.Forms.TabControl();
            this.tabCadastroClientes = new System.Windows.Forms.TabPage();
            this.btnExcluir1 = new System.Windows.Forms.Button();
            this.btnSair1 = new System.Windows.Forms.Button();
            this.btnEditar1 = new System.Windows.Forms.Button();
            this.btnSalvar1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.tabCadastroProdutos = new System.Windows.Forms.TabPage();
            this.txtIdCliente1 = new System.Windows.Forms.TextBox();
            this.btnExcluir2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditar2 = new System.Windows.Forms.Button();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.btnSalvar2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.tabCadastroComponentes = new System.Windows.Forms.TabPage();
            this.btnExcluir3 = new System.Windows.Forms.Button();
            this.btnSair3 = new System.Windows.Forms.Button();
            this.btnEditar3 = new System.Windows.Forms.Button();
            this.btnSalvar3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvComponentes = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtId3 = new System.Windows.Forms.TextBox();
            this.txtNomeComponente = new System.Windows.Forms.TextBox();
            this.txtIdCliente2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefoneCliente = new System.Windows.Forms.TextBox();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.tabCadastro2.SuspendLayout();
            this.tabCadastroClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.tabCadastroProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tabCadastroComponentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCadastro2
            // 
            this.tabCadastro2.Controls.Add(this.tabCadastroClientes);
            this.tabCadastro2.Controls.Add(this.tabCadastroProdutos);
            this.tabCadastro2.Controls.Add(this.tabCadastroComponentes);
            this.tabCadastro2.Location = new System.Drawing.Point(1, 12);
            this.tabCadastro2.Name = "tabCadastro2";
            this.tabCadastro2.SelectedIndex = 0;
            this.tabCadastro2.Size = new System.Drawing.Size(441, 514);
            this.tabCadastro2.TabIndex = 12;
            // 
            // tabCadastroClientes
            // 
            this.tabCadastroClientes.Controls.Add(this.txtSenha2);
            this.tabCadastroClientes.Controls.Add(this.txtEmailCliente);
            this.tabCadastroClientes.Controls.Add(this.txtTelefoneCliente);
            this.tabCadastroClientes.Controls.Add(this.label10);
            this.tabCadastroClientes.Controls.Add(this.label9);
            this.tabCadastroClientes.Controls.Add(this.label8);
            this.tabCadastroClientes.Controls.Add(this.btnExcluir1);
            this.tabCadastroClientes.Controls.Add(this.btnSair1);
            this.tabCadastroClientes.Controls.Add(this.btnEditar1);
            this.tabCadastroClientes.Controls.Add(this.btnSalvar1);
            this.tabCadastroClientes.Controls.Add(this.label7);
            this.tabCadastroClientes.Controls.Add(this.dgvClientes);
            this.tabCadastroClientes.Controls.Add(this.label6);
            this.tabCadastroClientes.Controls.Add(this.txtId1);
            this.tabCadastroClientes.Controls.Add(this.txtNomeCliente);
            this.tabCadastroClientes.Location = new System.Drawing.Point(4, 22);
            this.tabCadastroClientes.Name = "tabCadastroClientes";
            this.tabCadastroClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastroClientes.Size = new System.Drawing.Size(433, 488);
            this.tabCadastroClientes.TabIndex = 0;
            this.tabCadastroClientes.Text = "Cadastro de clientes";
            this.tabCadastroClientes.UseVisualStyleBackColor = true;
            // 
            // btnExcluir1
            // 
            this.btnExcluir1.Location = new System.Drawing.Point(168, 459);
            this.btnExcluir1.Name = "btnExcluir1";
            this.btnExcluir1.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir1.TabIndex = 41;
            this.btnExcluir1.Text = "Excluir";
            this.btnExcluir1.UseVisualStyleBackColor = true;
            this.btnExcluir1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSair1
            // 
            this.btnSair1.Location = new System.Drawing.Point(249, 459);
            this.btnSair1.Name = "btnSair1";
            this.btnSair1.Size = new System.Drawing.Size(75, 23);
            this.btnSair1.TabIndex = 40;
            this.btnSair1.Text = "Sair";
            this.btnSair1.UseVisualStyleBackColor = true;
            this.btnSair1.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.Location = new System.Drawing.Point(87, 459);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(75, 23);
            this.btnEditar1.TabIndex = 39;
            this.btnEditar1.Text = "Editar";
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSalvar1
            // 
            this.btnSalvar1.Location = new System.Drawing.Point(6, 459);
            this.btnSalvar1.Name = "btnSalvar1";
            this.btnSalvar1.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar1.TabIndex = 38;
            this.btnSalvar1.Text = "Salvar";
            this.btnSalvar1.UseVisualStyleBackColor = true;
            this.btnSalvar1.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Lista de clientes:";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClientes.Location = new System.Drawing.Point(6, 175);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(418, 278);
            this.dgvClientes.TabIndex = 36;
            this.dgvClientes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nome do cliente:";
            // 
            // txtId1
            // 
            this.txtId1.Enabled = false;
            this.txtId1.Location = new System.Drawing.Point(378, 461);
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(49, 20);
            this.txtId1.TabIndex = 31;
            this.txtId1.Visible = false;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(6, 20);
            this.txtNomeCliente.MaxLength = 55;
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(418, 20);
            this.txtNomeCliente.TabIndex = 32;
            // 
            // tabCadastroProdutos
            // 
            this.tabCadastroProdutos.Controls.Add(this.txtIdCliente2);
            this.tabCadastroProdutos.Controls.Add(this.txtIdCliente1);
            this.tabCadastroProdutos.Controls.Add(this.btnExcluir2);
            this.tabCadastroProdutos.Controls.Add(this.label2);
            this.tabCadastroProdutos.Controls.Add(this.btnSair2);
            this.tabCadastroProdutos.Controls.Add(this.label3);
            this.tabCadastroProdutos.Controls.Add(this.btnEditar2);
            this.tabCadastroProdutos.Controls.Add(this.txtId2);
            this.tabCadastroProdutos.Controls.Add(this.txtNomeProduto);
            this.tabCadastroProdutos.Controls.Add(this.btnSalvar2);
            this.tabCadastroProdutos.Controls.Add(this.label4);
            this.tabCadastroProdutos.Controls.Add(this.dgvProdutos);
            this.tabCadastroProdutos.Location = new System.Drawing.Point(4, 22);
            this.tabCadastroProdutos.Name = "tabCadastroProdutos";
            this.tabCadastroProdutos.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastroProdutos.Size = new System.Drawing.Size(433, 488);
            this.tabCadastroProdutos.TabIndex = 1;
            this.tabCadastroProdutos.Text = "Cadastro de produtos";
            this.tabCadastroProdutos.UseVisualStyleBackColor = true;
            // 
            // txtIdCliente1
            // 
            this.txtIdCliente1.Location = new System.Drawing.Point(6, 58);
            this.txtIdCliente1.Name = "txtIdCliente1";
            this.txtIdCliente1.Size = new System.Drawing.Size(68, 20);
            this.txtIdCliente1.TabIndex = 39;
            // 
            // btnExcluir2
            // 
            this.btnExcluir2.Location = new System.Drawing.Point(168, 381);
            this.btnExcluir2.Name = "btnExcluir2";
            this.btnExcluir2.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir2.TabIndex = 35;
            this.btnExcluir2.Text = "Excluir";
            this.btnExcluir2.UseVisualStyleBackColor = true;
            this.btnExcluir2.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nome do produto:";
            // 
            // btnSair2
            // 
            this.btnSair2.Location = new System.Drawing.Point(249, 381);
            this.btnSair2.Name = "btnSair2";
            this.btnSair2.Size = new System.Drawing.Size(75, 23);
            this.btnSair2.TabIndex = 34;
            this.btnSair2.Text = "Sair";
            this.btnSair2.UseVisualStyleBackColor = true;
            this.btnSair2.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Id do cliente:";
            // 
            // btnEditar2
            // 
            this.btnEditar2.Location = new System.Drawing.Point(87, 381);
            this.btnEditar2.Name = "btnEditar2";
            this.btnEditar2.Size = new System.Drawing.Size(75, 23);
            this.btnEditar2.TabIndex = 33;
            this.btnEditar2.Text = "Editar";
            this.btnEditar2.UseVisualStyleBackColor = true;
            this.btnEditar2.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // txtId2
            // 
            this.txtId2.Enabled = false;
            this.txtId2.Location = new System.Drawing.Point(384, 409);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(46, 20);
            this.txtId2.TabIndex = 27;
            this.txtId2.Visible = false;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(6, 19);
            this.txtNomeProduto.MaxLength = 55;
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(418, 20);
            this.txtNomeProduto.TabIndex = 28;
            // 
            // btnSalvar2
            // 
            this.btnSalvar2.Location = new System.Drawing.Point(6, 381);
            this.btnSalvar2.Name = "btnSalvar2";
            this.btnSalvar2.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar2.TabIndex = 32;
            this.btnSalvar2.Text = "Salvar";
            this.btnSalvar2.UseVisualStyleBackColor = true;
            this.btnSalvar2.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Lista de produtos:";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProdutos.Location = new System.Drawing.Point(6, 97);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(418, 278);
            this.dgvProdutos.TabIndex = 30;
            this.dgvProdutos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutos_CellMouseDoubleClick);
            // 
            // tabCadastroComponentes
            // 
            this.tabCadastroComponentes.Controls.Add(this.btnExcluir3);
            this.tabCadastroComponentes.Controls.Add(this.btnSair3);
            this.tabCadastroComponentes.Controls.Add(this.btnEditar3);
            this.tabCadastroComponentes.Controls.Add(this.btnSalvar3);
            this.tabCadastroComponentes.Controls.Add(this.label1);
            this.tabCadastroComponentes.Controls.Add(this.dgvComponentes);
            this.tabCadastroComponentes.Controls.Add(this.label5);
            this.tabCadastroComponentes.Controls.Add(this.txtId3);
            this.tabCadastroComponentes.Controls.Add(this.txtNomeComponente);
            this.tabCadastroComponentes.Location = new System.Drawing.Point(4, 22);
            this.tabCadastroComponentes.Name = "tabCadastroComponentes";
            this.tabCadastroComponentes.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastroComponentes.Size = new System.Drawing.Size(433, 488);
            this.tabCadastroComponentes.TabIndex = 2;
            this.tabCadastroComponentes.Text = "Cadastro de componentes";
            this.tabCadastroComponentes.UseVisualStyleBackColor = true;
            // 
            // btnExcluir3
            // 
            this.btnExcluir3.Location = new System.Drawing.Point(168, 345);
            this.btnExcluir3.Name = "btnExcluir3";
            this.btnExcluir3.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir3.TabIndex = 50;
            this.btnExcluir3.Text = "Excluir";
            this.btnExcluir3.UseVisualStyleBackColor = true;
            this.btnExcluir3.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnSair3
            // 
            this.btnSair3.Location = new System.Drawing.Point(249, 345);
            this.btnSair3.Name = "btnSair3";
            this.btnSair3.Size = new System.Drawing.Size(75, 23);
            this.btnSair3.TabIndex = 49;
            this.btnSair3.Text = "Sair";
            this.btnSair3.UseVisualStyleBackColor = true;
            this.btnSair3.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnEditar3
            // 
            this.btnEditar3.Location = new System.Drawing.Point(87, 345);
            this.btnEditar3.Name = "btnEditar3";
            this.btnEditar3.Size = new System.Drawing.Size(75, 23);
            this.btnEditar3.TabIndex = 48;
            this.btnEditar3.Text = "Editar";
            this.btnEditar3.UseVisualStyleBackColor = true;
            this.btnEditar3.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSalvar3
            // 
            this.btnSalvar3.Location = new System.Drawing.Point(6, 345);
            this.btnSalvar3.Name = "btnSalvar3";
            this.btnSalvar3.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar3.TabIndex = 47;
            this.btnSalvar3.Text = "Salvar";
            this.btnSalvar3.UseVisualStyleBackColor = true;
            this.btnSalvar3.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Lista de componentes:";
            // 
            // dgvComponentes
            // 
            this.dgvComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComponentes.Location = new System.Drawing.Point(6, 61);
            this.dgvComponentes.Name = "dgvComponentes";
            this.dgvComponentes.Size = new System.Drawing.Size(418, 278);
            this.dgvComponentes.TabIndex = 45;
            this.dgvComponentes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Nome do componente:";
            // 
            // txtId3
            // 
            this.txtId3.Enabled = false;
            this.txtId3.Location = new System.Drawing.Point(378, 347);
            this.txtId3.Name = "txtId3";
            this.txtId3.Size = new System.Drawing.Size(49, 20);
            this.txtId3.TabIndex = 43;
            this.txtId3.Visible = false;
            // 
            // txtNomeComponente
            // 
            this.txtNomeComponente.Location = new System.Drawing.Point(6, 19);
            this.txtNomeComponente.MaxLength = 55;
            this.txtNomeComponente.Name = "txtNomeComponente";
            this.txtNomeComponente.Size = new System.Drawing.Size(418, 20);
            this.txtNomeComponente.TabIndex = 44;
            // 
            // txtIdCliente2
            // 
            this.txtIdCliente2.Enabled = false;
            this.txtIdCliente2.Location = new System.Drawing.Point(384, 383);
            this.txtIdCliente2.Name = "txtIdCliente2";
            this.txtIdCliente2.Size = new System.Drawing.Size(46, 20);
            this.txtIdCliente2.TabIndex = 40;
            this.txtIdCliente2.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Telefone do cliente:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Email do cliente:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Senha do cliente:";
            // 
            // txtTelefoneCliente
            // 
            this.txtTelefoneCliente.Location = new System.Drawing.Point(6, 59);
            this.txtTelefoneCliente.MaxLength = 14;
            this.txtTelefoneCliente.Name = "txtTelefoneCliente";
            this.txtTelefoneCliente.Size = new System.Drawing.Size(157, 20);
            this.txtTelefoneCliente.TabIndex = 45;
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(10, 98);
            this.txtEmailCliente.MaxLength = 55;
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(414, 20);
            this.txtEmailCliente.TabIndex = 46;
            // 
            // txtSenha2
            // 
            this.txtSenha2.Location = new System.Drawing.Point(10, 137);
            this.txtSenha2.MaxLength = 20;
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.Size = new System.Drawing.Size(234, 20);
            this.txtSenha2.TabIndex = 47;
            // 
            // Cadastro2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 531);
            this.Controls.Add(this.tabCadastro2);
            this.Name = "Cadastro2";
            this.Text = "Cadastro2";
            this.Load += new System.EventHandler(this.Cad_produtos_Load);
            this.tabCadastro2.ResumeLayout(false);
            this.tabCadastroClientes.ResumeLayout(false);
            this.tabCadastroClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.tabCadastroProdutos.ResumeLayout(false);
            this.tabCadastroProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tabCadastroComponentes.ResumeLayout(false);
            this.tabCadastroComponentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCadastro2;
        private System.Windows.Forms.TabPage tabCadastroProdutos;
        private System.Windows.Forms.TabPage tabCadastroClientes;
        private System.Windows.Forms.Button btnExcluir2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSair2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditar2;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Button btnSalvar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TabPage tabCadastroComponentes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtId1;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Button btnExcluir1;
        private System.Windows.Forms.Button btnSair1;
        private System.Windows.Forms.Button btnEditar1;
        private System.Windows.Forms.Button btnSalvar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnExcluir3;
        private System.Windows.Forms.Button btnSair3;
        private System.Windows.Forms.Button btnEditar3;
        private System.Windows.Forms.Button btnSalvar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvComponentes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtId3;
        private System.Windows.Forms.TextBox txtNomeComponente;
        private System.Windows.Forms.TextBox txtIdCliente1;
        private System.Windows.Forms.TextBox txtIdCliente2;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.TextBox txtTelefoneCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}