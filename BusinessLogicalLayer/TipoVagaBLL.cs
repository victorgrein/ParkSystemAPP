using DataAccessLayer.Impl;
using DTO;
using DTO.Interfaces;
using Instrumentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class TipoVagaBLL : BaseValidator<TipoVaga>, IEntityBase<TipoVaga>
    {
        private TipoVagaDAL tipoVagaDAL = new TipoVagaDAL();

        public override void Validate(TipoVaga entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Nome))
            {
                AddError("O nome deve ser informado.");
            }
            else if (entity.Nome.Length < 3 || entity.Nome.Length > 30)
            {
                AddError("O nome deve conter entre 3 e 30 caracteres.");
            }
            if (entity.Valor <= 0)
            {
                AddError("O valor deve ser maior que ZERO");
            }
            if(entity.ID == 0 && Exists(entity))
            {
                AddError("Este tipo de vaga já existe.");
            }
            base.Validate(entity);
        }

        public int Insert(TipoVaga item)
        {
            Validate(item);
            try
            {
                tipoVagaDAL.Insert(item);
            }
            catch(Exception ex)
            {
                /*LogHelper.Log(ex);*/
                throw new Exception("Erro na base de dados, contate o administrador.");
            }
            return 0;
        }

        public int Update(TipoVaga item)
        {
            Validate(item);
            try
            {
               return tipoVagaDAL.Update(item);
            }
            catch (Exception ex)
            {
                //Logar erro - Próxima aula
                throw new Exception("Erro na base de dados, contate o administrador.");
            }
        }

        public int Delete(TipoVaga item)
        {
            try
            {
                return tipoVagaDAL.Delete(item);
            }
            catch (Exception ex)
            {
                //Logar erro - Próxima aula
                throw new Exception("Erro na base de dados, contate o administrador.");
            }
        }

        public bool Exists(TipoVaga item)
        {
            return tipoVagaDAL.Exists(item);
        }

        public TipoVaga GetById(int id)
        {
            return tipoVagaDAL.GetById(id);
        }

        public List<TipoVaga> GetAll()
        {
            return tipoVagaDAL.GetAll();
        }
    }
}
