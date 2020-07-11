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
using IS_Funcoes;
using SmartSolutions.Controls;

namespace IS_SisAdmin
{
    public partial class frmControleAcesso : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;

        DataTable dtGrid;
        int IndiceColunaGridAnterior = 1;

        public frmControleAcesso()
        {
            InitializeComponent();
        }

        private void frmControleAcesso_Load(object sender, EventArgs e)
        {
            IS_Funcoes.Componentes.TrataCorCampos(this.Controls);

            // aqui preencho Grid com todos os Usuários Cadastrados
            //this.dgvUsuario.DefaultCellStyle.Font = new Font("Tahoma", 15);
            this.dgvUsuario.DefaultCellStyle.ForeColor = Color.Blue;
            this.dgvUsuario.DefaultCellStyle.BackColor = Color.Beige;
            this.dgvUsuario.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dgvUsuario.DefaultCellStyle.SelectionBackColor = Color.Black;

            #region UPPER Textos
            //txtConteudo.CharacterCasing = CharacterCasing.Upper;
            #endregion

            lblNomeUsuario.Visible = false;
            lblLogin.Visible = false;

            ControlaBtn(false);
            PreencheUsuario();
        }

        private void ControlaBtn(bool MostraDireitos)
        {
            if (MostraDireitos)
            {
                this.Width = 1000;
                this.Height = 570;
            }
            else
            {
                this.Width = 545;
                this.Height = 570;
            }

            pnlUsuario.Enabled = (!MostraDireitos);
            pnlDireito.Enabled = (MostraDireitos);
        }

