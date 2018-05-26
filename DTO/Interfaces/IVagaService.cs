using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IVagaService
    {
        void Ocupar(int id);
        void Desocupar(int id);
    }
}
