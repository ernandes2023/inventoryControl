
namespace inventoryControl
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin1 = new System.Windows.Forms.TextBox();
            this.txtSenha1 = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCadastrarse = new System.Windows.Forms.Button();
            this.btnOlho1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(364, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(364, 313);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // txtLogin1
            // 
            this.txtLogin1.Location = new System.Drawing.Point(302, 225);
            this.txtLogin1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLogin1.MaxLength = 20;
            this.txtLogin1.Name = "txtLogin1";
            this.txtLogin1.Size = new System.Drawing.Size(173, 20);
            this.txtLogin1.TabIndex = 3;
            // 
            // txtSenha1
            // 
            this.txtSenha1.Location = new System.Drawing.Point(302, 290);
            this.txtSenha1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSenha1.MaxLength = 20;
            this.txtSenha1.Name = "txtSenha1";
            this.txtSenha1.PasswordChar = '*';
            this.txtSenha1.Size = new System.Drawing.Size(173, 20);
            this.txtSenha1.TabIndex = 4;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(357, 360);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 34);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // btnCadastrarse
            // 
            this.btnCadastrarse.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarse.Location = new System.Drawing.Point(22, 396);
            this.btnCadastrarse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCadastrarse.Name = "btnCadastrarse";
            this.btnCadastrarse.Size = new System.Drawing.Size(119, 34);
            this.btnCadastrarse.TabIndex = 6;
            this.btnCadastrarse.Text = "Cadastrar-se";
            this.btnCadastrarse.UseVisualStyleBackColor = true;
            this.btnCadastrarse.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // btnOlho1
            // 
            this.btnOlho1.Location = new System.Drawing.Point(480, 282);
            this.btnOlho1.Name = "btnOlho1";
            this.btnOlho1.Size = new System.Drawing.Size(75, 34);
            this.btnOlho1.TabIndex = 7;
            this.btnOlho1.Text = "Mostrar senha";
            this.btnOlho1.UseVisualStyleBackColor = true;
            this.btnOlho1.Click += new System.EventHandler(this.btnOlho_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnOlho1);
            this.Controls.Add(this.btnCadastrarse);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtSenha1);
            this.Controls.Add(this.txtLogin1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin1;
        private System.Windows.Forms.TextBox txtSenha1;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCadastrarse;
        private System.Windows.Forms.Button btnOlho1;
    }
}