using IS_Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace IS_SisAdmin
{
    public partial class frmConfigBD : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;

        string nomeArquivoXml = @"C:\\IntegraSoft\\ConexaoBD\config.xml";

        public frmConfigBD()
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

        private void FrmConfigBD_Load(object sender, EventArgs e)
        {
            /* Isto aqui é para desabilitar o botão X do formulário 
               Tem mais código de linhas em cima */
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int CountMenu = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, CountMenu, MF_BYCOMMAND);

            this.Height = 300;
            IS_Funcoes.Componentes.TrataCorCampos(this.Controls);

            try
            {
                if (!File.Exists(nomeArquivoXml))
                {
                    MessageBox.Show("Arquivo de Configuração do Banco de Dados não encontrado!", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(nomeArquivoXml);

                    XmlNode nomeConexao = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/NomeConexao");
                    if (nomeConexao != null)
                        txtNomeConexao.Text = IS_Funcoes.SegurancaCripto.Descriptografar(nomeConexao.InnerText);

                    XmlNode servidorInstancia = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/ServidorInstancia");
                    if (servidorInstancia != null)
                        txtServidorInstancia.Text = IS_Funcoes.SegurancaCripto.Descriptografar(servidorInstancia.InnerText);

                    XmlNode bancoDados = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/BancoDados");
                    if (bancoDados != null)
                        txtBD.Text = IS_Funcoes.SegurancaCripto.Descriptografar(bancoDados.InnerText);

                    XmlNode login = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/Login");
                    if (login != null)
                        txtLogin.Text = IS_Funcoes.SegurancaCripto.Descriptografar(login.InnerText);

                    XmlNode senha = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/Senha");
                    if (senha != null)
                    {
                        mskSenha.Text = IS_Funcoes.SegurancaCripto.Descriptografar(senha.InnerText);
                        mskSenhaConfirmar.Text = IS_Funcoes.SegurancaCripto.Descriptografar(senha.InnerText);
                    }

                    XmlNode timeout = xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/TimeOut");
                    if (timeout != null)
                        mskTimeOut.Text = IS_Funcoes.SegurancaCripto.Descriptografar(timeout.InnerText);

                }
            }
            catch (XmlException xmlEx)
            {
                //string msg = RetornaMsgXMLException(xmlEx);
                string msg = IS_Funcoes.Mensagens.RetornaMsgXMLException(xmlEx);
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //string msg = RetornaMsgException(ex);
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mskSenha_TextChanged(object sender, EventArgs e)
        {
            btnEye.Enabled = (mskSenha.Text.Length > 0);
            if (string.IsNullOrWhiteSpace(mskSenha.Text))
            {
                mskSenhaConfirmar.Text = string.Empty;
            }    
            mskSenhaConfirmar.Enabled = (mskSenha.Text.Length > 0);
        }
             
        private void btnEye_MouseDown(object sender, MouseEventArgs e)
        {
            mskSenha.UseSystemPasswordChar = false;
            mskSenhaConfirmar.UseSystemPasswordChar = false;
        }

        private void btnEye_MouseUp(object sender, MouseEventArgs e)
        {
            mskSenha.UseSystemPasswordChar = true;
            mskSenhaConfirmar.UseSystemPasswordChar = true;
        }

        private void mskTimeOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                {
                    MessageBox.Show("Somente número é permitido neste campo", "TimeOut!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    e.Handled = true;
            }         
        }

        private void frmConfigBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void btnInstancia_Click(object sender, EventArgs e)
        {
            btnInstancia.Enabled = false;
            btnSalvar.Enabled = false;
            this.Height = 500;
            lblInstancia.Text = "Buscando Instâncias, Por favor aguarde...";
            dgvInstancia.DataSource = null;
            SqlDataSourceEnumerator sqls = SqlDataSourceEnumerator.Instance;
            Refresh();
            dgvInstancia.DataSource = sqls.GetDataSources();
            if (dgvInstancia.Rows.Count == 0)
            {
                lblInstancia.Text = "Não consegui encontrar nenhuma instância. Por favor avisar o TI";
            }
            else
            {
                lblInstancia.Text = "Busca Concluida";
            }
        }

        private void dgvInstancia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInstancia.Enabled = true;
            btnSalvar.Enabled = true;
            txtServidorInstancia.Text = Convert.ToString(dgvInstancia.Rows[e.RowIndex].Cells[0].Value) + "\\" + dgvInstancia.Rows[e.RowIndex].Cells[1].Value;
            this.Height= 300;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblInstancia.ForeColor= lblInstancia.ForeColor == Color.Red ? Color.Black : Color.Red;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Se tiver algum campo em branco que precisa ser preenchido mostrará ponto de exclamação !
            epConfigBD.Clear();

            // Este nunca acontecerá pois o valor já esta dentro do txt e esta disabled, coloca aqui somente como precaução
            if (string.IsNullOrWhiteSpace(txtNomeConexao.Text))
                epConfigBD.SetError(txtNomeConexao, "Digite o campo " + lblNomeConexao.Text);

            // Data Source
            if (string.IsNullOrWhiteSpace(txtServidorInstancia.Text))
                epConfigBD.SetError(txtServidorInstancia, "Digite o campo " + lblServidorInstancia.Text);

            // Initial Catalog
            if (string.IsNullOrWhiteSpace(txtBD.Text))
                epConfigBD.SetError(txtBD, "Digite o campo " + lblBD.Text);

            // User ID
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
                epConfigBD.SetError(txtLogin, "Digite o campo " + lblLogin.Text);

            // Password
            if (string.IsNullOrWhiteSpace(mskSenha.Text))
                epConfigBD.SetError(mskSenha, "Digite o campo " + lblSenha.Text);

            if (string.IsNullOrWhiteSpace(mskSenhaConfirmar.Text))
                epConfigBD.SetError(mskSenhaConfirmar, "Digite o campo " + lblSenhaConfirmar.Text);

            if (!string.IsNullOrWhiteSpace(mskSenha.Text) && !string.IsNullOrWhiteSpace(mskSenhaConfirmar.Text))
            {
                if (mskSenhaConfirmar.Text.Trim() != mskSenha.Text.Trim())
                    epConfigBD.SetError(mskSenhaConfirmar, "Os campos " + lblSenha.Text + " e " + lblSenhaConfirmar.Text + " não conferem!");
            }

            if (string.IsNullOrWhiteSpace(mskTimeOut.Text))
            {
                epConfigBD.SetError(mskTimeOut, lblTimeOut.Text + ", tem que ter um valor.");
            }

            if (epConfigBD.HasErrors(this))  // função verifica se tem erro no controle dentro da Solution IS_Funcoes na Classe Extensoes
                return;

            // Para verificar se conexão ao BD foi feita com sucesso!
            bool ConexaoOK = true;

            try
            {
                // Inicio da criação do arquivo XML dentro do ..\.

                // Cria Documento
                XmlTextWriter writer = new XmlTextWriter(@"C:\\IntegraSoft\\ConexaoBD\config.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                // cria Elemento
                writer.WriteStartElement("Configuracoes");

                // cria nó
                writer.WriteStartElement("ConexaoBD");

                // cria elemento
                writer.WriteStartElement("NomeConexao");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(txtNomeConexao.Text.Trim()));
                writer.WriteEndElement();

                writer.WriteStartElement("ServidorInstancia");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(txtServidorInstancia.Text.Trim()));
                writer.WriteEndElement();

                writer.WriteStartElement("BancoDados");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(txtBD.Text.Trim()));
                writer.WriteEndElement();

                writer.WriteStartElement("Login");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(txtLogin.Text.Trim()));
                writer.WriteEndElement();

                writer.WriteStartElement("Senha");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(mskSenha.Text.Trim()));
                writer.WriteEndElement();

                writer.WriteStartElement("TimeOut");
                writer.WriteString(IS_Funcoes.SegurancaCripto.Criptografar(mskTimeOut.Text.Trim()));
                writer.WriteEndElement();

                // fecha nó
                writer.WriteEndElement();

                // fecha Elemento
                writer.WriteEndElement();

                // fecha Documento
                writer.WriteEndDocument();

                // fecha arquivo xml
                writer.Close();

                // vamos testar a conexão com o BD
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    conn.Open();

                    /* Vamos verificar se existe a tabela e se está vazia
                       Se não existir iremos gravar na mão usuário e senha */

                    int Qtde_Usr = new Administrativo_BLL.Usuario().Verifica_Qtd_Usuarios();

                    if (Qtde_Usr == -1) // BD vazio
                    {

                        Administrativo_Entities.Usuario usuario = new Administrativo_Entities.Usuario();
                        usuario.PW_Nome = IS_Funcoes.SegurancaCripto.Criptografar("Administrador");
                        usuario.PW_Login = IS_Funcoes.SegurancaCripto.Criptografar("IS.ADMIN");
                        usuario.PW_Senha = IS_Funcoes.SegurancaCripto.Criptografar("c#2019-IS");
                        usuario.PW_Email = IS_Funcoes.SegurancaCripto.Criptografar("contato@integrasoft.com.br");
                        usuario.PW_DataCadastro = DateTime.Now;
                        usuario.PW_Ativo = true;

                        new Administrativo_BLL.Usuario().Incluir(usuario);
                    }

                    // (65) + char(35) + char(50) + char(48) + char(49) + char(57) + char(45) + char(83) + char(66));
                    MessageBox.Show("Conexão com banco de dados efetuada com sucesso!", "Testando Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Arquivo XML Gravado com sucesso!", "XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Tag = "btnSalvar";
                this.Close();

            }
            catch (SqlException sqlEx)
            {
                ConexaoOK = false;
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                // throw new Exception(msg);
                MessageBox.Show(msg.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException xmlEx)
            {
                ConexaoOK = false;
                //string msg = RetornaMsgXMLException(xmlEx);
                string msg = IS_Funcoes.Mensagens.RetornaMsgXMLException(xmlEx);
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ConexaoOK = false;
                //string msg = RetornaMsgException(ex);
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (ConexaoOK == false)
                {
                    if (File.Exists(nomeArquivoXml))
                    {
                        File.Delete(nomeArquivoXml);
                    }
                }
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            btnSair.Enabled = false;
            this.Close();
        }
    }
}

