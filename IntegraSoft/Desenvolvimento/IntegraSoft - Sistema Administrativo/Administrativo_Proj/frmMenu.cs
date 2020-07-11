using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using IS_Funcoes;

namespace IS_SisAdmin
{
    public partial class frmMenu : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => false;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            // Desabilito os menus
            mnuDesigner.Visible = false;

            // Verifico o caminho do Banco de Dados
            VerificaCaminhoBD();

            // Chamo formulário Login de Usuário
            frmLogin frmlogin = new frmLogin();
            frmlogin.ShowDialog();

            try
            {
                
                if (Administrativo_Entities.Global.Usuario.PW_ID != 4) // Administrador
                {
                    List<Administrativo_Entities.CatalogoFormulario> listaCF = new Administrativo_BLL.CatalogoFormulario().RetornaListaAcessoMenu(Administrativo_Entities.Global.Usuario.PW_ID);

                    //MontarMenuAcessoUsuario(mnuDesigner.Items, Administrativo_Entities.Global.Usuario.PW_ID);
                    MontarMenuAcessoUsuario(mnuDesigner.Items, listaCF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mnuDesigner.Visible = true;
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmConfigBD(), this);
        }

        private void senhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmControleAcesso(), this);
        }

        // Verificando se existe o XML do Banco de Dados
        private void VerificaCaminhoBD()
        {
            string nomeArquivoXml = @".\config.xml";

            if (!File.Exists(nomeArquivoXml))
            {
                frmConfigBD frmconfigbd = new frmConfigBD();
                // aqui chamo o form
                frmconfigbd.ShowDialog();
                if (frmconfigbd.Tag.ToString() == "btnSair")
                {
                    Application.Exit();
                }
            }
        }

        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmUsuario(), this);
        }

        private void adaptaPermissãoDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ToolStripMenuItem parent = (ToolStripMenuItem)item.OwnerItem;
            parent = (ToolStripMenuItem)item.OwnerItem.OwnerItem;

            ToolStrip parent2 = item.GetCurrentParent();

            IS_Funcoes.Formulario.AbrirForm(new frmControleAcessoAdapta(), this);
        }

        private void ActivateMenus(ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem item in items)
            {
                item.Enabled = false;
                //ActivateMenus(item.DropDown.Parent);
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCliFor frmclifor = new frmCliFor();
            //frmclifor.MdiParent = this;
            //frmclifor.Show();
            IS_Funcoes.Formulario.AbrirForm(new frmCliFor(), this);
        }

        //public void MontarMenuAcessoUsuario(ToolStripItemCollection mnuDesigner, int IdUsuario)
        public void MontarMenuAcessoUsuario(ToolStripItemCollection mnuDesigner, List<Administrativo_Entities.CatalogoFormulario> listaCF)
        {
            foreach (ToolStripMenuItem itemMP in mnuDesigner)
            {
                if (!itemMP.HasDropDownItems)
                {
                    //bool habilitado = new Administrativo_BLL.CatalogoFormulario().RetornaAcessoMenu(itemMP.Name, IdUsuario);
                    if (listaCF == null)
                    {
                        itemMP.Enabled = false;
                    }
                    else
                    {
                        var cf = listaCF.FirstOrDefault(c => c.cafoNomeMenuAcesso == itemMP.Name);
                        itemMP.Enabled = (cf != null);
                    }
                }

                // ctrl E + D identa
                //if (itemMP.HasDropDown)
                if (itemMP.HasDropDownItems)
                {
                    MontarMenuAcessoUsuario(itemMP.DropDownItems, listaCF);
                }
            }
        }

        // aqui seria os "filhos" do menu
        public void AtribuirMenuAcessoUsuario(MenuStrip menuAcessoUsuario, ToolStripMenuItem tsAcessoUsuario)
        {
            for (int i = 0; i < tsAcessoUsuario.DropDownItems.Count;)
            {
                menuAcessoUsuario.Items.Add(tsAcessoUsuario.DropDownItems[i]);
            }
        }


        private void Item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (item.HasDropDownItems == false)
                {
                    if (item.Text == "C&lientes")
                    {
                        this.ClientesToolStripMenuItem_Click(item, new EventArgs());
                    }

                }
            }
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //ToolStripMenuItem parent = (ToolStripMenuItem)item.OwnerItem;

            //ToolStrip teste = item.GetCurrentParent();

            //ActivateMenus(teste.Items);
            //frmCliFor frmclifor = new frmCliFor();
            //frmclifor.MdiParent = this;
            //frmclifor.Show();
            IS_Funcoes.Formulario.AbrirForm(new frmCliFor(), this);
        }

        private void clienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmCliFor frmclifor = new frmCliFor();
            //frmclifor.MdiParent = this;
            //frmclifor.Show();
            IS_Funcoes.Formulario.AbrirForm(new frmCliFor(), this);
        }

        private void acessoAoBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmConfigBD(), this);
        }

        private void adaptaçãoPermissãoDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmControleAcessoAdapta(), this);
        }

        private void controleDePermisãoDeUsuároToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmControleAcesso(), this);
        }

        private void loginDoUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void manutençãoDoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuracaoDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmConfigBD(), this);
        }

        private void controleDeAcessoAdaptaçãoDosDireitosDoUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmControleAcessoAdapta(), this);
        }

        private void controleDeAcessoDireitosDoUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmControleAcesso(), this);
        }

        private void siteIntegraSoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "http://www.uol.com.br/";
            System.Diagnostics.Process.Start(target);
        }

        private void whatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://chat.whatsapp.com/GfSKzPyNPyqJuMLy4iw99K";
            System.Diagnostics.Process.Start(target);
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frmUsuario(), this);
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IS_Funcoes.Formulario.AbrirForm(new frm_ModeloMenuVertical(), this);
        }
    }
}
