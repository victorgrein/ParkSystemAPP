using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Movimentacao
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public int TempoCobrado { get; set; }
        public double Preco { get; set; }
        public DateTime? Duracao { get; set; }
        public string Modelo { get; set; }
        public int Cor { get; set; }
    }
}

