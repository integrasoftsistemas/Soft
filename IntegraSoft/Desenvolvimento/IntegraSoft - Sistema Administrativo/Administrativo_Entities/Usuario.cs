using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_Entities
{
    public class Usuario
    {
        public int PW_ID { get; set; }
        public string PW_Nome { get; set; }
        public string PW_Email { get; set; }
        public string PW_Login { get; set; }
        public string PW_Senha { get; set; }
        public bool PW_Ativo { get; set; }
        public DateTime PW_DataCadastro { get; set; }
    }
}
