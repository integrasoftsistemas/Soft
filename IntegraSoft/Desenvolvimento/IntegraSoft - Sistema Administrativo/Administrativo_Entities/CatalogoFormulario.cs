using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_Entities
{
    public class CatalogoFormulario
    {
        public int cafoID { get; set; }
        public string cafoNomeFormulario { get; set; }
        public string cafoNomeFullFormulario { get; set; }
        public string cafoNomeAmigavel { get; set; }
        public string cafoNomeMenuAcesso { get; set; }
        public bool cafoChecked { get; set; }

        public List<CatalogoComponente> CatalogoComponente { get; set; }

        public CatalogoFormulario()
        {
            this.CatalogoComponente = new List<CatalogoComponente>();
        }
        
    }
}
