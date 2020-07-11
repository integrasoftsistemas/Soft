using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Funcoes
{
    public static class Func_TreeView
    {
        public static int VerificarSeTemNoChecado(TreeNodeCollection nodes)
        {
            int nosChecados = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                TreeNode no = nodes[i];
                if (no.Checked)
                    nosChecados++;

                if (no.Nodes.Count > 0)
                    nosChecados += VerificarSeTemNoChecado(no.Nodes);
            }

            return nosChecados;
        }
    }
}
