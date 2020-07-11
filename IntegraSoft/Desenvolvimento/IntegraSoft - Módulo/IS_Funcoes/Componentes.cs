using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Funcoes
{
    public static class Componentes
    {
        public static void LimpaTodoConteudoTextBox(Control.ControlCollection controles)
        {
            //Faz um laço para todos os controles passados no parâmetro
            foreach (Control ctrl in controles)
            {
                //Se o controle for um TextBox ...
                if (ctrl is TextBox)
                {
                   ((TextBox)(ctrl)).Text = String.Empty;
                }
            }
        }

        public static void LimpaTodoConteudoMaskedTextBox(Control.ControlCollection controles)
        {
            //Faz um laço para todos os controles passados no parâmetro
            foreach (Control ctrl in controles)
            {
                //Se o controle for um MaskedTextBox ...
                if (ctrl is MaskedTextBox)
                {
                   ((MaskedTextBox)(ctrl)).Text = String.Empty;
                }
            }
        }

        public static void TrataCorCampos(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if ((control is TextBox) ||
                    (control is RichTextBox) ||
                    (control is ComboBox) ||
                    (control is MaskedTextBox))
                {
                    control.Enter += new EventHandler(ControlFocus_Enter);
                    control.Leave += new EventHandler(ControlFocus_Leave);
                    control.EnabledChanged += new EventHandler(Control_EnabledChanged);
                }

                if (control is TextBox)
                    (control as TextBox).ReadOnlyChanged += new EventHandler(Control_ReadOnlyChanged);

                if (control is MaskedTextBox)
                    (control as MaskedTextBox).ReadOnlyChanged += new EventHandler(Control_ReadOnlyChanged);

                TrataCorCampos(control.Controls);
            }
        }
        
        private static void ControlFocus_Leave(object sender, EventArgs e)
        {
            if ((sender as Control).BackColor == Color.FromArgb(255, 255, 200)) // Amarelo
                 (sender as Control).BackColor = Color.FromName("Window");
        }

        private static void ControlFocus_Enter(object sender, EventArgs e)
        {
            if ((sender as Control).BackColor == Color.FromName("Window"))
                (sender as Control).BackColor = Color.FromArgb(255, 255, 200); // Amarelo
        }

        private static void Control_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
                if ((sender as Control).Enabled && !(sender as TextBox).ReadOnly)
                    (sender as Control).BackColor = SystemColors.Window;
                else
                    (sender as Control).BackColor = SystemColors.ButtonFace;
            else if (sender is MaskedTextBox)
                if ((sender as Control).Enabled && !(sender as MaskedTextBox).ReadOnly)
                    (sender as Control).BackColor = SystemColors.Window;
                else
                    (sender as Control).BackColor = SystemColors.ButtonFace;
            else
                if ((sender as Control).Enabled)
                (sender as Control).BackColor = SystemColors.Window;
            else
                (sender as Control).BackColor = SystemColors.ButtonFace;
        }

        private static void Control_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (!(sender as TextBox).ReadOnly)
                (sender as Control).BackColor = SystemColors.Window;
            else
                (sender as Control).BackColor = SystemColors.ButtonFace;
        }
    }
}
