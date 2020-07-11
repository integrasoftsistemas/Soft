namespace IS_SisAdmin
{
    partial class frmPesquisaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.PW_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PW_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PW_Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboProcurarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProcurarPor = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtConteudo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMensagem.Location = new System.Drawing.Point(12, 359);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(69, 13);
            this.lblMensagem.TabIndex = 6;
            this.lblMensagem.Text = "Mensagem";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(499, 14);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(100, 33);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Tag = "Pesquisar";
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AllowUserToResizeColumns = false;
            this.dgvUsuario.AllowUserToResizeRows = false;
            this.dgvUsuario.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PW_ID,
            this.PW_Nome,
            this.PW_Login});
            this.dgvUsuario.Enabled = false;
            this.dgvUsuario.Location = new System.Drawing.Point(12, 53);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.RowHeadersVisible = false;
            this.dgvUsuario.RowTemplate.Height = 18;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(587, 300);
            this.dgvUsuario.TabIndex = 5;
            this.dgvUsuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellDoubleClick);
            // 
            // PW_ID
            // 
            this.PW_ID.DataPropertyName = "PW_ID";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "000";
            dataGridViewCellStyle1.NullValue = null;
            this.PW_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.PW_ID.HeaderText = "ID";
            this.PW_ID.Name = "PW_ID";
            this.PW_ID.ReadOnly = true;
            this.PW_ID.Visible = false;
            // 
            // PW_Nome
            // 
            this.PW_Nome.DataPropertyName = "PW_Nome";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PW_Nome.DefaultCellStyle = dataGridViewCellStyle2;
            this.PW_Nome.HeaderText = "Nome";
            this.PW_Nome.Name = "PW_Nome";
            this.PW_Nome.ReadOnly = true;
            this.PW_Nome.Width = 300;
            // 
            // PW_Login
            // 
            this.PW_Login.DataPropertyName = "PW_Login";
            this.PW_Login.HeaderText = "Login";
            this.PW_Login.Name = "PW_Login";
            this.PW_Login.ReadOnly = true;
            this.PW_Login.Width = 250;
            // 
            // cboProcurarPor
            // 
            this.cboProcurarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcurarPor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProcurarPor.FormattingEnabled = true;
            this.cboProcurarPor.Location = new System.Drawing.Point(12, 25);
            this.cboProcurarPor.Name = "cboProcurarPor";
            this.cboProcurarPor.Size = new System.Drawing.Size(156, 22);
            this.cboProcurarPor.TabIndex = 2;
            this.cboProcurarPor.TabStop = false;
            this.cboProcurarPor.Tag = "";
            this.cboProcurarPor.SelectedIndexChanged += new System.EventHandler(this.cboProcurarPor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conteúdo (Deixe em branco para todos)";
            // 
            // lblProcurarPor
            // 
            this.lblProcurarPor.AutoSize = true;
            this.lblProcurarPor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcurarPor.Location = new System.Drawing.Point(9, 9);
            this.lblProcurarPor.Name = "lblProcurarPor";
            this.lblProcurarPor.Size = new System.Drawing.Size(56, 13);
            this.lblProcurarPor.TabIndex = 0;
            this.lblProcurarPor.Text = "Procurar";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(228, 371);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(106, 33);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtConteudo
            // 
            this.txtConteudo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConteudo.Location = new System.Drawing.Point(174, 25);
            this.txtConteudo.Name = "txtConteudo";
            this.txtConteudo.Size = new System.Drawing.Size(314, 20);
            this.txtConteudo.TabIndex = 3;
            this.txtConteudo.Tag = "Ñ|";
            // 
            // frmPesquisaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 409);
            this.Controls.Add(this.txtConteudo);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.cboProcurarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProcurarPor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaUsuario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Pesquisa de Usuário";
            this.Load += new System.EventHandler(this.frmPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPesquisaUsuario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.ComboBox cboProcurarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProcurarPor;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtConteudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_Login;
    }
}