using IS_Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IS_SisAdmin
{
    public partial class frmUsuario : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;

        public frmUsuario()
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

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            /* Isto aqui é para desabilitar o botão X do formulário 
               Tem mais código de linhas em cima */
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int CountMenu = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, CountMenu, MF_BYCOMMAND);

            IS_Funcoes.Componentes.TrataCorCampos(this.Controls);
            txtNome.Select();
            Registro();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Se tiver algum campo em branco que precisa ser preenchido mostrará ponto de exclamação !
            epUsuario.Clear();

            // Nome do Usuário
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                epUsuario.SetError(txtNome, "Digite o campo " + lblNome.Text);

            // Login
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
                epUsuario.SetError(txtLogin, "Digite o campo " + lblLogin.Text);

            // Password
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
                epUsuario.SetError(txtSenha, "Digite o campo " + lblSenha.Text);

            if (string.IsNullOrWhiteSpace(txtSenhaConfirmar.Text))
                epUsuario.SetError(txtSenhaConfirmar, "Digite o campo " + lblSenhaConfirmar.Text);

            if (!string.IsNullOrWhiteSpace(txtSenha.Text) && !string.IsNullOrWhiteSpace(txtSenhaConfirmar.Text))
            {
                if (txtSenhaConfirmar.Text.Trim() != txtSenha.Text.Trim())
                    epUsuario.SetError(txtSenhaConfirmar, "Os campos " + lblSenha.Text + " e " + lblSenhaConfirmar.Text + " não conferem!");
            }

            // Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                epUsuario.SetError(txtEmail, "Digite o campo " + lblEmail.Text);

            if (epUsuario.HasErrors(this))  // função verifica se tem erro no controle dentro da Solution IS_Funcoes na Classe Extensoes
                return;

            // Faço verificações complementares
            if (txtLogin.Text.Length < 5)
            {
                MessageBox.Show("O Login precisa ter no mínimo 5 caracteres.", "Login!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtLogin.Focus();
                return;
            }

            if (txtSenha.Text.Length < 4)
            {
                MessageBox.Show("A Senha precisa ter no mínimo 4 caracteres.", "Senha!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtSenha.Focus();
                return;
            }

            try
            {
                // estância da classe
                // o que o usuário digitou e colocar no Entities
                Administrativo_Entities.Usuario usuario = new Administrativo_Entities.Usuario();
                usuario.PW_Nome = IS_Funcoes.SegurancaCripto.Criptografar(txtNome.Text);
                usuario.PW_Senha = IS_Funcoes.SegurancaCripto.Criptografar(txtSenha.Text);
                usuario.PW_Login = IS_Funcoes.SegurancaCripto.Criptografar(txtLogin.Text);
                usuario.PW_Email = IS_Funcoes.SegurancaCripto.Criptografar(txtEmail.Text);
                usuario.PW_DataCadastro = Convert.ToDateTime(txtDataCadastro.Text);
                if (rdbSim.Checked == true)
                {
                    usuario.PW_Ativo = true;
                }
                else
                {
                    usuario.PW_Ativo = false;
                }

                //int codigo = new Camadas_BLL.Cliente().Incluir(cliente);

                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    // Incluir
                    txtID.Text = new Administrativo_BLL.Usuario().Incluir(usuario).ToString();
                }
                else
                {
                    // Alterar
                    usuario.PW_ID = int.Parse(txtID.Text);
                    new Administrativo_BLL.Usuario().Alterar(usuario);
                }                

                HabilitarBotoesEdicao(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registro(int PW_ID = 0)
        {
            IS_Funcoes.Componentes.LimpaTodoConteudoTextBox(this.Controls);
            IS_Funcoes.Componentes.LimpaTodoConteudoMaskedTextBox(this.Controls);

            try
            {
                Administrativo_Entities.Usuario usuario = new Administrativo_BLL.Usuario().Pesquisar(PW_ID);
                if (usuario != null)
                {
                   PreencherCampos(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HabilitarBotoesEdicao(false);
        }

        private void HabilitarBotoesEdicao(bool modo)
        {
            HabilitarCampos(modo);

            btnIncluir.Enabled = !modo;
            btnAlterar.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text); // && chkManual.Checked;
            btnGravar.Enabled = modo;
            btnCancelar.Enabled = modo;
            btnExcluir.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text); 
            btnProcurar.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text);
            btnFechar.Enabled = !modo;

            btnPrimeiro.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text);
            btnAnterior.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text);
            btnProximo.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text);
            btnUltimo.Enabled = !modo && !string.IsNullOrWhiteSpace(txtID.Text);
        }


        private void HabilitarCampos(bool habilita)
        {            
            // txtEmpresaCodigo.Enabled = habilita && configuracao.Cfg_MultiEmpresas;
            // Não coloquei o txtDataCadastro e txtID pq nunca serão habilitados.   
            txtNome.Enabled = habilita;
            txtLogin.Enabled = habilita;
            txtSenha.Enabled = habilita;
            txtSenhaConfirmar.Enabled = habilita;
            txtEmail.Enabled = habilita;

            btnEye.Enabled = habilita;
            btnLimparCampos.Enabled = habilita;

            pnlAtivo.Enabled = habilita;
        }

        private void PreencherCampos (Administrativo_Entities.Usuario usuario)
        {
            txtNome.Text = IS_Funcoes.SegurancaCripto.Descriptografar(usuario.PW_Nome);
            txtSenha.Text = IS_Funcoes.SegurancaCripto.Descriptografar(usuario.PW_Senha);
            txtSenhaConfirmar.Text = IS_Funcoes.SegurancaCripto.Descriptografar(usuario.PW_Senha);
            txtLogin.Text = IS_Funcoes.SegurancaCripto.Descriptografar(usuario.PW_Login);
            txtDataCadastro.Text = usuario.PW_DataCadastro.ToString();
            txtID.Text = usuario.PW_ID.ToString();

            if (usuario.PW_Ativo == true)
                rdbSim.Checked = true;
            else
                rdbNao.Checked = false;

            txtEmail.Text = IS_Funcoes.SegurancaCripto.Descriptografar(usuario.PW_Email);
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

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
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
            txtSenha.UseSystemPasswordChar = false;
            txtSenhaConfirmar.UseSystemPasswordChar = false;
        }

        private void btnEye_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
            txtSenhaConfirmar.UseSystemPasswordChar = true;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            btnEye.Enabled = (txtSenha.Text.Length > 0);
            txtSenhaConfirmar.Enabled = (txtSenha.Text.Length > 0);

            if (!txtSenhaConfirmar.Enabled)
                txtSenhaConfirmar.Text = String.Empty;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            lblUltimoID.Text = txtID.Text;

            IS_Funcoes.Componentes.LimpaTodoConteudoTextBox(this.Controls);
            IS_Funcoes.Componentes.LimpaTodoConteudoMaskedTextBox(this.Controls);
            epUsuario.Clear();

            // Preencho a data
            txtDataCadastro.Text = DateTime.Now.ToString();

            HabilitarBotoesEdicao(true);

            txtNome.Focus();
        }

        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void btnLimpaCampos_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Componentes.LimpaTodoConteudoTextBox(this.Controls);
            epUsuario.Clear();
            txtNome.Select();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            {
                DialogResult dr = MessageBox.Show("Deseja realmente excluir este registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                try
                {
                    if (dr == DialogResult.Yes)
                    {
                        lblUltimoID.Text = (int.Parse(txtID.Text)).ToString();

                        new Administrativo_BLL.Usuario().Excluir(int.Parse(txtID.Text));

                        IS_Funcoes.Componentes.LimpaTodoConteudoTextBox(this.Controls);
                        IS_Funcoes.Componentes.LimpaTodoConteudoMaskedTextBox(this.Controls);

                        HabilitarBotoesEdicao(false);

                        Registro(BuscarNumeroAposExclusao(int.Parse(lblUltimoID.Text)));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro atual.\r\nDetalhes do erro: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            lblUltimoID.Text = txtID.Text;

            epUsuario.Clear();

            HabilitarBotoesEdicao(true);

            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtID.Text))
            //    intID = int.Parse(txtID.Text);

            IS_Funcoes.Componentes.LimpaTodoConteudoTextBox(this.Controls);
            IS_Funcoes.Componentes.LimpaTodoConteudoMaskedTextBox(this.Controls);
            epUsuario.Clear();

            if (int.Parse(lblUltimoID.Text) != 0) 
            {
                try
                {
                    Administrativo_Entities.Usuario usuario = new Administrativo_BLL.Usuario().Pesquisar(int.Parse(lblUltimoID.Text));
                    if (usuario != null)
                    {
                        PreencherCampos(usuario);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
             HabilitarBotoesEdicao(false);

            // ctrl E + D
         }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            try
            {
                string primeiroRegistro = IS_Funcoes.NavegacaoBD.PrimeiroRegistro("[logID]", "Login");
                if (!string.IsNullOrWhiteSpace(primeiroRegistro))
                {
                    Registro(int.Parse(primeiroRegistro));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    int numero = int.Parse(txtID.Text);

                    string registroAnterior = IS_Funcoes.NavegacaoBD.RegistroAnterior("[logID]", "Login", numero);

                    Registro(int.Parse(registroAnterior));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    int numero = int.Parse(txtID.Text);

                    string proximoRegistro = IS_Funcoes.NavegacaoBD.ProximoRegistro("[logID]", "Login", numero); 

                    Registro(int.Parse(proximoRegistro));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            try
            {
                string ultimoRegistro = IS_Funcoes.NavegacaoBD.UltimoRegistro("[logID]", "Login");
                if (!string.IsNullOrWhiteSpace(ultimoRegistro))
                {
                    Registro(int.Parse(ultimoRegistro));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            btnGravar.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private int BuscarNumeroAposExclusao(int PW_ID)
        {
            int retorno = 0;

            try
            {
                Administrativo_Entities.Usuario usuario = new Administrativo_BLL.Usuario().PesquisarRegistroAposExclusao(PW_ID);
                if (usuario != null)
                    retorno = usuario.PW_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            frmPesquisaUsuario frm = new frmPesquisaUsuario();
            frm.ShowDialog();

            if (!string.IsNullOrWhiteSpace(frm.Resultado))
            {
                Registro(int.Parse(frm.Resultado));
            }
        }
    }
}