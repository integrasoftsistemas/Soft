using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Funcoes
{
    public static class Formulario
    {
        public static void AbrirForm(Form frmParaAbrir, Form formMDI, bool mostraVersao = true)
        {
            Form frmAberto = null;

            FormCollection fc = Application.OpenForms;
            foreach (Form form in fc)
            {
                if (form.Name.ToLower() == frmParaAbrir.Name.ToLower())
                {
                    frmAberto = form;
                    break;
                }
            }

            //Icon ico = IS_Funcoes.Properties.Resources.icon;

            if (frmAberto != null)
            {
                //frmAberto.Icon = ico;
                frmAberto.WindowState = FormWindowState.Normal;
                frmAberto.Show();
                frmAberto.Focus();
            }
            else
            {
                if (mostraVersao)
                {
                    frmParaAbrir.Text = frmParaAbrir.Text + " - v " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                else
                {
                    frmParaAbrir.Text = frmParaAbrir.Text;
                }

                //frmParaAbrir.Icon = ico;
                frmParaAbrir.MdiParent = formMDI;
                frmParaAbrir.Show();
            }
        }       
    }
}
