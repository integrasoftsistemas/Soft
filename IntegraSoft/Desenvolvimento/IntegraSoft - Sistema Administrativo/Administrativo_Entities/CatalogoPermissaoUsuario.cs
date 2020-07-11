using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_Entities
{
    public class CatalogoPermissaoUsuario
    {
        public int capeusID { get; set; }
        public int capeusIDComponente { get; set; }
        public int capeusIDPWUsuario { get; set; }
        public bool capeusPermissao { get; set; }

        public int cacoIDForm { get; set; }

    }
}
