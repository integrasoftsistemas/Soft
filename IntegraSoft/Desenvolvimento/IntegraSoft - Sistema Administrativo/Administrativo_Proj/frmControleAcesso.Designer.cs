namespace IS_SisAdmin
{
    partial class frmControleAcesso
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControleAcesso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.pnlDireito = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.trvPermissoes = new SmartSolutions.Controls.TriStateTreeView();
            this.imgTreeviewer = new System.Windows.Forms.ImageList(this.components);
            this.picAguarde = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.PW_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PW_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PW_Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDireitos = new System.Windows.Forms.Button();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.lblPesquisarPor = new System.Windows.Forms.Label();
            this.pnlDireito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAguarde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.pnlUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(67, 5);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(499, 21);
            this.txtPesquisa.TabIndex = 1;
            this.txtPesquisa.Tag = "";
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // pnlDireito
            // 
            this.pnlDireito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDireito.Controls.Add(this.lblLogin);
            this.pnlDireito.Controls.Add(this.lblNomeUsuario);
            this.pnlDireito.Controls.Add(this.trvPermissoes);
            this.pnlDireito.Controls.Add(this.picAguarde);
            this.pnlDireito.Controls.Add(this.btnSalvar);
            this.pnlDireito.Controls.Add(this.btnCancelar);
            this.pnlDireito.Location = new System.Drawing.Point(579, 10);
            this.pnlDireito.Name = "pnlDireito";
            this.pnlDireito.Size = new System.Drawing.Size(452, 510);
            this.pnlDireito.TabIndex = 5;
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(54, 33);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(343, 18);
            this.lblLogin.TabIndex = 12;
            this.lblLogin.Text = "lblLogin";
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUsuario.Location = new System.Drawing.Point(54, 5);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(343, 18);
            this.lblNomeUsuario.TabIndex = 11;
            this.lblNomeUsuario.Text = "lblNomeUsuario";
            // 
            // trvPermissoes
            // 
            this.trvPermissoes.CheckBoxes = true;
            this.trvPermissoes.CheckedImageIndex = 3;
            this.trvPermissoes.ImageIndex = 0;
            this.trvPermissoes.ImageList = this.imgTreeviewer;
            this.trvPermissoes.IndeterminateImageIndex = 4;
            this.trvPermissoes.Location = new System.Drawing.Point(5, 59);
            this.trvPermissoes.Name = "trvPermissoes";
            this.trvPermissoes.SelectedImageIndex = 1;
            this.trvPermissoes.Size = new System.Drawing.Size(440, 388);
            this.trvPermissoes.TabIndex = 10;
            this.trvPermissoes.UncheckedImageIndex = 5;
            this.trvPermissoes.UseCustomImages = true;
            // 
            // imgTreeviewer
            // 
            this.imgTreeviewer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeviewer.ImageStream")));
            this.imgTreeviewer.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imgTreeviewer.Images.SetKeyName(0, "");
            this.imgTreeviewer.Images.SetKeyName(1, "");
            this.imgTreeviewer.Images.SetKeyName(2, "");
            this.imgTreeviewer.Images.SetKeyName(3, "");
            this.imgTreeviewer.Images.SetKeyName(4, "");
            this.imgTreeviewer.Images.SetKeyName(5, "");
            // 
            // picAguarde
            // 
            this.picAguarde.Image = ((System.Drawing.Image)(resources.GetObject("picAguarde.Image")));
            this.picAguarde.Location = new System.Drawing.Point(135, 124);
            this.picAguarde.Name = "picAguarde";
            this.picAguarde.Size = new System.Drawing.Size(226, 226);
            this.picAguarde.TabIndex = 3;
            this.picAguarde.TabStop = false;
            this.picAguarde.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(12, 455);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(167, 40);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Tag = "";
            this.btnSalvar.Text = "     &Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(265, 455);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(167, 40);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMensagem.Location = new System.Drawing.Point(4, 494);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(69, 13);
            this.lblMensagem.TabIndex = 4;
            this.lblMensagem.Text = "Mensagem";
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
            this.dgvUsuario.Location = new System.Drawing.Point(6, 32);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.RowHeadersWidth = 20;
            this.dgvUsuario.RowTemplate.Height = 18;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(560, 416);
            this.dgvUsuario.TabIndex = 2;
            this.dgvUsuario.Tag = "";
            this.dgvUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellClick);
            this.dgvUsuario.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuario_ColumnHeaderMouseClick);
            // 
            // PW_ID
            // 
            this.PW_ID.DataPropertyName = "PW_ID";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "000";
            dataGridViewCellStyle5.NullValue = null;
            this.PW_ID.DefaultCellStyle = dataGridViewCellStyle5;
            this.PW_ID.HeaderText = "ID";
            this.PW_ID.Name = "PW_ID";
            this.PW_ID.ReadOnly = true;
            this.PW_ID.Width = 50;
            // 
            // PW_Nome
            // 
            this.PW_Nome.DataPropertyName = "PW_Nome";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PW_Nome.DefaultCellStyle = dataGridViewCellStyle6;
            this.PW_Nome.HeaderText = "Nome Usuário";
            this.PW_Nome.Name = "PW_Nome";
            this.PW_Nome.ReadOnly = true;
            this.PW_Nome.Width = 260;
            // 
            // PW_Login
            // 
            this.PW_Login.DataPropertyName = "PW_Login";
            this.PW_Login.HeaderText = "Login";
            this.PW_Login.Name = "PW_Login";
            this.PW_Login.ReadOnly = true;
            this.PW_Login.Width = 205;
            // 
            // btnDireitos
            // 
            this.btnDireitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDireitos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireitos.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDireitos.Image = ((System.Drawing.Image)(resources.GetObject("btnDireitos.Image")));
            this.btnDireitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDireitos.Location = new System.Drawing.Point(192, 461);
            this.btnDireitos.Name = "btnDireitos";
            this.btnDireitos.Size = new System.Drawing.Size(167, 40);
            this.btnDireitos.TabIndex = 3;
            this.btnDireitos.Tag = "Ver os Direitos";
            this.btnDireitos.Text = "    &Ver os Direitos";
            this.btnDireitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDireitos.UseVisualStyleBackColor = true;
            this.btnDireitos.Click += new System.EventHandler(this.btnDireitos_Click);
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.Controls.Add(this.lblPesquisarPor);
            this.pnlUsuario.Controls.Add(this.dgvUsuario);
            this.pnlUsuario.Controls.Add(this.btnDireitos);
            this.pnlUsuario.Controls.Add(this.txtPesquisa);
            this.pnlUsuario.Controls.Add(this.lblMensagem);
            this.pnlUsuario.Location = new System.Drawing.Point(5, 10);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(569, 512);
            this.pnlUsuario.TabIndex = 0;
            // 
            // lblPesquisarPor
            // 
            this.lblPesquisarPor.AutoSize = true;
            this.lblPesquisarPor.Location = new System.Drawing.Point(8, 10);
            this.lblPesquisarPor.Name = "lblPesquisarPor";
            this.lblPesquisarPor.Size = new System.Drawing.Size(53, 13);
            this.lblPesquisarPor.TabIndex = 5;
            this.lblPesquisarPor.Text = "Pesquisar";
            // 
            // frmControleAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 531);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.pnlDireito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControleAcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Definir os Direitos de Acesso do Usuário";
            this.Load += new System.EventHandler(this.frmControleAcesso_Load);
            this.pnlDireito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAguarde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Panel pnlDireito;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Button btnDireitos;
        private System.Windows.Forms.PictureBox picAguarde;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.ImageList imgTreeviewer;
        private SmartSolutions.Controls.TriStateTreeView trvPermissoes;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPesquisarPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn PW_Login;
    }
}