        private void PreencheUsuario()
        {
            try
            {
                string strWhere = "";

                LimpaGrid();

                dtGrid = new Administrativo_BLL.Usuario().CarregarGrid_DT(strWhere);

                dgvUsuario.AutoGenerateColumns = false;
                dgvUsuario.RowsDefaultCellStyle.BackColor = Color.White;
                dgvUsuario.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;

                dtGrid.DefaultView.Sort = "PW_Nome";
                dgvUsuario.DataSource = dtGrid.DefaultView;

                dgvUsuario.Focus();
            }
            catch (Exception ex)
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = ex.Message;
            }
        }

        private void LimpaGrid()
        {
            dgvUsuario.DataSource = null;
        }

        private void LimpaTrv()
        {
            trvPermissoes.Nodes.Clear();
        }

        private void PreenchePermissoes()
        {
            LimpaTrv();
            picAguarde.Visible = true;
            this.Refresh();

            try
            {
                int idUsuario = int.Parse(dgvUsuario.CurrentRow.Cells["PW_ID"].Value.ToString());
                List<Administrativo_Entities.CatalogoFormulario> listaCF = new Administrativo_BLL.CatalogoFormulario().RetornarTodosFormulariosComponentes();
                List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU = new Administrativo_BLL.CatalogoPermissaoUsuario().PreencheAcessoPermissaoUsuario(idUsuario);

                // aqui adicionamos os nós dos formulários no treeview
                TriStateTreeNode rootNode = new TriStateTreeNode("Formulários/Componentes");
                rootNode.IsContainer = true;

                // adiciona os formulários (pai)
                foreach (var cf in listaCF)
                {
                    TriStateTreeNode node = new TriStateTreeNode(cf.cafoNomeAmigavel, 0, 1);
                    node.IsContainer = true;
                    node.Name = cf.cafoID.ToString();
                    rootNode.Nodes.Add(node);
                }

                TriStateTreeNode folder = new TreeNode() as TriStateTreeNode;
                int i = 0;
                // para cada formulário, adiciona os componentes 
                foreach (TriStateTreeNode rtNode in rootNode.Nodes)
                {
                    if (rtNode.PrevNode == null)
                        folder = rootNode.FirstNode as TriStateTreeNode;
                    else
                        folder = folder.NextNode as TriStateTreeNode;

                    foreach (var co in listaCF[i].CatalogoComponente)
                    {
                        TriStateTreeNode itemNode = new TriStateTreeNode( co.cacoNomeAmigavel, 2, 2);
                        itemNode.IsContainer = true;
                        itemNode.Name = listaCF[i].cafoID.ToString() + "-" + co.cacoID.ToString();

                        folder.Nodes.Add(itemNode);
                    }

                    i++;
                }

                trvPermissoes.SuspendLayout();
                trvPermissoes.Nodes.Add(rootNode);
                trvPermissoes.ResumeLayout();

                if (listaCPU != null)
                {
                    var listaCPUPermitida = listaCPU.Where(c => c.capeusPermissao == true).ToList();
                    if (listaCPUPermitida != null)
                    {
                        foreach (var cpuTrue in listaCPUPermitida)
                        {
                            string nodeName = cpuTrue.cacoIDForm.ToString() + "-" + cpuTrue.capeusIDComponente.ToString();

                            foreach (TriStateTreeNode node in rootNode.Nodes)
                            {
                                foreach (TriStateTreeNode item in node.Nodes)
                                {
                                    if (item.Name == nodeName)
                                        item.Checked = cpuTrue.capeusPermissao;
                                }
                            }
                        }
                    }
                }

                picAguarde.Visible = false;
                trvPermissoes.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro.\n\nDetalhes do erro: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IEnumerable<Control> FiltrarControles(Control container, IEnumerable<Type> controlesParaFiltrar)
        {
            var controlesFiltrados = container.Controls.Cast<Control>();

            return controlesFiltrados.SelectMany(ctrl => FiltrarControles(ctrl, controlesParaFiltrar))
                                     .Concat(controlesFiltrados)
                                     .Where(ctl => controlesParaFiltrar.Any(t => ctl.GetType() == t));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // verificar para alterar para tristateTreeView
            int nosChecados = IS_Funcoes.Func_TreeView.VerificarSeTemNoChecado(trvPermissoes.Nodes);

            if (nosChecados != 0)
            {
                string message = "Deseja abandonar as alterações?";
                string caption = "Alterações de Direitos";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ControlaBtn(false);
                }
            }
            else
            {
                ControlaBtn(false);
            }

            lblNomeUsuario.Visible = false;
            lblLogin.Visible = false;
            LimpaTrv();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (trvPermissoes.Nodes.Count == 0)
            {
                MessageBox.Show("Nenhuma permissão foi selecionada!", "Para SALVAR pelo menos UMA opção precisa ser marcada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int idUsuarioGrid = int.Parse(dgvUsuario.CurrentRow.Cells["PW_ID"].Value.ToString());
                bool ok = new Administrativo_BLL.CatalogoPermissaoUsuario().AtualizaAcessoPermissaoUsuario(idUsuarioGrid, trvPermissoes);
                                
                ControlaBtn(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro.\n\nDetalhes do erro: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //    textBox1.Text = dgvForms.Rows[e.RowIndex].Cells["Id"].Value.ToString();

            if (e.RowIndex != -1)
            {
                //if (e.ColumnIndex == 1)
                //{
                //}
                //else if (e.ColumnIndex == 2)
                //{
                //    txtPesquisa.Text = string.Empty;
                //}
            }
            //else if (e.ColumnIndex == 1)
            //{
            //    MessageBox.Show("Coluna 1");
            //}
            //else if (e.ColumnIndex == 2)
            //{
            //    MessageBox.Show("Coluna 2");
            //}
            //else
            //{
            //    MessageBox.Show("Teste");
            //}
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //dtGrid.DefaultView.RowFilter = "PW_Nome LIKE '%" + txtPesquisa.Text + "%'";     // values that contain 'jo'
            if (dgvUsuario.SortedColumn.Name == "PW_Nome")
                dtGrid.DefaultView.RowFilter = "PW_Nome LIKE '" + txtPesquisa.Text + "%'";
            else if (dgvUsuario.SortedColumn.Name == "PW_Login")
                dtGrid.DefaultView.RowFilter = "PW_Login LIKE '" + txtPesquisa.Text + "%'";
            dgvUsuario.DataSource = dtGrid.DefaultView;
        }

        private void dgvUsuario_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && IndiceColunaGridAnterior != e.ColumnIndex)
            {
                txtPesquisa.Text = string.Empty;
                txtPesquisa.Focus();
                IndiceColunaGridAnterior = e.ColumnIndex;
            }
        }

        //private void ChecarNoTreeView(TreeNode no, Boolean checado)
        //{
        //    foreach (TreeNode item in no.Nodes)
        //    {
        //        item.Checked = checado;

        //        if (item.Nodes.Count > 0)
        //        {
        //            MessageBox.Show("Usuário caso veja esta mensagem entrar em contato URGENTE com o pessoal do TI.");
        //            ChecarNoTreeView(item, checado);
        //        }
        //    }
        //}

        private void btnDireitos_Click(object sender, EventArgs e)
        {
            ControlaBtn(true);
            trvPermissoes.Nodes.Clear();
            PreenchePermissoes();

            int idUsuario = int.Parse(dgvUsuario.CurrentRow.Cells["PW_ID"].Value.ToString());
            lblNomeUsuario.Text = dgvUsuario.CurrentRow.Cells["PW_ID"].Value.ToString() + " - Nome Usuário:  " + dgvUsuario.CurrentRow.Cells["PW_Nome"].Value.ToString();
            lblLogin.Text = "Login:  " + dgvUsuario.CurrentRow.Cells["PW_Login"].Value.ToString();

            lblNomeUsuario.Visible = true;
            lblLogin.Visible = true;

            List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU = new Administrativo_BLL.CatalogoPermissaoUsuario().PreencheAcessoPermissaoUsuario(idUsuario);
            if (listaCPU != null)
            {
                // aqui estamos prenchendo true ou false de acordo com o BD
                foreach (var cpu in listaCPU)
                {
                    //TriStateTreeNode[] tn = trvPermissoes.Nodes.Find(cpu.cacoIDForm + "-" + cpu.capeusIDComponente.ToString(), true) as TriStateTreeNode[];
                    //TreeNode[] tn = trvPermissoes.Nodes.Find(cpu.cacoIDForm + "-" + cpu.capeusIDComponente.ToString(), true);

                    //TreeNode[] tn = trvPermissoes.Nodes.Find(cpu.cacoIDForm + "-" + cpu.capeusIDComponente.ToString(), true);
                    //if (tn.Length > 0)
                    //{
                    //    tn[0].Checked = cpu.capeusPermissao;
                    //}


                    //MarcarNoTreeView(trvPermissoes.Nodes, cpu.cacoIDForm.ToString() + "-" + cpu.capeusIDComponente.ToString(), cpu);






                }

                //    // Marcar nós Pai de acordo com os nós filhos 
                //    // Se todos os nós filhos tiverem true marca o Pai com true)
                //    foreach (TreeNode noPai in trvPermissoes.Nodes)
                //    {
                //        int qtdeNoChecado = 0;
                //        int qtdeNoFilho = noPai.GetNodeCount(true);

                //        foreach (TreeNode noFilho in noPai.Nodes)
                //        {
                //            if (noFilho.Checked == true)
                //                qtdeNoChecado++;
                //        }

                //        if (qtdeNoFilho == qtdeNoChecado)
                //        {
                //            noPai.Checked = true;
                //        }
                //        else
                //        {
                //            /*
                //            Tabela de cores
                //            https://celke.com.br/artigo/tabela-de-cores-html-nome-hexadecimal-rgb
                //            */

                //            if (qtdeNoChecado > 0)
                //            {
                //                // Permissão Parcial
                //                noPai.ForeColor = Cor_PermissaoParcial;
                //            }
                //            else
                //            {
                //                // Sem Permissão
                //                noPai.ForeColor = Cor_SemPermissao;
                //                noPai.Collapse();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    // TreeNode noPai = new TreeNode();

                //    // Não existe nenhum registro do usuário na tabela CatalogoPermissaoUsuario
                //    foreach (TreeNode noPai in trvPermissoes.Nodes)
                //    {
                //        /*
                //        Tabela de cores
                //        https://celke.com.br/artigo/tabela-de-cores-html-nome-hexadecimal-rgb
                //        */

                //        // Sem Permissão
                //        noPai.ForeColor = Cor_SemPermissao;
                //        noPai.Collapse();
                //    }
            }
        }
    }
}
