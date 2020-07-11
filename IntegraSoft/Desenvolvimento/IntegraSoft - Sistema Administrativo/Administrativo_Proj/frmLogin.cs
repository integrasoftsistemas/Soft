using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_SisAdmin
{
    public partial class frmLogin : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => false;

        public frmLogin()
        {         
           InitializeComponent();
        }

        // Dentro do formulário MaximizeBox = False e MinimizeBox = False
        /* Isto aqui é para desabilitar o botão X do formulário 
           using System.Runtime.InteropServices; <- esta linha Precisa ser COLOCADO LOGO ACIMA PARA PODER FUNCIONAR e também dentro do form_Load        

        Tem mais código de linhas abaixo dentro do form_load */
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        private void frmLogin_Load(object sender, EventArgs e)
        {
            /* Isto aqui é para desabilitar o botão X do formulário 
               Tem mais código de linhas em cima */
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int CountMenu = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, CountMenu, MF_BYCOMMAND);

            IS_Funcoes.Componentes.TrataCorCampos(this.Controls);         
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }

            // Aqui mostra se o CapsLook esta ativo ou não
            //if (Control.IsKeyLocked(Keys.CapsLock))
            //{
            //    lblCapsLook.Visible = true;
            //    lblCapsLook.Text = "Caps Lock esta Ativo";
            //}
            //else
            //{
            //    lblCapsLook.Visible = false;
            //    lblCapsLook.Text = "Caps Lock esta Ativo";
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("O Login precisa ser Informado.", "Nome do Usuário!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtLogin.Focus();
                return;
            }

            if (txtLogin.Text.Length < 5)
            {
                MessageBox.Show("O Login precisa ter no mínimo 5 caracteres.", "Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(mskPassword.Text))
            {
                MessageBox.Show("A Senha precisa ser informada.", "Senha!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                mskPassword.Focus();
                return;
            }

            if (mskPassword.Text.Length < 4)
            {
                MessageBox.Show("A Senha precisa ter no mínimo 4 caracteres.", "Senha!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                mskPassword.Focus();
                return;
            }

            try
            {
                string login = IS_Funcoes.SegurancaCripto.Criptografar(txtLogin.Text);
                string senha = IS_Funcoes.SegurancaCripto.Criptografar(mskPassword.Text);

                Administrativo_Entities.Usuario usuario = new Administrativo_BLL.Usuario().AutenticarUsuario(login, senha);
                if (usuario == null)
                {
                    MessageBox.Show("Login não encontrado ou Senha Inválida!\n\nVerifique se o Login e Senha foram informados corretamente!", "Autenticar Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (usuario.PW_Ativo == false)
                    {
                        MessageBox.Show("Login não está ativo! Acesso Negado ao sistema!", "Autenticar Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Administrativo_Entities.Global.Usuario = usuario;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifico se é diferente de Enter e diferente de seta de voltar
            if ((Keys)e.KeyChar != Keys.Enter && (Keys)e.KeyChar != Keys.Back)                 
            {
                // Se for space mando a mensagem
                if ((Keys)e.KeyChar == Keys.Space)
                {
                    MessageBox.Show("Não é permitido espaço em branco no Login.", "Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    e.Handled = true;
                }
                else
                {
                    // Se não for Letra ou se não for Número ou se não for Ponto Final
                    if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)46)
                    {
                        MessageBox.Show("Não é permitido caracteres especiais no Login.", "L O G I N!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        e.Handled = true;
                    }
                }
            }
        }

        private void mskPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifico se é diferente de Enter e diferente de seta de voltar
            if ((Keys)e.KeyChar != Keys.Enter && (Keys)e.KeyChar != Keys.Back)                
            {
                // Senha não pode ter space
                if ((Keys)e.KeyChar == Keys.Space)
                {
                    MessageBox.Show("Não é permitido caracter em branco na Senha", "S E N H A!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btnEye_MouseDown(object sender, MouseEventArgs e)
        {
            mskPassword.UseSystemPasswordChar = false;
        }

        private void btnEye_MouseUp(object sender, MouseEventArgs e)
        {
            mskPassword.UseSystemPasswordChar = true;
        }

        private void mskPassword_TextChanged(object sender, EventArgs e)
        {
            btnEye.Enabled = (mskPassword.Text.Length > 0);
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskPassword_Enter(object sender, EventArgs e)
        {
            mskPassword.SelectAll();
        }
    }
}
