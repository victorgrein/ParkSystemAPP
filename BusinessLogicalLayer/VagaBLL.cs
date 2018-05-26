using DataAccessLayer.Impl;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class VagaBLL : BaseValidator<Vaga>, IEntityBase<Vaga>, IVagaService
    {
        private VagaDAL vagaDAL = new VagaDAL();

        public int Insert(Vaga item)
        {
            //Tarefinha (Usar a classe TipoVagaBll para estudo
            throw new NotImplementedException();
        }
        public int Update(Vaga item)
        {
            //Tarefinha
            throw new NotImplementedException();
        }
        public int Delete(Vaga item)
        {
            //Tarefinha
            throw new NotImplementedException();
        }
        public bool Exists(Vaga item)
        {
            //Tarefinha
            throw new NotImplementedException();
        }

        public Vaga GetById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("ID inválido.");
            }
            return vagaDAL.GetById(id);
        }

        public List<Vaga> GetAll()
        {
            return vagaDAL.GetAll();
        }

        public void Ocupar(int id)
        {
            vagaDAL.Ocupar(id);
        }

        public void Desocupar(int id)
        {
             vagaDAL.Desocupar(id);
        }
    }
}
