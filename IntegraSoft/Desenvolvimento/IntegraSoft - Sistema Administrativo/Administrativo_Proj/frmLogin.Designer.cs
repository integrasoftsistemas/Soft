namespace IS_SisAdmin
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mskPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.verticalLabel1 = new Brazuca.Brazuca.Windows.FormControls.VerticalLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEye = new System.Windows.Forms.Button();
            this.lblCapsLook = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // mskPassword
            // 
            this.mskPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPassword.Location = new System.Drawing.Point(59, 95);
            this.mskPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mskPassword.Name = "mskPassword";
            this.mskPassword.Size = new System.Drawing.Size(216, 30);
            this.mskPassword.TabIndex = 4;
            this.mskPassword.Text = "c#2019-IS";
            this.mskPassword.UseSystemPasswordChar = true;
            this.mskPassword.TextChanged += new System.EventHandler(this.mskPassword_TextChanged);
            this.mskPassword.Enter += new System.EventHandler(this.mskPassword_Enter);
            this.mskPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskPassword_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(59, 134);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(124, 46);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "   &Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(59, 30);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(260, 30);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Text = "IS.ADMIN";
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLogin_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(195, 134);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 46);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "  &Sair";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.verticalLabel1.EndColor = System.Drawing.Color.Empty;
            this.verticalLabel1.Font = new System.Drawing.Font("Membra", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel1.ForeColor = System.Drawing.Color.White;
            this.verticalLabel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.verticalLabel1.Image = null;
            this.verticalLabel1.ImageAlignment = Brazuca.Brazuca.Windows.FormControls.VerticalLabel.ObjectAlignments.TopLeft;
            this.verticalLabel1.ImageIndex = -1;
            this.verticalLabel1.ImageKey = null;
            this.verticalLabel1.ImageList = null;
            this.verticalLabel1.Location = new System.Drawing.Point(0, 0);
            this.verticalLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.PaintMethod = Brazuca.Brazuca.Windows.FormControls.VerticalLabel.PaintMethods.Solid;
            this.verticalLabel1.ShadowColor = System.Drawing.Color.Empty;
            this.verticalLabel1.ShadowDepth = 0;
            this.verticalLabel1.Size = new System.Drawing.Size(53, 188);
            this.verticalLabel1.StartColor = System.Drawing.Color.Empty;
            this.verticalLabel1.TabIndex = 0;
            this.verticalLabel1.TabStop = false;
            this.verticalLabel1.Text = "Login";
            this.verticalLabel1.TextAlignment = Brazuca.Brazuca.Windows.FormControls.VerticalLabel.ObjectAlignments.MiddleCenter;
            this.verticalLabel1.TextLayout = Brazuca.Brazuca.Windows.FormControls.VerticalLabel.TextLayouts.BottomToTop;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Computerfont", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(54, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Computerfont", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(54, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha";
            // 
            // btnEye
            // 
            this.btnEye.Enabled = false;
            this.btnEye.Image = ((System.Drawing.Image)(resources.GetObject("btnEye.Image")));
            this.btnEye.Location = new System.Drawing.Point(278, 95);
            this.btnEye.Name = "btnEye";
            this.btnEye.Size = new System.Drawing.Size(41, 26);
            this.btnEye.TabIndex = 7;
            this.btnEye.TabStop = false;
            this.btnEye.UseVisualStyleBackColor = true;
            this.btnEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEye_MouseDown);
            this.btnEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEye_MouseUp);
            // 
            // lblCapsLook
            // 
            this.lblCapsLook.AutoSize = true;
            this.lblCapsLook.Location = new System.Drawing.Point(208, 78);
            this.lblCapsLook.Name = "lblCapsLook";
            this.lblCapsLook.Size = new System.Drawing.Size(89, 21);
            this.lblCapsLook.TabIndex = 8;
            this.lblCapsLook.Text = "caps lock";
            this.lblCapsLook.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 187);
            this.Controls.Add(this.mskPassword);
            this.Controls.Add(this.verticalLabel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEye);
            this.Controls.Add(this.lblCapsLook);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Login do Usuário";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MaskedTextBox mskPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnCancelar;
        private Brazuca.Brazuca.Windows.FormControls.VerticalLabel verticalLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEye;
        private System.Windows.Forms.Label lblCapsLook;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}