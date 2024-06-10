
namespace inventoryControl
{
    partial class Operação
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grmNumero = new System.Windows.Forms.ComboBox();
            this.produto = new System.Windows.Forms.ComboBox();
            this.defeito = new System.Windows.Forms.ComboBox();
            this.componente = new System.Windows.Forms.ComboBox();
            this.GRM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gtdComp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.garantia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.addList = new System.Windows.Forms.Button();
            this.finalizar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.serialNumber = new System.Windows.Forms.TextBox();
            this.dataAtual = new System.Windows.Forms.TextBox();
            this.tecnico = new System.Windows.Forms.TextBox();
            this.Olá = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operação Ass. Técnica";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(984, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Saír";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1077, 327);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // grmNumero
            // 
            this.grmNumero.FormattingEnabled = true;
            this.grmNumero.Location = new System.Drawing.Point(18, 85);
            this.grmNumero.Name = "grmNumero";
            this.grmNumero.Size = new System.Drawing.Size(69, 21);
            this.grmNumero.TabIndex = 3;
            this.grmNumero.SelectedIndexChanged += new System.EventHandler(this.grmNumero_SelectedIndexChanged);
            // 
            // produto
            // 
            this.produto.FormattingEnabled = true;
            this.produto.Location = new System.Drawing.Point(21, 151);
            this.produto.Name = "produto";
            this.produto.Size = new System.Drawing.Size(99, 21);
            this.produto.TabIndex = 4;
            this.produto.SelectedIndexChanged += new System.EventHandler(this.produto_SelectedIndexChanged);
            // 
            // defeito
            // 
            this.defeito.FormattingEnabled = true;
            this.defeito.Location = new System.Drawing.Point(455, 149);
            this.defeito.Name = "defeito";
            this.defeito.Size = new System.Drawing.Size(121, 21);
            this.defeito.TabIndex = 5;
            this.defeito.SelectedIndexChanged += new System.EventHandler(this.defeito_SelectedIndexChanged);
            // 
            // componente
            // 
            this.componente.FormattingEnabled = true;
            this.componente.Location = new System.Drawing.Point(421, 85);
            this.componente.Name = "componente";
            this.componente.Size = new System.Drawing.Size(121, 21);
            this.componente.TabIndex = 6;
            this.componente.SelectedIndexChanged += new System.EventHandler(this.componente_SelectedIndexChanged);
            // 
            // GRM
            // 
            this.GRM.AutoSize = true;
            this.GRM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GRM.Location = new System.Drawing.Point(15, 57);
            this.GRM.Name = "GRM";
            this.GRM.Size = new System.Drawing.Size(32, 13);
            this.GRM.TabIndex = 7;
            this.GRM.Text = "GRM";
            this.GRM.Click += new System.EventHandler(this.GRM_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(18, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Módulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(452, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Defeito";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(418, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Componente";
            // 
            // gtdComp
            // 
            this.gtdComp.Location = new System.Drawing.Point(567, 85);
            this.gtdComp.Name = "gtdComp";
            this.gtdComp.Size = new System.Drawing.Size(43, 20);
            this.gtdComp.TabIndex = 11;
            this.gtdComp.TextChanged += new System.EventHandler(this.gtdComp_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(564, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "QTD";
            // 
            // garantia
            // 
            this.garantia.FormattingEnabled = true;
            this.garantia.Location = new System.Drawing.Point(273, 85);
            this.garantia.Name = "garantia";
            this.garantia.Size = new System.Drawing.Size(121, 21);
            this.garantia.TabIndex = 13;
            this.garantia.SelectedIndexChanged += new System.EventHandler(this.garantia_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(270, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Garantia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(312, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Status";
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(315, 150);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(121, 21);
            this.status.TabIndex = 15;
            this.status.SelectedIndexChanged += new System.EventHandler(this.status_SelectedIndexChanged);
            // 
            // addList
            // 
            this.addList.Location = new System.Drawing.Point(764, 147);
            this.addList.Name = "addList";
            this.addList.Size = new System.Drawing.Size(75, 23);
            this.addList.TabIndex = 17;
            this.addList.Text = "Add list";
            this.addList.UseVisualStyleBackColor = true;
            this.addList.Click += new System.EventHandler(this.addList_Click);
            // 
            // finalizar
            // 
            this.finalizar.Location = new System.Drawing.Point(876, 147);
            this.finalizar.Name = "finalizar";
            this.finalizar.Size = new System.Drawing.Size(75, 23);
            this.finalizar.TabIndex = 18;
            this.finalizar.Text = "Finalizar";
            this.finalizar.UseVisualStyleBackColor = true;
            this.finalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(136, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(136, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Serial Number";
            // 
            // serialNumber
            // 
            this.serialNumber.Location = new System.Drawing.Point(139, 151);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(154, 20);
            this.serialNumber.TabIndex = 23;
            this.serialNumber.TextChanged += new System.EventHandler(this.serialNumber_TextChanged);
            // 
            // dataAtual
            // 
            this.dataAtual.Location = new System.Drawing.Point(139, 85);
            this.dataAtual.Name = "dataAtual";
            this.dataAtual.Size = new System.Drawing.Size(106, 20);
            this.dataAtual.TabIndex = 24;
            this.dataAtual.TextChanged += new System.EventHandler(this.dataAtual_TextChanged);
            // 
            // tecnico
            // 
            this.tecnico.Location = new System.Drawing.Point(753, 85);
            this.tecnico.Name = "tecnico";
            this.tecnico.Size = new System.Drawing.Size(100, 20);
            this.tecnico.TabIndex = 25;
            this.tecnico.TextChanged += new System.EventHandler(this.tecnico_TextChanged);
            // 
            // Olá
            // 
            this.Olá.AutoSize = true;
            this.Olá.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Olá.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Olá.Location = new System.Drawing.Point(723, 92);
            this.Olá.Name = "Olá";
            this.Olá.Size = new System.Drawing.Size(24, 14);
            this.Olá.TabIndex = 26;
            this.Olá.Text = "Olá";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(943, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Cadastrar nova GRM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(943, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Consultar Serial";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Operação
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1101, 528);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Olá);
            this.Controls.Add(this.tecnico);
            this.Controls.Add(this.dataAtual);
            this.Controls.Add(this.serialNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.finalizar);
            this.Controls.Add(this.addList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.garantia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gtdComp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GRM);
            this.Controls.Add(this.componente);
            this.Controls.Add(this.defeito);
            this.Controls.Add(this.produto);
            this.Controls.Add(this.grmNumero);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Operação";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operação";
            this.Load += new System.EventHandler(this.Operação_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox grmNumero;
        private System.Windows.Forms.ComboBox produto;
        private System.Windows.Forms.ComboBox defeito;
        private System.Windows.Forms.ComboBox componente;
        private System.Windows.Forms.Label GRM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox gtdComp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox garantia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Button addList;
        private System.Windows.Forms.Button finalizar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox serialNumber;
        private System.Windows.Forms.TextBox dataAtual;
        private System.Windows.Forms.TextBox tecnico;
        private System.Windows.Forms.Label Olá;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}