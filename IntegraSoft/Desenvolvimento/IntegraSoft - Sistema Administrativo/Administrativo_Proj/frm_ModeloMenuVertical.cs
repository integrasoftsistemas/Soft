using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IS_SisAdmin
{
    public partial class frm_ModeloMenuVertical : Form
    {
        public frm_ModeloMenuVertical()
        {
            InitializeComponent();
        }

        // Dentro do formulário MaximizeBox = False e MinimizeBox = False
        /* Isto aqui é para desabilitar o botão X do formulário 
           using System.Runtime.InteropServices; <- esta linha Precisa ser COLOCADO LOGO ACIMA PARA PODER FUNCIONAR e também dentro do form_Load        

        Tem mais código de linhas abaixo dentro do form_load */
        //const int MF_BYCOMMAND = 0X400;
        //[DllImport("user32")]
        //static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        //[DllImport("user32")]
        //static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        //[DllImport("user32")]
        //static extern int GetMenuItemCount(IntPtr hWnd);

        private void AbrirFormEnPanel(object frmFilho)
        {
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            Form ff = frmFilho as Form;
            ff.TopLevel = false;
            ff.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(ff);
            this.pnlContainer.Tag = ff;
            ff.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmUsuario());
        }

        private void btnTeste3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCliFor());
        }

        private void btnTeste2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmControleAcessoAdapta());
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (pnlMenuV.Width == 245)
            {
                pnlMenuV.Width = 80;
            }
            else
                pnlMenuV.Width = 245;
        }

        private void picFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picRestaurar.Visible = true;
            picMaximizar.Visible = false;
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picRestaurar.Visible = false;
            picMaximizar.Visible = true;
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_ModeloMenuVertical_Load(object sender, EventArgs e)
        {
            /* Isto aqui é para desabilitar o botão X do formulário 
            Tem mais código de linhas em cima */
            //IntPtr hMenu = GetSystemMenu(this.Handle, false);
            //int CountMenu = GetMenuItemCount(hMenu) - 1;
            //RemoveMenu(hMenu, CountMenu, MF_BYCOMMAND);
        }

        private void pnlTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
