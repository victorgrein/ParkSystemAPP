using DataAccessLayer.Infrastructure;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl
{
    public class TipoVagaDAL : IEntityBase<TipoVaga>
    {
        public int Insert(TipoVaga item)
        {
            return new DbExecuter().Execute(
                new SqlGenerator<TipoVaga>().GenerateInsertCommand(item));
        }

        public int Update(TipoVaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText =
                @"UPDATE TIPOSVAGA SET NOME = @NOME,
                                   VALOR = @VALOR 
                                   WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@VALOR", item.Valor);
            command.Parameters.AddWithValue("@ID", item.ID);
            return new DbExecuter().Execute(command);
        }

        public int Delete(TipoVaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText =
                "DELETE FROM TIPOSVAGA WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", item.ID);
            return new DbExecuter().Execute(command);
        }

        public bool Exists(TipoVaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT ID FROM TIPOSVAGA WHERE NOME = @NOME";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            DataTable table = new DbExecuter().GetData(command);
            return table.Rows.Count > 0;
        }

        public TipoVaga GetById(int id)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT * FROM TIPOSVAGA WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DbExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }

            TipoVaga tipoVaga = new TipoVaga();
            tipoVaga.ID = id;
            tipoVaga.Nome = (string)table.Rows[0]["NOME"];
            tipoVaga.Valor = Convert.ToDouble(table.Rows[0]["VALOR"]);
            return tipoVaga;
        }

        public List<TipoVaga> GetAll()
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT * FROM TIPOSVAGA";
            DataTable table = new DbExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            List<TipoVaga> tiposVagas = new List<TipoVaga>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TipoVaga tipoVaga = new TipoVaga();
                tipoVaga.ID = (int)table.Rows[i]["ID"];
                tipoVaga.Nome = (string)table.Rows[i]["NOME"];
                tipoVaga.Valor = Convert.ToDouble(table.Rows[i]["VALOR"]);
                tiposVagas.Add(tipoVaga);
            }
            return tiposVagas;
        }
    }
}
