using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_SisAdmin
{
    public partial class frmPesquisaUsuario : Form, ICatalogoFormulario
    {
        // vai aparecer dentro dos direitos
        public bool CatalogoFormulario => true;
        public string Resultado { get; set; }

        public frmPesquisaUsuario()
        {
            InitializeComponent();
        }

        private void frmPesquisa_Load(object sender, EventArgs e)
        {
            IS_Funcoes.Componentes.TrataCorCampos(this.Controls);

            #region UPPER Textos
            //txtConteudo.CharacterCasing = CharacterCasing.Upper;
            #endregion

            //cboProcurarPor.Items.Add("Código");
            cboProcurarPor.Items.Add("Nome");
            cboProcurarPor.Items.Add("Login");
            cboProcurarPor.SelectedIndex = 0;
            lblMensagem.Text = "";
            lblMensagem.Visible = true;

            txtConteudo.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string strWhere = "";
                string strTexto = "";

                LimpaGrid();

                switch (cboProcurarPor.SelectedIndex)
                {
                    //case 0:
                    //    if (!string.IsNullOrWhiteSpace(txtConteudo.Text))
                    //        strWhere = "([logID] = " + txtConteudo.Text + ")";
                    //    break;

                    case 0:
                        if (!string.IsNullOrWhiteSpace(txtConteudo.Text))
                        {
                            strTexto = IS_Funcoes.SegurancaCripto.Criptografar(txtConteudo.Text);
                            strTexto = IS_Funcoes.TratarTexto.ProcurarQualquerPalavra(strTexto);
                            strTexto = IS_Funcoes.TratarTexto.TratarTextoSQL(strTexto);
                            strWhere = "(logNome COLLATE Latin1_General_CI_AI LIKE '%" + strTexto + "%')";
                        }
                        break;

                    case 1:
                        if (!string.IsNullOrWhiteSpace(txtConteudo.Text))
                        {
                            strTexto = IS_Funcoes.SegurancaCripto.Criptografar(txtConteudo.Text);
                            strTexto = IS_Funcoes.TratarTexto.ProcurarQualquerPalavra(strTexto);
                            strTexto = IS_Funcoes.TratarTexto.TratarTextoSQL(strTexto);

                            strWhere = "(logLogin COLLATE Latin1_General_CI_AI LIKE '%" + strTexto + "%')";
                        }
                        break;

                    default:
                        MessageBox.Show("Selecione a opção de busca!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboProcurarPor.Focus();
                        return;
                }

                List<Administrativo_Entities.Usuario> listausuario = new Administrativo_BLL.Usuario().CarregarGrid(strWhere);

                dgvUsuario.AutoGenerateColumns = false;
                dgvUsuario.DataSource = listausuario;
                dgvUsuario.RowsDefaultCellStyle.BackColor = Color.White;
                dgvUsuario.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;

                // Controla Botões e Grid
                btnConfirmar.Enabled = !(dgvUsuario.Rows.Count == 0);
                dgvUsuario.Enabled = !(dgvUsuario.Rows.Count == 0);

                if (dgvUsuario.Rows.Count == 0)
                {
                    lblMensagem.Text = "Nenhum registro encontrado!";
                    txtConteudo.Focus();
                }
                else
                {                    
                    dgvUsuario.Focus();
                    lblMensagem.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void frmPesquisaUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void LimpaGrid()
        {
            dgvUsuario.DataSource = null;
        }

        private void txtConteudo_TextChanged(object sender, EventArgs e)
        {
            LimpaGrid();
            btnConfirmar.Enabled = false;
        }

        private void txtConteudo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cboProcurarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProcurarPor.SelectedIndex == 0)
            {
                //txtConteudo.Mask = "999999";
            }
            else
            {
                //txtConteudo.Mask = ">L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L>L";
            }
        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index != -1)
            {
                Resultado = Convert.ToString(dgvUsuario.Rows[index].Cells["PW_ID"].Value);
                this.Close();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            dgvUsuario_CellDoubleClick(this.dgvUsuario, new DataGridViewCellEventArgs(this.dgvUsuario.CurrentCell.ColumnIndex, this.dgvUsuario.CurrentRow.Index));
        }
    }
}
