using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_SisAdmin
{
    public partial class frmCliFor : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;

        public frmCliFor()
        {
            InitializeComponent();
        }

        private void FrmCliFor_Load(object sender, EventArgs e)
        {
            // Criando lista
            try
            {
                List<Administrativo_Entities.CatalogoFormulario> listaCF = new Administrativo_BLL.CatalogoFormulario().RetornaListaAcessoMenu(Administrativo_Entities.Global.Usuario.PW_ID);

                List<Administrativo_Entities.CatalogoComponente> listaCC = new Administrativo_BLL.CatalogoComponente().RetornaListaAcessoNegadoPermissaoComponente(Administrativo_Entities.Global.Usuario.PW_ID, this.Name);
                if (listaCC != null)
                {
                    foreach (var item in listaCC)
                    {
                        Control ctrl = this.Controls.Find(item.cacoNomeComponente, true)[0];
                        MessageBox.Show(item.cacoNomeComponente);
                        ctrl.Enabled = false;
                    }
                }

                //MontarMenuAcessoUsuario(mnuDesigner.Items, Administrativo_Entities.Global.Usuario.PW_ID);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // preenchendo o cbo
            List<Administrativo_Entities.EstadoCivil> lstEstadoCivil = new Administrativo_BLL.EstadoCivil().CarregaComboBox();
            cboEstadoCivil.ValueMember = "escID";
            cboEstadoCivil.DisplayMember = "escDescricao";
            cboEstadoCivil.DataSource = lstEstadoCivil;
            // posiciona no primeiro item do cbo
            cboEstadoCivil.SelectedValue = -1;
        }

        private void ChkSuframa_Click(object sender, EventArgs e)
        {
            txtRegiaoSuframa.Enabled = chkSuframa.Checked;
        }

        private void ChkSuframa_CheckedChanged(object sender, EventArgs e)
        {
            txtRegiaoSuframa.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            btnSair.Enabled = false;
            this.Close();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            frmPesquisaUsuario frm = new frmPesquisaUsuario();
            frm.ShowDialog();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            frmPesquisaUsuario frm = new frmPesquisaUsuario();
            frm.ShowDialog();
        }

        private void rdbFisica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboComoNosConheceu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNomeRazao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
