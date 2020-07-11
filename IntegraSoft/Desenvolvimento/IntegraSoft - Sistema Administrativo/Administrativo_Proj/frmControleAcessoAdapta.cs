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
using System.Reflection;

namespace IS_SisAdmin
{
    public partial class frmControleAcessoAdapta : Form, ICatalogoFormulario
    {
        string strCaminho;

        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;

        public frmControleAcessoAdapta()
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

        private void frmControleAcessoAdapta_Load(object sender, EventArgs e)
        {
            /* Isto aqui é para desabilitar o botão X do formulário 
               Tem mais código de linhas em cima */
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int CountMenu = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, CountMenu, MF_BYCOMMAND);
        }

        private void LimpaTrv()
        {
            trvFormCtrl.Nodes.Clear();
        }

        private void PreenchePermissoes()
        {
            LimpaTrv();

            // Aqui vamos iniciar o Catalogo de Formulário
            var controlesParaFiltrar = new List<Type>
            {
                typeof(TextBox),
                typeof(MaskedTextBox),
                typeof(Button),
                typeof(ComboBox),
                typeof(CheckBox),
                typeof(TabPage),
                typeof(RadioButton),
                typeof(Bunifu.Framework.UI.BunifuFlatButton)
            };

            /* Agora nas 2 tabelas (CatalogoFormulario e CatalogoComponente)
               no campo Checked das respectivas tabela atualizo todos os registro para false
               Logo abaixo irei deletar os registro com false e os que cafoNomeMenuAcesso seja NULL               
               Na tabela CatalogoPermissaoFormulario não precisa deste campo Ckecked
            */

            Administrativo_Entities.CatalogoFormulario catalogoformulario = new Administrativo_Entities.CatalogoFormulario();
            new Administrativo_BLL.CatalogoFormulario().Update_CheckedFalso(catalogoformulario);

            Administrativo_Entities.CatalogoComponente catalogocomponente = new Administrativo_Entities.CatalogoComponente();
            new Administrativo_BLL.CatalogoComponente().Update_CheckedFalso(catalogocomponente);

            Administrativo_Entities.CatalogoPermissaoUsuario catalogopermissaousuario = new Administrativo_Entities.CatalogoPermissaoUsuario();
            //new Administrativo_BLL.CatalogoPermissaoUsuario().Update_CheckedFalso(catalogopermissaousuario);

            // Aqui começo a ler o projeto procurando todos os formulários existentes
            frmMenu fMenu = new frmMenu();
            MenuStrip msMenu = fMenu.Controls["mnuDesigner"] as MenuStrip;

            Type tipoForm = typeof(Form);
            foreach (Type tp in Assembly.GetExecutingAssembly().GetTypes())
            {
                // É formulário
                if (tipoForm.IsAssignableFrom(tp))
                {
                    // criando o objeto da classe ou instância
                    catalogoformulario = new Administrativo_Entities.CatalogoFormulario();
                    catalogoformulario.cafoNomeFormulario = tp.Name;
                    catalogoformulario.cafoNomeFullFormulario = tp.FullName;
                    catalogoformulario.cafoChecked = true;

                    // aqui crio o formulário
                    Type tipo = Type.GetType(catalogoformulario.cafoNomeFullFormulario);
                    if (tipo != null)
                    {
                        // crio a estância do formulário                       
                        Form frm = Activator.CreateInstance(tipo) as Form;

                        // Cria instância do formulário (para ele existir)
                        var icf = Activator.CreateInstance(tipo) as ICatalogoFormulario;

                        if (frm != null && icf != null)
                        {
                            if (icf.CatalogoFormulario == false)
                                continue; // na verdade é o loop ptz

                            catalogoformulario.cafoNomeAmigavel = frm.Text;

                            string NameDoMenu = null;
                            BuscaNomeItem_mnuDesigner(msMenu.Items, catalogoformulario.cafoNomeAmigavel, ref NameDoMenu);
                            catalogoformulario.cafoNomeMenuAcesso = NameDoMenu;

                            if (catalogoformulario.cafoNomeMenuAcesso == null) // Não encontrou Menu para clicar
                            {
                                continue; // na verdade é o loop ptz
                            }

                            // Insert ou Update no BD tabela Formulário
                            int idForm = new Administrativo_BLL.CatalogoFormulario().InsertUpdate(catalogoformulario);

                            // aqui pegamos os componentes do form
                            var controlesFiltrados = FiltrarControles(frm, controlesParaFiltrar);

                            foreach (var ctrl in controlesFiltrados)
                            {
                                catalogocomponente.cacoNomeAmigavel = string.Empty;
                                catalogocomponente.cacoIDForm = idForm;
                                catalogocomponente.cacoNomeComponente = ctrl.Name;
                                catalogocomponente.cacoChecked = true;

                                string tag = ctrl.Tag as string;
                                if (!string.IsNullOrWhiteSpace(tag))
                                {
                                    //aqui criamos uma matriz ou array
                                    string[] words = ctrl.Tag.ToString().Split('|');
                                    if (words != null)
                                    {
                                        // aqui quando TAG[0] for diferente de Ñ, então o campo aparecerá para dar permissão ou não ao usuário ao usuário
                                        if (words[0] != "Ñ")
                                        {
                                            if (!string.IsNullOrWhiteSpace(words[0]))
                                            {
                                                catalogocomponente.cacoNomeAmigavel = words[0];
                                            }
                                            else
                                            {
                                                catalogocomponente.cacoNomeAmigavel = "N.A.";
                                            }
                                            int idComp = new Administrativo_BLL.CatalogoComponente().InsertUpdate(catalogocomponente);
                                        }
                                    }
                                }
                            }
                            frm.Dispose(); // destroi o formulário
                        }
                    }
                    else
                    {
                        MessageBox.Show("Algum erro acontenceu. Avise o Responsávelo pelo Sistema!", "Catalogo de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            tipoForm = null;

            /* Agora nas 2 tabelas (CatalogoFormulario e CatalogoComponente) 
               deleto todos os registro que campo Checked = false nas respectivas tabela 
               Na tabela CatalogoPermissaoUsuario faço inner join para deletar o que esta relacionado com a tabale CatalogoCompnente Checked = 0
            */

            catalogopermissaousuario = new Administrativo_Entities.CatalogoPermissaoUsuario();
            new Administrativo_BLL.CatalogoPermissaoUsuario().Delete_CheckedFalso(catalogopermissaousuario);

            catalogocomponente = new Administrativo_Entities.CatalogoComponente();
            new Administrativo_BLL.CatalogoComponente().Delete_CheckedFalso(catalogocomponente);

            catalogoformulario = new Administrativo_Entities.CatalogoFormulario();
            new Administrativo_BLL.CatalogoFormulario().Delete_CheckedFalso(catalogoformulario);

            // Preenche o Grid
            List<Administrativo_Entities.CatalogoFormulario> listaCF = new Administrativo_BLL.CatalogoFormulario().LerConteudo();
            List<Administrativo_Entities.CatalogoComponente> listaCO = new Administrativo_BLL.CatalogoComponente().LerConteudo();

            foreach (var cf in listaCF)
            {
                // aqui mostramos os nós do formulário

                TreeNode node = trvFormCtrl.Nodes.Add(cf.cafoNomeFormulario, cf.cafoNomeAmigavel);
                node.ForeColor = Color.Blue;

                var listaComp = listaCO.Where(c => c.cacoIDForm == cf.cafoID).ToList();

                // aqui mostramos o nós do controle
                foreach (var co in listaComp)
                {
                    node.Nodes.Add(co.cacoNomeComponente, co.cacoNomeAmigavel);
                }
            }

            //picAguarde.Visible = false;
            trvFormCtrl.ExpandAll();
            panel1.Visible = true;
        }

        private static IEnumerable<Control> FiltrarControles(Control container, IEnumerable<Type> controlesParaFiltrar)
        {
            var controlesFiltrados = container.Controls.Cast<Control>();

            return controlesFiltrados.SelectMany(ctrl => FiltrarControles(ctrl, controlesParaFiltrar))
                                     .Concat(controlesFiltrados)
                                     .Where(ctl => controlesParaFiltrar.Any(t => ctl.GetType() == t));
        }

        private void ChecarNoTreeView(TreeNode no, Boolean checado)
        {
            foreach (TreeNode item in no.Nodes)
            {
                item.Checked = checado;

                if (item.Nodes.Count > 0)
                    ChecarNoTreeView(item, checado);
            }
        }

        private void trvFormCtrl_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ChecarNoTreeView(e.Node, e.Node.Checked);
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fazer a adaptação dos direitos de Usuários?\r\n\r\nUma vez iniciado o processo não poderá ser cancelado.\r\n\r\nPosso processeguir?", "Adaptação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                btnProcessar.Visible = false;
                btnSair.Location = new Point(164, 483);
                lblProcessando.Visible = true;
                PreenchePermissoes();
                lblProcessando.Visible = false;

                // acho o tamanho da tela
                int c = Screen.PrimaryScreen.BitsPerPixel;
                int w = Screen.PrimaryScreen.Bounds.Width; // Left
                int h = Screen.PrimaryScreen.Bounds.Height; // Top

                // dimensiono meu formulário
                this.Width = 480;
                this.Height = 570;

                // centralizo
                this.Left = (w - this.Width) / 2;
                this.Top = ((h - this.Height) / 2);
                this.Top = this.Top - (this.Top / 2);

                //this.Location = new Point(this.Left, this.Top);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            this.Close();
            //GC.Collect();
        }

        public void BuscaNomeItem_mnuDesigner(ToolStripItemCollection mnuDesigner, string NomeAmigavel, ref string NameDoMenu)
        {
            foreach (ToolStripMenuItem itemMP in mnuDesigner)
            {
                //ToolStripMenuItem itemMenuLiberado = new ToolStripMenuItem(itemMP.Text, null, Item_Click);
                //tsAcessoUsuario.DropDownItems.Add(itemMenuLiberado);

                if (itemMP.Text == NomeAmigavel)
                {
                    NameDoMenu = itemMP.Name;
                    //MessageBox.Show("deu certO, achamos o menu " + itemMP.Name);
                    strCaminho = string.Empty;
                    break;
                }

                // ctrl E + D identa

                strCaminho = strCaminho + itemMP.Text + " / ";
                if (itemMP.HasDropDownItems)
                {
                    BuscaNomeItem_mnuDesigner(itemMP.DropDownItems, NomeAmigavel, ref NameDoMenu);
                }
            }
        }

        private void trvFormCtrl_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}



