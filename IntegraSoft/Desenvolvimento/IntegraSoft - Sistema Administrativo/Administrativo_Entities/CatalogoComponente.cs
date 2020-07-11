using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_Entities
{
    public class CatalogoComponente
    {
        public int cacoID { get; set; }
        public int cacoIDForm { get; set; }
        public string cacoNomeComponente { get; set; }
        public string cacoNomeAmigavel { get; set; }
        public bool cacoChecked { get; set; }
    }
}
