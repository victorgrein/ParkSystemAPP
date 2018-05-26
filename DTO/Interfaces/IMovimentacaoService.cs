using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IMovimentacaoService
    {
        void RegistrarEntrada(Movimentacao m);
        double RegistrarSaida(Movimentacao m);
        Movimentacao LerMovimentacao(string placa);
    }
}
