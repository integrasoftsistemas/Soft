namespace IS_SisAdmin
{
    partial class frmControleAcessoAdapta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trvFormCtrl = new System.Windows.Forms.TreeView();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.lblProcessando = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trvFormCtrl);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 463);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // trvFormCtrl
            // 
            this.trvFormCtrl.Location = new System.Drawing.Point(5, 5);
            this.trvFormCtrl.Name = "trvFormCtrl";
            this.trvFormCtrl.Size = new System.Drawing.Size(440, 453);
            this.trvFormCtrl.TabIndex = 0;
            this.trvFormCtrl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFormCtrl_AfterSelect);
            // 
            // btnProcessar
            // 
            this.btnProcessar.AutoSize = true;
            this.btnProcessar.BackColor = System.Drawing.Color.Khaki;
            this.btnProcessar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcessar.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessar.Location = new System.Drawing.Point(85, 16);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(130, 41);
            this.btnProcessar.TabIndex = 11;
            this.btnProcessar.Tag = "Processar";
            this.btnProcessar.Text = " &Processar";
            this.btnProcessar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessar.UseVisualStyleBackColor = false;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // lblProcessando
            // 
            this.lblProcessando.AutoSize = true;
            this.lblProcessando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessando.Location = new System.Drawing.Point(61, 25);
            this.lblProcessando.Name = "lblProcessando";
            this.lblProcessando.Size = new System.Drawing.Size(327, 24);
            this.lblProcessando.TabIndex = 12;
            this.lblProcessando.Text = "Processando, por favor aguarde...";
            this.lblProcessando.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = true;
            this.btnSair.BackColor = System.Drawing.Color.Khaki;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(264, 16);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(130, 41);
            this.btnSair.TabIndex = 15;
            this.btnSair.Tag = "";
            this.btnSair.Text = " &Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmControleAcessoAdapta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 65);
            this.ControlBox = false;
            this.Controls.Add(this.lblProcessando);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControleAcessoAdapta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptação dos Direitos do Usuário";
            this.Load += new System.EventHandler(this.frmControleAcessoAdapta_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView trvFormCtrl;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Label lblProcessando;
        private System.Windows.Forms.Button btnSair;
    }
}