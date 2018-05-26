using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("TIPOSVAGA")]
    public class TipoVaga : Entity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
