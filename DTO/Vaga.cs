using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vaga : Entity
    {
        public string Codigo { get; set; }
        public int TipoVagaID { get; set; }
        public bool Ocupada { get; set; }
        public bool Coberta { get; set; }
        public bool Idoso { get; set; }
        public bool Especial { get; set; } 
    }
}
