namespace IS_SisAdmin
{
    partial class frmConfigBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigBD));
            this.txtNomeConexao = new System.Windows.Forms.TextBox();
            this.txtServidorInstancia = new System.Windows.Forms.MaskedTextBox();
            this.txtBD = new System.Windows.Forms.MaskedTextBox();
            this.txtLogin = new System.Windows.Forms.MaskedTextBox();
            this.mskSenha = new System.Windows.Forms.MaskedTextBox();
            this.lblNomeConexao = new System.Windows.Forms.Label();
            this.lblServidorInstancia = new System.Windows.Forms.Label();
            this.lblBD = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblSenhaConfirmar = new System.Windows.Forms.Label();
            this.mskSenhaConfirmar = new System.Windows.Forms.MaskedTextBox();
            this.epConfigBD = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEye = new System.Windows.Forms.Button();
            this.mskTimeOut = new System.Windows.Forms.MaskedTextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.dgvInstancia = new System.Windows.Forms.DataGridView();
            this.btnInstancia = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblInstancia = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSalvar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSair = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.epConfigBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstancia)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeConexao
            // 
            this.txtNomeConexao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNomeConexao.Enabled = false;
            this.txtNomeConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeConexao.Location = new System.Drawing.Point(127, 12);
            this.txtNomeConexao.Name = "txtNomeConexao";
            this.txtNomeConexao.Size = new System.Drawing.Size(263, 22);
            this.txtNomeConexao.TabIndex = 0;
            this.txtNomeConexao.Tag = "";
            this.txtNomeConexao.Text = "Conecta_Administrativo";
            // 
            // txtServidorInstancia
            // 
            this.txtServidorInstancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidorInstancia.Location = new System.Drawing.Point(127, 68);
            this.txtServidorInstancia.Name = "txtServidorInstancia";
            this.txtServidorInstancia.Size = new System.Drawing.Size(219, 22);
            this.txtServidorInstancia.TabIndex = 2;
            this.txtServidorInstancia.Tag = "";
            // 
            // txtBD
            // 
            this.txtBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBD.Location = new System.Drawing.Point(127, 96);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(263, 22);
            this.txtBD.TabIndex = 3;
            this.txtBD.Tag = "";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(127, 124);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(263, 22);
            this.txtLogin.TabIndex = 4;
            this.txtLogin.Tag = "";
            // 
            // mskSenha
            // 
            this.mskSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskSenha.Location = new System.Drawing.Point(127, 152);
            this.mskSenha.Name = "mskSenha";
            this.mskSenha.Size = new System.Drawing.Size(219, 22);
            this.mskSenha.TabIndex = 5;
            this.mskSenha.Tag = "";
            this.mskSenha.UseSystemPasswordChar = true;
            this.mskSenha.TextChanged += new System.EventHandler(this.mskSenha_TextChanged);
            // 
            // lblNomeConexao
            // 
            this.lblNomeConexao.AutoSize = true;
            this.lblNomeConexao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeConexao.Location = new System.Drawing.Point(6, 15);
            this.lblNomeConexao.Name = "lblNomeConexao";
            this.lblNomeConexao.Size = new System.Drawing.Size(117, 14);
            this.lblNomeConexao.TabIndex = 2;
            this.lblNomeConexao.Text = "Nome da Conexão";
            // 
            // lblServidorInstancia
            // 
            this.lblServidorInstancia.AutoSize = true;
            this.lblServidorInstancia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidorInstancia.Location = new System.Drawing.Point(2, 71);
            this.lblServidorInstancia.Name = "lblServidorInstancia";
            this.lblServidorInstancia.Size = new System.Drawing.Size(121, 14);
            this.lblServidorInstancia.TabIndex = 2;
            this.lblServidorInstancia.Text = "Servidor\\Instância";
            // 
            // lblBD
            // 
            this.lblBD.AutoSize = true;
            this.lblBD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBD.Location = new System.Drawing.Point(18, 99);
            this.lblBD.Name = "lblBD";
            this.lblBD.Size = new System.Drawing.Size(105, 14);
            this.lblBD.TabIndex = 2;
            this.lblBD.Text = "Banco de Dados";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(82, 127);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 14);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(78, 155);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(45, 14);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha";
            // 
            // lblSenhaConfirmar
            // 
            this.lblSenhaConfirmar.AutoSize = true;
            this.lblSenhaConfirmar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaConfirmar.Location = new System.Drawing.Point(14, 183);
            this.lblSenhaConfirmar.Name = "lblSenhaConfirmar";
            this.lblSenhaConfirmar.Size = new System.Drawing.Size(109, 14);
            this.lblSenhaConfirmar.TabIndex = 7;
            this.lblSenhaConfirmar.Text = "Confirmar Senha";
            // 
            // mskSenhaConfirmar
            // 
            this.mskSenhaConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskSenhaConfirmar.Location = new System.Drawing.Point(127, 180);
            this.mskSenhaConfirmar.Name = "mskSenhaConfirmar";
            this.mskSenhaConfirmar.Size = new System.Drawing.Size(219, 22);
            this.mskSenhaConfirmar.TabIndex = 7;
            this.mskSenhaConfirmar.Tag = "";
            this.mskSenhaConfirmar.UseSystemPasswordChar = true;
            // 
            // epConfigBD
            // 
            this.epConfigBD.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epConfigBD.ContainerControl = this;
            // 
            // btnEye
            // 
            this.btnEye.Enabled = false;
            this.btnEye.Location = new System.Drawing.Point(348, 151);
            this.btnEye.Name = "btnEye";
            this.btnEye.Size = new System.Drawing.Size(42, 22);
            this.btnEye.TabIndex = 6;
            this.btnEye.TabStop = false;
            this.btnEye.Tag = "";
            this.btnEye.UseVisualStyleBackColor = true;
            this.btnEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEye_MouseDown);
            this.btnEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEye_MouseUp);
            // 
            // mskTimeOut
            // 
            this.mskTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTimeOut.Location = new System.Drawing.Point(127, 40);
            this.mskTimeOut.Mask = "00";
            this.mskTimeOut.Name = "mskTimeOut";
            this.mskTimeOut.Size = new System.Drawing.Size(22, 22);
            this.mskTimeOut.TabIndex = 1;
            this.mskTimeOut.TabStop = false;
            this.mskTimeOut.Tag = "";
            this.mskTimeOut.Text = "01";
            this.mskTimeOut.ValidatingType = typeof(int);
            this.mskTimeOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskTimeOut_KeyPress);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeOut.Location = new System.Drawing.Point(4, 43);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(119, 14);
            this.lblTimeOut.TabIndex = 11;
            this.lblTimeOut.Text = "Time Out Conexão";
            // 
            // dgvInstancia
            // 
            this.dgvInstancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstancia.Location = new System.Drawing.Point(5, 296);
            this.dgvInstancia.Name = "dgvInstancia";
            this.dgvInstancia.Size = new System.Drawing.Size(389, 145);
            this.dgvInstancia.TabIndex = 12;
            this.dgvInstancia.TabStop = false;
            this.dgvInstancia.Tag = "Ñ|";
            this.dgvInstancia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstancia_CellContentClick);
            // 
            // btnInstancia
            // 
            this.btnInstancia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInstancia.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstancia.Location = new System.Drawing.Point(350, 68);
            this.btnInstancia.Name = "btnInstancia";
            this.btnInstancia.Size = new System.Drawing.Size(40, 22);
            this.btnInstancia.TabIndex = 13;
            this.btnInstancia.Tag = "";
            this.btnInstancia.Text = "...";
            this.btnInstancia.UseVisualStyleBackColor = true;
            this.btnInstancia.Click += new System.EventHandler(this.btnInstancia_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 180;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblInstancia
            // 
            this.lblInstancia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstancia.Location = new System.Drawing.Point(5, 258);
            this.lblInstancia.Name = "lblInstancia";
            this.lblInstancia.Size = new System.Drawing.Size(385, 31);
            this.lblInstancia.TabIndex = 14;
            this.lblInstancia.Text = "------";
            this.lblInstancia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Active = false;
            this.btnSalvar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalvar.BorderRadius = 0;
            this.btnSalvar.ButtonText = "   &Salvar";
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.DisabledColor = System.Drawing.Color.Gray;
            this.btnSalvar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSalvar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Iconimage")));
            this.btnSalvar.Iconimage_right = null;
            this.btnSalvar.Iconimage_right_Selected = null;
            this.btnSalvar.Iconimage_Selected = null;
            this.btnSalvar.IconMarginLeft = 10;
            this.btnSalvar.IconMarginRight = 0;
            this.btnSalvar.IconRightVisible = true;
            this.btnSalvar.IconRightZoom = 0D;
            this.btnSalvar.IconVisible = true;
            this.btnSalvar.IconZoom = 50D;
            this.btnSalvar.IsTab = false;
            this.btnSalvar.Location = new System.Drawing.Point(69, 220);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSalvar.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btnSalvar.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnSalvar.selected = false;
            this.btnSalvar.Size = new System.Drawing.Size(140, 35);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.Tag = "Salvar";
            this.btnSalvar.Text = "   &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Textcolor = System.Drawing.Color.White;
            this.btnSalvar.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Active = false;
            this.btnSair.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSair.BackgroundImage")));
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSair.BorderRadius = 0;
            this.btnSair.ButtonText = "    Sai&r";
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.DisabledColor = System.Drawing.Color.Gray;
            this.btnSair.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSair.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSair.Iconimage")));
            this.btnSair.Iconimage_right = null;
            this.btnSair.Iconimage_right_Selected = null;
            this.btnSair.Iconimage_Selected = null;
            this.btnSair.IconMarginLeft = 10;
            this.btnSair.IconMarginRight = 0;
            this.btnSair.IconRightVisible = true;
            this.btnSair.IconRightZoom = 0D;
            this.btnSair.IconVisible = true;
            this.btnSair.IconZoom = 50D;
            this.btnSair.IsTab = false;
            this.btnSair.Location = new System.Drawing.Point(219, 220);
            this.btnSair.Name = "btnSair";
            this.btnSair.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSair.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btnSair.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnSair.selected = false;
            this.btnSair.Size = new System.Drawing.Size(140, 35);
            this.btnSair.TabIndex = 56;
            this.btnSair.Text = "    Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Textcolor = System.Drawing.Color.White;
            this.btnSair.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmConfigBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 451);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblInstancia);
            this.Controls.Add(this.btnInstancia);
            this.Controls.Add(this.dgvInstancia);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.mskTimeOut);
            this.Controls.Add(this.btnEye);
            this.Controls.Add(this.lblSenhaConfirmar);
            this.Controls.Add(this.mskSenhaConfirmar);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblBD);
            this.Controls.Add(this.lblServidorInstancia);
            this.Controls.Add(this.lblNomeConexao);
            this.Controls.Add(this.mskSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtBD);
            this.Controls.Add(this.txtServidorInstancia);
            this.Controls.Add(this.txtNomeConexao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigBD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Configuração do BD";
            this.Load += new System.EventHandler(this.FrmConfigBD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfigBD_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.epConfigBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeConexao;
        private System.Windows.Forms.MaskedTextBox txtServidorInstancia;
        private System.Windows.Forms.MaskedTextBox txtBD;
        private System.Windows.Forms.MaskedTextBox txtLogin;
        private System.Windows.Forms.MaskedTextBox mskSenha;
        private System.Windows.Forms.Label lblNomeConexao;
        private System.Windows.Forms.Label lblServidorInstancia;
        private System.Windows.Forms.Label lblBD;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblSenhaConfirmar;
        private System.Windows.Forms.MaskedTextBox mskSenhaConfirmar;
        private System.Windows.Forms.ErrorProvider epConfigBD;
        private System.Windows.Forms.Button btnEye;
        private System.Windows.Forms.MaskedTextBox mskTimeOut;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Button btnInstancia;
        private System.Windows.Forms.DataGridView dgvInstancia;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblInstancia;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Bunifu.Framework.UI.BunifuFlatButton btnSair;
        private Bunifu.Framework.UI.BunifuFlatButton btnSalvar;
    }
}