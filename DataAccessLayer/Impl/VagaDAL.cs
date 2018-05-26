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
    public class VagaDAL : IEntityBase<Vaga>, IVagaService
    {
        public int Insert(Vaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "INSERT INTO VAGAS (CODIGO,TIPOVAGAID,OCUPADA,COBERTA,IDOSO,ESPECIAL) VALUES (@CODIGO,@TIPOVAGAID,@OCUPADA,@COBERTA,@IDOSO,@ESPECIAL)";
            command.Parameters.AddWithValue("@CODIGO", item.Codigo);
            command.Parameters.AddWithValue("@TIPOVAGAID", item.TipoVagaID);
            command.Parameters.AddWithValue("@OCUPADA", item.Ocupada);
            command.Parameters.AddWithValue("@COBERTA", item.Coberta);
            command.Parameters.AddWithValue("@IDOSO", item.Idoso);
            command.Parameters.AddWithValue("@ESPECIAL", item.Especial);
            return new DbExecuter().Execute(command);
        }

        public int Update(Vaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "UPDATE VAGAS SET CODIGO = @CODIGO, TIPOVAGAID = @TIPOVAGAID,OCUPADA = @OCUPADA,COBERTA = @COBERTA,IDOSO = @IDOSO,ESPECIAL = @ESPECIAL WHERE ID = @ID";
            command.Parameters.AddWithValue("@CODIGO", item.Codigo);
            command.Parameters.AddWithValue("@TIPOVAGAID", item.TipoVagaID);
            command.Parameters.AddWithValue("@OCUPADA", item.Ocupada);
            command.Parameters.AddWithValue("@COBERTA", item.Coberta);
            command.Parameters.AddWithValue("@IDOSO", item.Idoso);
            command.Parameters.AddWithValue("@ESPECIAL", item.Especial);
            command.Parameters.AddWithValue("@ID", item.ID);
            return new DbExecuter().Execute(command);
        }

        public int Delete(Vaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "DELETE FROM VAGAS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", item.ID);
            return new DbExecuter().Execute(command);
        }

        public bool Exists(Vaga item)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT ID FROM VAGAS WHERE CODIGO = @CODIGO";
            command.Parameters.AddWithValue("@CODIGO", item.Codigo);
            return new DbExecuter().GetData(command).Rows.Count > 0;
        }

        public Vaga GetById(int id)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT * FROM VAGAS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DbExecuter().GetData(command);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return new Vaga()
            {
                ID = id,
                Coberta = (bool)table.Rows[0]["COBERTA"],
                Codigo = (string)table.Rows[0]["CODIGO"],
                Especial = (bool)table.Rows[0]["ESPECIAL"],
                Idoso = (bool)table.Rows[0]["IDOSO"],
                Ocupada = (bool)table.Rows[0]["OCUPADA"],
                TipoVagaID = (int)table.Rows[0]["TIPOVAGAID"]
            };
        }

        public List<Vaga> GetAll()
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = "SELECT * FROM VAGAS";
            DataTable table = new DbExecuter().GetData(command);
            List<Vaga> vagas = new List<Vaga>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Vaga vaga = new Vaga()
                {
                    ID = (int)table.Rows[i]["ID"],
                    Coberta = (bool)table.Rows[i]["COBERTA"],
                    Codigo = (string)table.Rows[i]["CODIGO"],
                    Especial = (bool)table.Rows[i]["ESPECIAL"],
                    Idoso = (bool)table.Rows[i]["IDOSO"],
                    Ocupada = (bool)table.Rows[i]["OCUPADA"],
                    TipoVagaID = (int)table.Rows[i]["TIPOVAGAID"]
                };
                vagas.Add(vaga);
            }
            return vagas;
        }

        public void Ocupar(int id)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText = 
                "UPDATE VAGAS SET OCUPADA = @OCUPADA WHERE ID = @ID";
            command.Parameters.AddWithValue("@OCUPADA", true);
            command.Parameters.AddWithValue("@ID", id);
            new DbExecuter().Execute(command);
        }

        public void Desocupar(int id)
        {
            DbCommand command = DbFactory.GetCommand();
            command.CommandText =
                "UPDATE VAGAS SET OCUPADA = @OCUPADA WHERE ID = @ID";
            command.Parameters.AddWithValue("@OCUPADA", false);
            command.Parameters.AddWithValue("@ID", id);
            new DbExecuter().Execute(command);
        }
    }
}
